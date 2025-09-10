using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EXUI_Leyva.Models
{
    public class ClsOperaciones
    {
        public int Numero { get; set; }
        public List<int> Numeros { get; set; }
        public double Suma { get; set; }
        public double Promedio { get; set; }
        public int Maximo { get; set; }
        public int Minimo { get; set; }
        public bool TieneNumeros { get; set; }

        public ClsOperaciones()
        {
            Numeros = new List<int>();
            Suma = 0;
            Promedio = 0;
            Maximo = 0;
            Minimo = 0;
            TieneNumeros = false;
        }

        public string AgregarNumero(int numero)
        {
            if (numero < 0)
            {
                return "No se aceptan números negativos";
            }

            Numeros.Add(numero);
            TieneNumeros = true;
            return "success";
        }

        public void CalcularOperaciones()
        {
            if (Numeros.Count > 0)
            {
                Suma = Numeros.Sum();
                Promedio = Numeros.Average();
                Maximo = Numeros.Max();
                Minimo = Numeros.Min();
            }
            else
            {
                Suma = 0;
                Promedio = 0;
                Maximo = 0;
                Minimo = 0;
            }
        }

        public void LimpiarTodo()
        {
            Numeros.Clear();
            Numero = 0;
            Suma = 0;
            Promedio = 0;
            Maximo = 0;
            Minimo = 0;
            TieneNumeros = false;
        }
    }
}