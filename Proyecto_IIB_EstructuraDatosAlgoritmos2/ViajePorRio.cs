namespace Proyecto_IIB_EstructuraDatosAlgoritmos2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class ViajePorRio
    {
        public int[,] tarifas; // Matriz triangular superior de tarifas
        public int n; // Número de embarcaderos
        public int[,] dp; // Matriz de programación dinámica para almacenar los resultados calculados
        public int[,] rutas; // Matriz para almacenar las rutas óptimas

        public ViajePorRio()
        {
            n = 10; // Número de embarcaderos
            tarifas = new int[,]
            {
            { 0, 10, 15, 20, 25, 30, 35, 40, 45, 50 },
            { 0,  0, 12, 18, 24, 28, 33, 38, 43, 48 },
            { 0,  0,  0,  2, 15, 21, 26, 31, 36, 41 },
            { 0,  0,  0,  0, 10, 16, 22, 27, 32, 37 },
            { 0,  0,  0,  0,  0,  8, 14, 19, 24, 29 },
            { 0,  0,  0,  0,  0,  0, 11, 17, 22, 27 },
            { 0,  0,  0,  0,  0,  0,  0,  9, 15, 20 },
            { 0,  0,  0,  0,  0,  0,  0,  0,  7, 13 },
            { 0,  0,  0,  0,  0,  0,  0,  0,  0,  6 },
            { 0,  0,  0,  0,  0,  0,  0,  0,  0,  0 }
            };

            dp = new int[n, n];
            rutas = new int[n, n];
        }

        //Milton
        public int CalcularCostoMinimoBottomUp(int origen, int destino)
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
                int costoRestante = CalcularCostoMinimoBottomUp(k, destino);
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

        //javier, programacion dinamica para el viaje mas barato en rio con el enfoque TOP-DOWn
        //public int CalcularCostoMinimoTopDown(int origen, int destino)
        //{
        //}

        public List<int> RecuperarRutaOptima(int origen, int destino)
        {
            List<int> ruta = new List<int>();

            while (origen != destino)
            {
                ruta.Add(origen);
                origen = rutas[origen, destino];
            }
            ruta.Add(destino);

            // Sumar 1 a cada elemento de la lista
            for (int i = 0; i < ruta.Count; i++)
            {
                ruta[i] += 1;
            }

            return ruta;
        }

    }
}


