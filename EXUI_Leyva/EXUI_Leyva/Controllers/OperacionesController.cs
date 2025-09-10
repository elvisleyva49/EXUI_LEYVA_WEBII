using EXUI_Leyva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EXUI_Leyva.Controllers
{
    public class OperacionesController : Controller
    {
        private static ClsOperaciones objOperaciones = new ClsOperaciones();

        public ActionResult Index()
        {
            return View(objOperaciones);
        }

        [HttpPost]
        public ActionResult Agregar(int? numero)
        {
            if (numero == null)
            {
                ViewBag.Mensaje = "Por favor ingrese un número válido";
                ViewBag.ClaseMensaje = "alert-danger";
                return View("Index", objOperaciones);
            }

            string resultado = objOperaciones.AgregarNumero(numero.Value);

            if (resultado == "success")
            {
                ViewBag.Mensaje = $"Número {numero} agregado correctamente";
                ViewBag.ClaseMensaje = "alert-success";
                objOperaciones.Numero = 0; // Limpiar el campo después de agregar
            }
            else
            {
                ViewBag.Mensaje = resultado;
                ViewBag.ClaseMensaje = "alert-danger";
            }

            return View("Index", objOperaciones);
        }

        [HttpPost]
        public ActionResult Limpiar()
        {
            objOperaciones.Numero = 0;
            ViewBag.Mensaje = "Campo limpiado";
            ViewBag.ClaseMensaje = "alert-info";
            return View("Index", objOperaciones);
        }

        [HttpPost]
        public ActionResult Calcular()
        {
            if (objOperaciones.Numeros.Count == 0)
            {
                ViewBag.Mensaje = "No hay números para calcular";
                ViewBag.ClaseMensaje = "alert-warning";
                return View("Index", objOperaciones);
            }

            objOperaciones.CalcularOperaciones();
            ViewBag.Mensaje = "Operaciones calculadas correctamente";
            ViewBag.ClaseMensaje = "alert-success";
            return View("Index", objOperaciones);
        }

        [HttpPost]
        public ActionResult Salir()
        {
            objOperaciones.LimpiarTodo();
            ViewBag.Mensaje = "Sistema reiniciado correctamente";
            ViewBag.ClaseMensaje = "alert-info";
            return View("Index", objOperaciones);
        }
    }
}