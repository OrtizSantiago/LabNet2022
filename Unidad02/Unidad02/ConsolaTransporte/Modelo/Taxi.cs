using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaTransporte.Modelo
{
    public class Taxi : Transporte
    {
        public Taxi(int pasajeros) : base(pasajeros)
        {
        }

        public override void Avansar()
        {
            Console.WriteLine("El Taxi está avanzando.");
        }

        public override void Detenerse()
        {
            Console.WriteLine("El Taxi se detuvo.");
        }
    }
}
