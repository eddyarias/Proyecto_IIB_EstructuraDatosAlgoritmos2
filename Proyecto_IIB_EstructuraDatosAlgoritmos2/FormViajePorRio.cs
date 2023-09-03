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
        List<Bote> botesBU;
        List<Bote> botesTD;
        //para navegar
        private const int FRAMES_PER_SECOND = 30; // fps
        private int currentFrame = 0;
        private int totalFrames = 0;

        public FormViajePorRio()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            viaje = new ViajePorRio();
            botesBU = new List<Bote>();
            botesTD = new List<Bote>();
            embarcaderos = new int[] { 50, 200, 350, 500, 650, 800, 950, 1100, 1250, 1400 }; // Ubicaciones en píxeles

            // Agregar los botes a la lista Bottom-Up
            botesBU.Add(new Bote(1, 40, 173, BUBote1));
            botesBU.Add(new Bote(2, 190, 173, BUBote2));
            botesBU.Add(new Bote(3, 340, 173, BUBote3));
            botesBU.Add(new Bote(4, 490, 173, BUBote4));
            botesBU.Add(new Bote(5, 640, 173, BUBote5));
            botesBU.Add(new Bote(6, 790, 173, BUBote6));
            botesBU.Add(new Bote(7, 940, 173, BUBote7));
            botesBU.Add(new Bote(8, 1090, 173, BUBote8));
            botesBU.Add(new Bote(9, 1240, 173, BUBote9));

            // Agregar los botes a la lista Top-Down
            botesTD.Add(new Bote(1, 40, 173, TDBote1));
            botesTD.Add(new Bote(2, 190, 173, TDBote2));
            botesTD.Add(new Bote(3, 340, 173, TDBote3));
            botesTD.Add(new Bote(4, 490, 173, TDBote4));
            botesTD.Add(new Bote(5, 640, 173, TDBote5));
            botesTD.Add(new Bote(6, 790, 173, TDBote6));
            botesTD.Add(new Bote(7, 940, 173, TDBote7));
            botesTD.Add(new Bote(8, 1090, 173, TDBote8));
            botesTD.Add(new Bote(9, 1240, 173, TDBote9));

            // Configura la GUI
            InitializeGUI();
        }
        private void InitializeGUI()
        {
            MostrarTarifasDGV();
            // Configurar el Timer
            timer = new Timer();
            timer.Interval = 1000 / (FRAMES_PER_SECOND / 3); // Actualizar cada 3 cuadros
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
                    Bote boteActualBU = botesBU.FirstOrDefault(bote => bote.NumeroEmbarcadero == currentEmbarcadero + 1);
                    Bote boteActualTD = botesTD.FirstOrDefault(bote => bote.NumeroEmbarcadero == currentEmbarcadero + 1);
                    if (boteActualBU != null&& boteActualTD != null)
                    {
                        // Baja 50 pixeles suavemente utilizando interpolación cúbica
                        if (rutaOptima.Count == 2)
                        {
                            if (currentFrame == 0)
                            {
                                boteActualBU.PBBote.Top += 60;
                                boteActualTD.PBBote.Top += 60;
                            }
                        }
                        else
                        {
                            double verticalProgress = progress * progress * (3 - 2 * progress); // Interpolación cúbica

                            int originalTop = boteActualBU.PosicionOriginalTop;
                            int targetTop = originalTop + 60; // Posición final después del descenso

                            int verticalPosition = (int)(originalTop +
                                                         verticalProgress * (targetTop - originalTop));
                            boteActualBU.PBBote.Top = verticalPosition;
                            boteActualTD.PBBote.Top = verticalPosition;
                        }
                        boteActualBU.PBBote.Left = interpolatedPositionLeft;
                        boteActualTD.PBBote.Left = interpolatedPositionLeft;
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
            foreach (Bote bote in botesBU)
            {
                bote.RestaurarPosicion();
            }
            foreach (Bote bote in botesTD)
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
            int costoMinimo = viaje.CalcularCostoMinimoBottomUp(origen, destino);

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
            foreach (Bote bote in botesBU)
            {
                bote.RestaurarPosicion();
            }
            foreach (Bote bote in botesTD)
            {
                bote.RestaurarPosicion();
            }
        }
        private void txtDestino_TextChanged(object sender, EventArgs e)
        {
            timer.Stop();
            // Restaurar la posición de todos los barcos
            foreach (Bote bote in botesBU)
            {
                bote.RestaurarPosicion();
            }
            foreach (Bote bote in botesTD)
            {
                bote.RestaurarPosicion();
            }
        }
    }
}
