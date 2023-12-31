﻿namespace Proyecto_IIB_EstructuraDatosAlgoritmos2
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class ViajePorRio
    {
        public int[,] tarifas; // Matriz triangular superior de tarifas
        public int n; // Número de embarcaderos
        public int[,] dp; // Matriz de programación dinámica para almacenar los resultados calculados
        public int[,] rutasTD; // Matriz para almacenar las rutas óptimas TopDown
        public int[] costosMinimos; // Matriz para almacenar las rutas óptimas ButtonUp
        public ViajePorRio()
        {
            n = 5; // Número de embarcaderos
            tarifas = new int[,]
            {
                //{ 0, 10, 15, 20, 25, 30, 35, 32, 45, 42 },
                //{ 0,  0, 12, 18, 22, 28, 33, 30, 43, 48 },
                //{ 0,  0,  0,  2, 10, 21, 26, 31, 36, 41 },
                //{ 0,  0,  0,  0, 10, 16, 22, 20, 32, 37 },
                //{ 0,  0,  0,  0,  0,  8, 14, 19, 24, 22 },
                //{ 0,  0,  0,  0,  0,  0, 11, 17, 22, 27 },
                //{ 0,  0,  0,  0,  0,  0,  0,  9, 15, 20 },
                //{ 0,  0,  0,  0,  0,  0,  0,  0,  7, 13 },
                //{ 0,  0,  0,  0,  0,  0,  0,  0,  0,  6 },
                //{ 0,  0,  0,  0,  0,  0,  0,  0,  0,  0 }

                { 0, 10, 15, 20, 25},
                { 0,  0, 12, 18, 22},
                { 0,  0,  0,  2, 10},
                { 0,  0,  0,  0, 10},
                { 0,  0,  0,  0,  0}
            };

            dp = new int[n, n];
            rutasTD = new int[n, n];
            costosMinimos = new int[n];
        }

        // Método para calcular el costo mínimo utilizando programación dinámica con enfoque "Top-Down"
        public int CalcularCostoMinimoTopDown(int origen, int destino)
        {
            if (origen >= destino)
                return 0; // No se puede viajar río arriba

            // Si ya hemos calculado el resultado, lo retornamos directamente desde la matriz dp
            if (dp[origen, destino] != 0)
                return dp[origen, destino];

            int costoMinimo = int.MaxValue;
            int siguienteEmbarcadero = -1; // Ruta

            // Recorremos los posibles embarcaderos intermedios
            for (int k = origen + 1; k <= destino; k++)
            {
                int costoViajeDirecto = tarifas[origen, k];
                int costoRestante = CalcularCostoMinimoTopDown(k, destino);
                int costoTotal = costoViajeDirecto + costoRestante;

                if (costoTotal < costoMinimo) // Actualizamos el costo mínimo y la siguiente ruta
                {
                    costoMinimo = costoTotal;
                    siguienteEmbarcadero = k;
                }
            }

            // Almacenamos el resultado en la matriz dp para evitar recálculos futuros
            dp[origen, destino] = costoMinimo;
            rutasTD[origen, destino] = siguienteEmbarcadero;

            return costoMinimo;
        }

        public List<int> RecuperarRutaOptimaTopDown(int origen, int destino)
        {
            List<int> rutaTD = new List<int>();

            while (origen != destino)
            {
                rutaTD.Add(origen); // Agregar el embarcadero actual a la ruta
                origen = rutasTD[origen, destino]; // Cambiar al siguiente embarcadero en la ruta
            }
            rutaTD.Add(destino); // Agregar el destino final a la ruta

            // Sumar 1 a cada elemento de la lista 
            for (int i = 0; i < rutaTD.Count; i++)
            {
                rutaTD[i] += 1; // Sumar 1 a cada elemento de la ruta (opcional)
            }
            return rutaTD; // Devolver la ruta óptima
        }


        public int CalcularCostoMinimoBottomUp(int origen, int destino)
        {
            // Inicializar todos los costos mínimos a un valor máximo, excepto el origen que es 0.
            for (int i = 0; i < n; i++)
            {
                costosMinimos[i] = int.MaxValue;
            }

            costosMinimos[origen] = 0; // Establecer el costo mínimo para el origen como 0.

            for (int i = origen; i < destino; i++)
            {
                for (int j = i + 1; j <= destino; j++)
                {
                    // Calcular el costo actual sumando la tarifa entre i y j con el costo mínimo en i.
                    int costoActual = tarifas[i, j] + costosMinimos[i];

                    // Si el costo actual es menor que el costo mínimo registrado en j, actualizarlo.
                    if (costoActual < costosMinimos[j])
                    {
                        costosMinimos[j] = costoActual;
                    }
                }
            }

            // Reconstruir la ruta óptima y devolver el costo mínimo
            return costosMinimos[destino];
        }
        public List<int> RecuperarRutaOptimaBottomUp(int origen, int destino)
        {
            List<int> rutaBU = new List<int>();
            int embarcaderoActual = destino; // Comenzamos desde el destino

            while (embarcaderoActual != origen)
            {
                rutaBU.Insert(0, embarcaderoActual); // Agregar el embarcadero actual al principio de la ruta
                int costoActual = costosMinimos[embarcaderoActual];

                // Buscar el embarcadero anterior en la ruta óptima
                for (int i = origen; i < embarcaderoActual; i++)
                {
                    if (tarifas[i, embarcaderoActual] + costosMinimos[i] == costoActual)
                    {
                        embarcaderoActual = i;
                        break;
                    }
                }
            }

            rutaBU.Insert(0, origen); // Agregar el origen al principio de la ruta
            // Sumar 1 a cada elemento de la lista 
            for (int i = 0; i < rutaBU.Count; i++)
            {
                rutaBU[i] += 1; // Sumar 1 a cada elemento de la ruta (opcional)
            }
            return rutaBU;
        }


    }

}



