using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EXUI_Leyva.Models
{
    public class ClsTransaccion
    {
        public string Cliente { get; set; }
        public decimal Saldo { get; set; }
        public decimal Monto { get; set; }
        public List<TransaccionDetalle> Historial { get; set; }

        public ClsTransaccion()
        {
            Cliente = "Elvis Leyva Sardon";
            Saldo = 500;
            Monto = 0;
            Historial = new List<TransaccionDetalle>();
        }

        public string RealizarDeposito(decimal monto)
        {
            if (monto <= 0)
            {
                return "El monto debe ser mayor a 0";
            }

            Saldo += monto;

            // Agregar al historial
            Historial.Add(new TransaccionDetalle
            {
                Tipo = "Depósito",
                Monto = monto,
                SaldoAnterior = Saldo - monto,
                SaldoNuevo = Saldo,
                Fecha = DateTime.Now
            });

            return "success";
        }

        public string RealizarRetiro(decimal monto)
        {
            if (monto <= 0)
            {
                return "El monto debe ser mayor a 0";
            }

            if (monto > Saldo)
            {
                return "Saldo insuficiente para realizar el retiro";
            }

            decimal saldoAnterior = Saldo;
            Saldo -= monto;

            // Agregar al historial
            Historial.Add(new TransaccionDetalle
            {
                Tipo = "Retiro",
                Monto = monto,
                SaldoAnterior = saldoAnterior,
                SaldoNuevo = Saldo,
                Fecha = DateTime.Now
            });

            return "success";
        }
    }

    public class TransaccionDetalle
    {
        public string Tipo { get; set; }
        public decimal Monto { get; set; }
        public decimal SaldoAnterior { get; set; }
        public decimal SaldoNuevo { get; set; }
        public DateTime Fecha { get; set; }
    }
}