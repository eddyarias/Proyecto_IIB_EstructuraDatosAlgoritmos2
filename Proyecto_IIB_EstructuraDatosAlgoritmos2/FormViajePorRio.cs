namespace Proyecto_IIB_EstructuraDatosAlgoritmos2
{
    using System;
    using System.Windows.Forms;

    public partial class FormViajePorRio : Form
    {
        ViajePorRio viaje;
        private Timer timer;
        private int[] embarcaderos; // Posiciones de los embarcaderos
        List<int> rutaOptima;
        List<Bote> botes = new List<Bote>();

        //para navegar
        private const int FRAMES_PER_SECOND = 30; // fps
        private int currentFrame = 0;
        private int totalFrames = 0;

        public FormViajePorRio()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            viaje = new ViajePorRio();
            embarcaderos = new int[] { 115, 265, 415, 565, 715 }; // Ubicaciones en píxeles

            // Agregar los botes a la lista
            botes.Add(new Bote(1, 115, 173, BUBote1));
            botes.Add(new Bote(2, 265, 173, BUBote2));
            botes.Add(new Bote(3, 415, 173, BUBote3));
            botes.Add(new Bote(4, 565, 173, BUBote4));

            // Configura la GUI
            InitializeGUI();
        }
        private void InitializeGUI()
        {
            MostrarTarifasDGV();
            // Configurar el Timer
            timer = new Timer();
            timer.Interval = 1000 / FRAMES_PER_SECOND;
            timer.Tick += Timer_Tick;
        }

        private void MostrarTarifasDGV()
        {
            dGVTarifas.ColumnCount = 3;
            dGVTarifas.Columns[0].Name = "Origen";
            dGVTarifas.Columns[1].Name = "Destino";
            dGVTarifas.Columns[2].Name = "Tarifa";

            // Recorrer la matriz de tarifas y agregar los valores al DataGridView
            for (int i = 0; i < viaje.n; i++)
            {
                for (int j = i + 1; j < viaje.n; j++)
                {
                    int tarifa = viaje.tarifas[i, j];
                    dGVTarifas.Rows.Add(i + 1, j + 1, tarifa);
                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (currentFrame < totalFrames)
            {
                int currentIndex = currentFrame / FRAMES_PER_SECOND;
                int nextIndex = currentIndex + 1;

                if (nextIndex < rutaOptima.Count)
                {
                    double progress = (double)(currentFrame % FRAMES_PER_SECOND) / FRAMES_PER_SECOND;

                    int currentEmbarcadero = rutaOptima[currentIndex] - 1;
                    int nextEmbarcadero = rutaOptima[nextIndex] - 1;

                    int interpolatedPositionLeft = (int)(embarcaderos[currentEmbarcadero] +
                                                         progress * (embarcaderos[nextEmbarcadero] - embarcaderos[currentEmbarcadero]));

                    // Buscar el bote correspondiente al embarcadero actual y ajustar la posición de su PictureBox
                    Bote boteActual = botes.FirstOrDefault(bote => bote.NumeroEmbarcadero == currentEmbarcadero + 1);
                    if (boteActual != null)
                    {
                        // Baja 50 pixeles suavemente utilizando interpolación cúbica
                        if (rutaOptima.Count == 2)
                        {
                            if (currentFrame == 0)
                            {
                                boteActual.PBBote.Top += 50;
                            }
                        }
                        else
                        {
                            boteActual.PBBote.BringToFront();

                            double verticalProgress = progress * progress * (3 - 2 * progress); // Interpolación cúbica

                            int originalTop = boteActual.PosicionOriginalTop;
                            int targetTop = originalTop + 50; // Posición final después del descenso

                            int verticalPosition = (int)(originalTop +
                                                         verticalProgress * (targetTop - originalTop));
                            boteActual.PBBote.Top = verticalPosition;
                        }
                        boteActual.PBBote.Left = interpolatedPositionLeft;
                    }

                    currentFrame++;
                }
                else
                {
                    // Detener el Timer cuando se hayan recorrido todos los frames
                    timer.Stop();
                }
            }
            else
            {
                // Detener el Timer cuando se hayan recorrido todos los frames
                timer.Stop();
            }
        }





        private void IniciarSimulacion_Click(object sender, EventArgs e)
        {
            timer.Stop();
            foreach (Bote bote in botes)
            {
                bote.RestaurarPosicion();
            }

            // Validar entrada de usuario
            if (!int.TryParse(txtOrigen.Text, out int origen) ||
                !int.TryParse(txtDestino.Text, out int destino))
            {
                MessageBox.Show("Ingrese el número del embarcadero de origen y destino.");
                return;
            }

            origen--; // Convertir a índice
            destino--;

            if (origen < 0 || destino < 0 || origen >= viaje.n || destino >= viaje.n)
            {
                MessageBox.Show("Los valores deben estar dentro del rango de embarcaderos.");
                return;
            }

            if (origen >= destino)
            {
                MessageBox.Show("Solo puede ir río abajo.");
                return;
            }

            //Calcula el costo mínimo y la ruta óptima
            int costoMinimo = viaje.CalcularCostoMinimo(origen, destino);

            // Recuperar la ruta óptima a partir de la matriz de rutas
            rutaOptima = viaje.RecuperarRutaOptima(origen, destino);

            // Mostrar el resultado en el label
            lbResultado.Text = "Costo mínimo: " + costoMinimo.ToString();
            lbRutasOptimas.Text = "Ruta óptima: " + string.Join(" -> ", rutaOptima);

            //inicia y reinicia la simulación
            totalFrames = rutaOptima.Count * FRAMES_PER_SECOND;
            currentFrame = 0;
            timer.Start();// Iniciar el timer
        }

        //Para restaurar la posición de los barcos.
        private void txtOrigen_TextChanged(object sender, EventArgs e)
        {
            timer.Stop();
            // Restaurar la posición de todos los barcos
            foreach (Bote bote in botes)
            {
                bote.RestaurarPosicion();
            }
        }
        private void txtDestino_TextChanged(object sender, EventArgs e)
        {
            timer.Stop();
            // Restaurar la posición de todos los barcos
            foreach (Bote bote in botes)
            {
                bote.RestaurarPosicion();
            }
        }
    }
}
