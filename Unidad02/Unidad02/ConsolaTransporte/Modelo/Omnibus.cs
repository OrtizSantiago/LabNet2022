using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaTransporte.Modelo
{
    public class Omnibus : Transporte
    {
        public Omnibus(int pasajeros) : base(pasajeros)
        {
        }

        public override void Avansar()
        {
            Console.WriteLine("El Ómnibus está avanzando.");
        }

        public override void Detenerse()
        {
            Console.WriteLine("El Ómnibus se detuvo.");
        }
    }
}
