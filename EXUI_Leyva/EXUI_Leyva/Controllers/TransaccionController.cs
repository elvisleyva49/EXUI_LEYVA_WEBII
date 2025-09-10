using EXUI_Leyva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EXUI_Leyva.Controllers
{
    public class TransaccionController : Controller
    {
        public ActionResult Index()
        {
            ClsTransaccion objTransaccion = new ClsTransaccion();

            // Recuperar datos de la sesión si existen
            if (Session["Transaccion"] != null)
            {
                objTransaccion = (ClsTransaccion)Session["Transaccion"];
            }
            else
            {
                // Guardar en sesión la primera vez
                Session["Transaccion"] = objTransaccion;
            }

            return View(objTransaccion);
        }

        [HttpPost]
        public ActionResult Depositar(decimal? monto)
        {
            ClsTransaccion objTransaccion = (ClsTransaccion)Session["Transaccion"];

            if (monto == null || monto <= 0)
            {
                ViewBag.Mensaje = "Por favor ingrese un monto válido";
                ViewBag.ClaseMensaje = "alert-danger";
                return View("Index", objTransaccion);
            }

            string resultado = objTransaccion.RealizarDeposito(monto.Value);

            if (resultado == "success")
            {
                ViewBag.Mensaje = $"Depósito de S/ {monto:F2} realizado exitosamente";
                ViewBag.ClaseMensaje = "alert-success";
                // Actualizar en sesión
                Session["Transaccion"] = objTransaccion;
            }
            else
            {
                ViewBag.Mensaje = resultado;
                ViewBag.ClaseMensaje = "alert-danger";
            }

            return View("Index", objTransaccion);
        }

        [HttpPost]
        public ActionResult Retirar(decimal? monto)
        {
            ClsTransaccion objTransaccion = (ClsTransaccion)Session["Transaccion"];

            if (monto == null || monto <= 0)
            {
                ViewBag.Mensaje = "Por favor ingrese un monto válido";
                ViewBag.ClaseMensaje = "alert-danger";
                return View("Index", objTransaccion);
            }

            string resultado = objTransaccion.RealizarRetiro(monto.Value);

            if (resultado == "success")
            {
                ViewBag.Mensaje = $"Retiro de S/ {monto:F2} realizado exitosamente";
                ViewBag.ClaseMensaje = "alert-success";
                // Actualizar en sesión
                Session["Transaccion"] = objTransaccion;
            }
            else
            {
                ViewBag.Mensaje = resultado;
                ViewBag.ClaseMensaje = "alert-danger";
            }

            return View("Index", objTransaccion);
        }

        public ActionResult Reiniciar()
        {
            // Limpiar la sesión y crear nueva instancia
            Session["Transaccion"] = new ClsTransaccion();
            ViewBag.Mensaje = "Sesión reiniciada exitosamente";
            ViewBag.ClaseMensaje = "alert-info";

            return RedirectToAction("Index");
        }
    }
}