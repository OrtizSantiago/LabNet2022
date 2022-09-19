using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoExcepciones.Excepciones
{
    public class IngresoVacioExcepcion : Exception
    {
        public IngresoVacioExcepcion() : base("Ingreso un no valor. Ingreso vacio.")
        {
            Console.WriteLine("Mensaje de mi excepción");
        }
    }
}
