using EXUI_Leyva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EXUI_Leyva.Controllers
{
    public class SumaController : Controller
    {
        ClsSuma objSuma = new ClsSuma();

        public ActionResult Index()
        {
            return View(objSuma);
        }

        [HttpPost]
        public ActionResult Index(int? numero)
        {
            if (numero == null)
            {
                ViewBag.Mensaje = "Por favor ingrese un número";
                ViewBag.ClaseMensaje = "alert-danger";
                return View(objSuma);
            }

            string resultado = objSuma.CalcularFormas(numero.Value);

            if (resultado == "success")
            {
                ViewBag.Mensaje = $"Se encontraron {objSuma.TotalFormas} formas de representar el número {numero}";
                ViewBag.ClaseMensaje = "alert-success";
            }
            else
            {
                ViewBag.Mensaje = resultado;
                ViewBag.ClaseMensaje = "alert-danger";
            }

            return View(objSuma);
        }
    }
}