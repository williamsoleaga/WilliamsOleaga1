using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen1.Models
{
    public  class Ordenamiento
    {
        //nuestra variable que contrendran los numeros
        public List<int> ListaNumeros { get; set; }

        //constructor en la case con los numeros
      public Ordenamiento(int[] Lista)
        {
            ListaNumeros = new List<int>();

            //agregamos los numeros a nuestra variables asignada
            foreach (var item in Lista)
            {
                ListaNumeros.Add(item);
            }
        }

    }
}