namespace Proyecto_IIB_EstructuraDatosAlgoritmos2
{
    public partial class Form1 : Form
    {
        private int[,] tarifas; // Matriz triangular superior de tarifas
        private int n; // Número de embarcaderos
        private int[,] dp; // Matriz de programación dinámica para almacenar los resultados calculados
        private int[,] rutas; // Matriz para almacenar las rutas óptimas

        public Form1()
        {
            InitializeComponent();

            // Inicializa la matriz de tarifas y el número de embarcaderos (debes asignar valores apropiados)
            n = 5; // Por ejemplo, 5 embarcaderos
            tarifas = new int[,]
            {
                { 0, 10, 15, 20, 25 },
                { 0,  0, 12, 18, 24 },
                { 0,  0,  0,  2, 15 },
                { 0,  0,  0,  0, 10 },
                { 0,  0,  0,  0,  0 }
            };

            dp = new int[n, n];
            rutas = new int[n, n];

            // Configura la GUI
            InitializeGUI();
        }


        private void MostrarTarifasEnLabel()
        {
            lbTarifas.Text = "Tarifas:\n";

            // Recorrer la matriz de tarifas y agregar los valores al label
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    lbTarifas.Text += $"Tarifa [{i}, {j}]: {tarifas[i, j]}\n";
                }
            }

            // Ajustar la posición y tamaño del label
            lbTarifas.AutoSize = true;
        }

        private void InitializeGUI()
        {
            // Configuración de controles y diseño de la interfaz gráfica
            // Agrega botones, cuadros de texto, etiquetas, etc.

            MostrarTarifasEnLabel();
            // Ejemplo de cómo manejar el cálculo del costo más barato al hacer clic en un botón
            btnCalcular.Click += btnCalcular_Click;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            int origen = Convert.ToInt32(txtOrigen.Text);
            int destino = Convert.ToInt32(txtDestino.Text);

            int costoMinimo = CalcularCostoMinimo(origen, destino);

            // Recuperar la ruta óptima a partir de la matriz de rutas
            List<int> rutaOptima = RecuperarRutaOptima(origen, destino);

            // Mostrar el resultado en un cuadro de texto o etiqueta
            lbResultado.Text = "Costo mínimo: " + costoMinimo.ToString();
            lbRutasOptimas.Text = "Ruta óptima: " + string.Join(" -> ", rutaOptima);

        }

        private int CalcularCostoMinimo(int origen, int destino)
        {
            if (origen >= destino)
                return 0; // No se puede viajar río arriba

            // Si ya hemos calculado el resultado, lo retornamos directamente desde la matriz dp
            if (dp[origen, destino] != 0)
                return dp[origen, destino];

            int costoMinimo = int.MaxValue;
            int siguienteEmbarcadero = -1; //ruta


            // Recorremos los posibles embarcaderos intermedios
            for (int k = origen + 1; k <= destino; k++)
            {
                int costoViajeDirecto = tarifas[origen, k];
                int costoRestante = CalcularCostoMinimo(k, destino);
                int costoTotal = costoViajeDirecto + costoRestante;

                //// Calculamos el costo mínimo tomando el mínimo entre todas las posibilidades de embarcaderos intermedios
                //costoMinimo = Math.Min(costoMinimo, costoTotal);

                if (costoTotal < costoMinimo) //ruta
                {
                    costoMinimo = costoTotal;
                    siguienteEmbarcadero = k;
                }
            }

            // Almacenamos el resultado en la matriz dp para evitar recálculos futuros
            dp[origen, destino] = costoMinimo;
            rutas[origen, destino] = siguienteEmbarcadero;

            return costoMinimo;
        }


        private List<int> RecuperarRutaOptima(int origen, int destino)
        {
            List<int> ruta = new List<int>();
            while (origen != destino)
            {
                ruta.Add(origen);
                origen = rutas[origen, destino];
            }
            ruta.Add(destino);

            return ruta;
        }
    }
}
