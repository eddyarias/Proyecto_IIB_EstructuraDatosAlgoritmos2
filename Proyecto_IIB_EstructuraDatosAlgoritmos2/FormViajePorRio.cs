namespace Proyecto_IIB_EstructuraDatosAlgoritmos2
{
    using System;
    using System.Diagnostics;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public partial class FormViajePorRio : Form
    {

        ViajePorRio viaje;
        private Timer timerTD;
        private Timer timerBU;
        private int[] embarcaderos; // Posiciones de los embarcaderos
        List<int> rutaOptimaTD;
        List<int> rutaOptimaBU;
        List<Bote> botesBU;
        List<Bote> botesTD;
        //para navegar
        private const int FRAMES_PER_SECOND = 40; // fps
        private int currentFrameTD = 0;
        private int currentFrameBU = 0;
        private int totalFramesTD = 0;
        private int totalFramesBU = 0;

        public FormViajePorRio()
        {

            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            viaje = new ViajePorRio();
            botesBU = new List<Bote>();
            botesTD = new List<Bote>();
            embarcaderos = new int[] { 50, 200, 350, 500, 650, 800, 950, 1100, 1250, 1400 }; // Ubicaciones en píxeles

            // Agregar los botes a la lista Top-Down
            botesTD.Add(new Bote(1, 40, 173, TDBote1));
            botesTD.Add(new Bote(2, 190, 173, TDBote2));
            botesTD.Add(new Bote(3, 340, 173, TDBote3));
            botesTD.Add(new Bote(4, 490, 173, TDBote4));
            //botesTD.Add(new Bote(5, 640, 173, TDBote5));
            //botesTD.Add(new Bote(6, 790, 173, TDBote6));
            //botesTD.Add(new Bote(7, 940, 173, TDBote7));
            //botesTD.Add(new Bote(8, 1090, 173, TDBote8));
            //botesTD.Add(new Bote(9, 1240, 173, TDBote9));

            // Agregar los botes a la lista Bottom-Up
            botesBU.Add(new Bote(1, 40, 173, BUBote1));
            botesBU.Add(new Bote(2, 190, 173, BUBote2));
            botesBU.Add(new Bote(3, 340, 173, BUBote3));
            botesBU.Add(new Bote(4, 490, 173, BUBote4));
            //botesBU.Add(new Bote(5, 640, 173, BUBote5));
            //botesBU.Add(new Bote(6, 790, 173, BUBote6));
            //botesBU.Add(new Bote(7, 940, 173, BUBote7));
            //botesBU.Add(new Bote(8, 1090, 173, BUBote8));
            //botesBU.Add(new Bote(9, 1240, 173, BUBote9));

            // Configura los Timers
            timerTD = new Timer();
            timerTD.Interval = 1000 / (FRAMES_PER_SECOND); // Actualizar cada 3 cuadros
            timerTD.Tick += TimerTD_Tick;

            timerBU = new Timer();
            timerBU.Interval = 1000 / (FRAMES_PER_SECOND); // Actualizar cada 3 cuadros
            timerBU.Tick += TimerBU_Tick;

            MostrarTarifasDGV();
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

        private void TimerTD_Tick(object sender, EventArgs e)
        {
            if (currentFrameTD < totalFramesTD)
            {
                int currentIndex = currentFrameTD / FRAMES_PER_SECOND;
                int nextIndex = currentIndex + 1;

                if (nextIndex < rutaOptimaTD.Count)
                {
                    double progress = (double)(currentFrameTD % FRAMES_PER_SECOND) / FRAMES_PER_SECOND;

                    int currentEmbarcaderoTD = rutaOptimaTD[currentIndex] - 1;
                    int nextEmbarcaderoTD = rutaOptimaTD[nextIndex] - 1;

                    int interpolatedPositionLeftTD = (int)(embarcaderos[currentEmbarcaderoTD] +
                                                            progress * (embarcaderos[nextEmbarcaderoTD] - embarcaderos[currentEmbarcaderoTD]));

                    // Buscar el bote correspondiente al embarcadero actual y ajustar la posición de su PictureBox
                    Bote boteActualTD = botesTD.FirstOrDefault(bote => bote.NumeroEmbarcadero == currentEmbarcaderoTD + 1);
                    boteActualTD.PBBote.BringToFront();

                    if (boteActualTD != null)
                    {
                        // Baja 50 pixeles suavemente utilizando interpolación cúbica
                        if (rutaOptimaTD.Count == 2)
                        {
                            if (currentFrameTD == 0)
                            {
                                boteActualTD.PBBote.Top += 60;
                            }
                        }
                        else
                        {
                            double verticalProgress = progress * progress * (3 - 2 * progress); // Interpolación cúbica

                            int originalTop = boteActualTD.PosicionOriginalTop;
                            int targetTop = originalTop + 60; // Posición final después del descenso

                            int verticalPosition = (int)(originalTop +
                                                         verticalProgress * (targetTop - originalTop));
                            boteActualTD.PBBote.Top = verticalPosition;
                        }
                        boteActualTD.PBBote.Left = interpolatedPositionLeftTD;
                    }

                    currentFrameTD++;
                }
                else
                {
                    // Detener el Timer cuando se hayan recorrido todos los frames
                    timerTD.Stop();
                }
            }
            else
            {
                // Detener el Timer cuando se hayan recorrido todos los frames
                timerTD.Stop();
            }
        }

        private void TimerBU_Tick(object sender, EventArgs e)
        {
            if (currentFrameBU < totalFramesBU)
            {
                int currentIndex = currentFrameBU / FRAMES_PER_SECOND;
                int nextIndex = currentIndex + 1;

                if (nextIndex < rutaOptimaBU.Count)
                {
                    double progress = (double)(currentFrameBU % FRAMES_PER_SECOND) / FRAMES_PER_SECOND;

                    int currentEmbarcaderoBU = rutaOptimaBU[currentIndex] - 1;
                    int nextEmbarcaderoBU = rutaOptimaBU[nextIndex] - 1;

                    int interpolatedPositionLeftBU = (int)(embarcaderos[currentEmbarcaderoBU] +
                                                            progress * (embarcaderos[nextEmbarcaderoBU] - embarcaderos[currentEmbarcaderoBU]));

                    // Buscar el bote correspondiente al embarcadero actual y ajustar la posición de su PictureBox
                    Bote boteActualBU = botesBU.FirstOrDefault(bote => bote.NumeroEmbarcadero == currentEmbarcaderoBU + 1);
                    boteActualBU.PBBote.BringToFront();
                    if (boteActualBU != null)
                    {
                        // Baja 60 pixeles suavemente utilizando interpolación cúbica
                        if (rutaOptimaBU.Count == 2)
                        {
                            if (currentFrameBU == 0)
                            {
                                boteActualBU.PBBote.Top += 60;
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
                        }
                        boteActualBU.PBBote.Left = interpolatedPositionLeftBU;
                    }

                    currentFrameBU++;
                }
                else
                {
                    // Detener el Timer cuando se hayan recorrido todos los frames
                    timerBU.Stop();
                }
            }
            else
            {
                // Detener el Timer cuando se hayan recorrido todos los frames
                timerBU.Stop();
            }
        }


        private void IniciarSimulacion_Click(object sender, EventArgs e)
        {
            timerTD.Stop();
            timerBU.Stop();
            currentFrameTD = 0;
            currentFrameBU = 0;
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

            // Medir el tiempo de ejecución para el enfoque Top-Down
            var stopwatchTD = new Stopwatch();
            stopwatchTD.Start();
            int costoMinimoTD = viaje.CalcularCostoMinimoTopDown(origen, destino);
            stopwatchTD.Stop();

            // Medir el tiempo de ejecución para el enfoque Bottom-Up
            var stopwatchBU = new Stopwatch();
            stopwatchBU.Start();
            int costoMinimoBU = viaje.CalcularCostoMinimoBottomUp(origen, destino);
            stopwatchBU.Stop();

            // Recuperar la ruta óptima a partir de la matriz de rutas
            rutaOptimaTD = viaje.RecuperarRutaOptimaTopDown(origen, destino);
            rutaOptimaBU = viaje.RecuperarRutaOptimaBottomUp(origen, destino);

            // Mostrar el resultado en el label TopDown
            lbResultadoTD.Text = "Costo mínimo: " + costoMinimoTD.ToString();
            lbTiempoEjecucionTD.Text = "Tiempo de ejecución (ns): " + ((stopwatchTD.ElapsedTicks * 1000000000) / Stopwatch.Frequency).ToString();
            lbRutasOptimasTD.Text = "Ruta óptima: " + string.Join(" -> ", rutaOptimaTD);

            // Mostrar el resultado en el label BottomUp
            lbResultadoBU.Text = "Costo mínimo: " + costoMinimoBU.ToString();
            lbTiempoEjecucionBU.Text = "Tiempo de ejecución (ns): " + ((stopwatchBU.ElapsedTicks * 1000000000) / Stopwatch.Frequency).ToString();
            lbRutasOptimasBU.Text = "Ruta óptima: " + string.Join(" -> ", rutaOptimaBU);

            //inicia y reinicia la simulación para Top-Down
            totalFramesTD = rutaOptimaTD.Count * FRAMES_PER_SECOND;
            timerTD.Start();

            //inicia y reinicia la simulación para Bottom-Up
            totalFramesBU = rutaOptimaBU.Count * FRAMES_PER_SECOND;
            timerBU.Start();
        }


        //Para restaurar la posición de los barcos.
        private void txtOrigen_TextChanged(object sender, EventArgs e)
        {
            timerTD.Stop();
            timerBU.Stop();
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
            timerTD.Stop();
            timerBU.Stop();
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
