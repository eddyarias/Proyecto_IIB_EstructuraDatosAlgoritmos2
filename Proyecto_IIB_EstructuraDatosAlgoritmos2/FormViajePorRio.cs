namespace Proyecto_IIB_EstructuraDatosAlgoritmos2
{
    using System.Windows.Forms;

    public partial class FormViajePorRio : Form
    {
        ViajePorRio viaje;
        private Timer timer;
        private int[] embarcaderos; // Posiciones de los embarcaderos
        List<int> rutaOptima;

        //para navegar
        private const int FRAMES_PER_SECOND = 60; // fps
        private int currentFrame = 0;
        private int totalFrames = 0;
        public FormViajePorRio()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;


            viaje = new ViajePorRio();
            embarcaderos = new int[] { 120, 270, 420, 570, 720 }; // Ubicaciones en píxeles

            // Configura la GUI
            InitializeGUI();
            // Deshabilitar temporalmente la selección de celdas
            dGVTarifas.Enabled = false;

            // Limpia la selección de celdas en el DataGridView al inicializar
            dGVTarifas.ClearSelection();
            // Habilitar la selección de celdas nuevamente
            dGVTarifas.Enabled = true;
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

                    int interpolatedPosition = (int)(embarcaderos[currentEmbarcadero] +
                                                     progress * (embarcaderos[nextEmbarcadero] - embarcaderos[currentEmbarcadero]));

                    PBBote.Left = interpolatedPosition;

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
    }

}
