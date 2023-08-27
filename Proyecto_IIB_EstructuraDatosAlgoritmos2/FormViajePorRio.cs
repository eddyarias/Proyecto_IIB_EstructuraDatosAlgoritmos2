namespace Proyecto_IIB_EstructuraDatosAlgoritmos2
{
    using System.Windows.Forms;

    public partial class FormViajePorRio : Form
    {
        ViajePorRio viaje;
        private Timer timer;
        private int posicionBote = 0; // Posición inicial del bote
        private int[] embarcaderos; // Posiciones de los embarcaderos

        public FormViajePorRio()
        {
            InitializeComponent();

            viaje = new ViajePorRio();
            embarcaderos = new int[] { 120, 270, 420, 570, 720 }; // Ubicaciones en píxeles

            // Configura la GUI
            InitializeGUI();
        }


        private void InitializeGUI()
        {
            MostrarTarifasDGV();
            // Resto de la configuración de la GUI

            // Configurar el Timer
            timer = new Timer();
            timer.Interval = 2000; // Intervalo en milisegundos (2 segundos)
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

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            int origen = Convert.ToInt32(txtOrigen.Text) - 1;
            int destino = Convert.ToInt32(txtDestino.Text) - 1;

            int costoMinimo = viaje.CalcularCostoMinimo(origen, destino);

            // Recuperar la ruta óptima a partir de la matriz de rutas
            List<int> rutaOptima = viaje.RecuperarRutaOptima(origen, destino);

            // Mostrar el resultado en un cuadro de texto o etiqueta
            lbResultado.Text = "Costo mínimo: " + costoMinimo.ToString();
            lbRutasOptimas.Text = "Ruta óptima: " + string.Join(" -> ", rutaOptima);

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Mover el bote al siguiente embarcadero
            if (posicionBote < embarcaderos.Length - 1)
            {
                posicionBote++;
            }
            else
            {
                // Detener el Timer cuando el bote llega al último embarcadero
                timer.Stop();
            }

            // Actualizar la posición del bote en el PictureBox
            PBBote.Left = embarcaderos[posicionBote];
        }

        private void IniciarSimulacion_Click(object sender, EventArgs e)
        {
            posicionBote = 0;
            // Iniciar la simulación al hacer clic en el botón
            PBBote.Left = embarcaderos[posicionBote]; // Posicionar el bote al inicio
            timer.Start();
        }
    }

}
