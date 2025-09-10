using EXUI_Leyva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EXUI_Leyva.Controllers
{
    public class LoginController : Controller
    {

        ClsLogin objLogin = new ClsLogin();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string usuario, string clave)
        {
            string resultado = objLogin.Validar(usuario, clave);

            if (resultado == "Acceso Exitoso")
            {
                ViewBag.Mensaje = "Acceso exitoso";
            }
            else
            {
                ViewBag.Mensaje = resultado;
                return View();
            }

            return View();
        }
    }
}