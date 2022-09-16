using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaTransporte.Modelo
{
    public abstract class Transporte
    {
        public int Pasajeros { get; set; }

        public Transporte(int pasajeros)
        {
            Pasajeros = pasajeros;
        }

        public abstract void Avansar();
        public abstract void Detenerse();
    }
}
