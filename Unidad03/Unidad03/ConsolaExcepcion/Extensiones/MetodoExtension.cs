using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoExcepciones
{
    public static class MetodoExtension
    {
        public static int DivisionPorCero(this int a)
        {
            return a / 0;
        }
        public static double DivisionRacional(this double a, double b)
        {
            return a / b;
        }
    }
}
