using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EXUI_Leyva.Models
{
    public class ClsSuma
    {
        public int Numero { get; set; }
        public List<string> Formas { get; set; }
        public int TotalFormas { get; set; }

        public ClsSuma()
        {
            Formas = new List<string>();
            TotalFormas = 0;
        }

        public string CalcularFormas(int numero)
        {
            if (numero <= 0)
            {
                return "El número debe ser un entero positivo";
            }

            if (numero > 10)
            {
                return "El número no puede ser mayor a 10";
            }

            Numero = numero;
            Formas.Clear();

            // Generar todas las particiones
            GenerarParticiones(numero, numero, new List<int>());

            // Invertir la lista para que aparezcan en el orden correcto
            Formas.Reverse();

            TotalFormas = Formas.Count;

            return "success";
        }

        private void GenerarParticiones(int numeroRestante, int maximo, List<int> particionActual)
        {
            if (numeroRestante == 0)
            {
                // Convertir la partición a string
                string forma = string.Join(" + ", particionActual);
                Formas.Add(forma);
                return;
            }

            for (int i = Math.Min(numeroRestante, maximo); i >= 1; i--)
            {
                List<int> nuevaParticion = new List<int>(particionActual);
                nuevaParticion.Add(i);
                GenerarParticiones(numeroRestante - i, i, nuevaParticion);
            }
        }
    }
}