using Examen1.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Examen1.Controllers
{
    public class HomeController : Controller
    {

        //declaramos nuestra lista del ejemplo
        static int[] categories = { 1, 3, 5, 73, 4, 6, 87, 4 };
        //la inicializamos como dice el ejercio con los valores 
         Ordenamiento Orden = new Ordenamiento(categories);

        //nuestra pagina de inicio
        public ActionResult Index()
        {
            return View();
        }

        //lista que devuleve los valores inversos
        public JsonResult ListaInversa()
        {
            return Json(categories.Reverse());
        }

        //Eliminamos la lista el numero digitado
        public JsonResult EliminarEnLista(int numero)
        {
            var resul = Orden.ListaNumeros.RemoveAll(x => x == numero);
            return Json(Orden.ListaNumeros);
        }

        //encontramos los pares e imprimimos el mayor impar
        public JsonResult Pares()
        {
            List<int> Pares = new List<int>();
            int impar = 0;

            foreach (var item in Orden.ListaNumeros)
            {
                if (item % 2 == 0)
                {
                    Pares.Add(item);
                }
                else
                {
                    if(item > impar) { impar = item; }
                }
            }
            //return Json(Pares , impar);
            return Json(new { resultado = Pares, mayor = impar });

        }
        
        //eliminamos el mayor de la lista
        public JsonResult EliminarMayor()
        {
            int mayor = 0;
            foreach (var item in Orden.ListaNumeros)
            {
                if(item > mayor) { mayor = item;}
            }

            Orden.ListaNumeros.RemoveAll(x => x == mayor);

            return Json(this.Orden.ListaNumeros, JsonRequestBehavior.AllowGet);
        }

        //agregamos un numero en la pos 1 de la lista
        public JsonResult AgregarNumero(int numero)
        {
            //agregamos el numero en la primera posicion
            this.Orden.ListaNumeros.Insert(0, numero);

            return Json(this.Orden.ListaNumeros, JsonRequestBehavior.AllowGet);
        }

        //obtenermos toda la lista
        public JsonResult ObtenerLista()
        {
            return Json(Orden.ListaNumeros.ToList(), JsonRequestBehavior.AllowGet);
        }

    }
}