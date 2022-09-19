using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoExcepciones
{
    public class Logic
    {
        public void ExcepcionLanzada()
        {
            throw new ArgumentNullException();
        }

        public double División(double a, double b)
        {
            return a / b;
        }
    }
}
