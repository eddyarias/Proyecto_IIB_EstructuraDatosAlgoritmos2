namespace Proyecto_IIB_EstructuraDatosAlgoritmos2
{
    using System.Windows.Forms;

    public partial class FormViajePorRio : Form
    {
        ViajePorRio viaje;
        private Timer timer;
        private int posicionBote = 0; // Posición inicial del bote
        private int[] embarcaderos; // Posiciones de los embarcaderos
        List<int> rutaOptima;
        public FormViajePorRio()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;


            viaje = new ViajePorRio();
            embarcaderos = new int[] { 0, 120, 270, 420, 570, 720 }; // Ubicaciones en píxeles

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
            timer.Interval = 1000; // Intervalo en milisegundos (1 segundo)
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
            // Verificar si aún quedan posiciones en la lista de rutaOptima
            if (posicionBote < rutaOptima.Count)
            {
                // Actualizar la posición del bote según la próxima posición en la lista
                int proximoEmbarcadero = rutaOptima[posicionBote];
                PBBote.Left = embarcaderos[proximoEmbarcadero];//la ruta óptima ya empieza desde el 1

                // Incrementar la posición para el próximo Tick
                posicionBote++;
            }
            else
            {
                // Detener el Timer cuando se hayan recorrido todos los embarcaderos en la rutaOptima
                timer.Stop();
            }
        }

        private void IniciarSimulacion_Click(object sender, EventArgs e)
        {
            // Validar entrada de usuario
            if (!int.TryParse(txtOrigen.Text, out int origen) ||
                !int.TryParse(txtDestino.Text, out int destino))
            {
                MessageBox.Show("Por favor, ingrese valores numéricos enteros.");
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
                MessageBox.Show("El valor de origen debe ser menor que el valor de destino.");
                return;
            }

            //Calcula el costo mínimo y la ruta óptima
            int costoMinimo = viaje.CalcularCostoMinimo(origen, destino);

            // Recuperar la ruta óptima a partir de la matriz de rutas
            rutaOptima = viaje.RecuperarRutaOptima(origen, destino);

            // Mostrar el resultado en el label
            lbResultado.Text = "Costo mínimo: " + costoMinimo.ToString();
            lbRutasOptimas.Text = "Ruta óptima: " + string.Join(" -> ", rutaOptima);

            // Iniciar la simulación
            posicionBote = 0;
            PBBote.Left = embarcaderos[posicionBote]; // Posicionar el bote al inicio
            timer.Start();
        }
    }

}
