using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EXUI_Leyva.Models
{
    public class ClsLogin
    {
        public string Usuario { get; set; }
        public string Clave { get; set; }

        public static string[] usuarios = { "elvis", "lanchipa" };
        public static string[] claves = { "123", "123" };
        public static string[] estados = { "activo", "activo" };

        public static int intentos = 0;

        public string Validar(string usuario, string clave)
        {

            if (usuario == "" || clave == "")
            {
                return "Los campos no deben estar vacios";
            }

            for (int i = 0; i < usuarios.Length; i++)
            {
                if (usuarios[i] == usuario)
                {
                    if (claves[i] == clave)
                    {
                        if (estados[i] == "activo")
                        {
                            intentos = 0;
                            return "Acceso Exitoso";
                        }
                        else
                        {
                            return "Usuario desactivado";
                        }
                    }

                }
            }
            intentos++;
            if (intentos >= 3)
            {
                return "Superaste el límite de 3 intentos";
            }
            else
            {
                return "Clave o usuario incorrecto";
            }
        }

    }
}