using ConsolaTransporte.Interfaces;
using ConsolaTransporte.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaTransporte.Logica
{
    public class LogicaTaxi : IOperaciones<Taxi>
    {
        List<Taxi> ListaTaxi = new List<Taxi>();
        public void Agregar(Taxi entidad)
        {
            if (entidad != null)
            {
                ListaTaxi.Add(entidad);
            }
        }

        public string Mostrar()
        {
            string text = "Lista de Taxis \n";
            int n = 1;
            foreach (Taxi i in ListaTaxi)
            {
                text += "Taxi #" + n + ": " + i.Pasajeros + " pasajeros. \n";
                n++;
            }
            return text;
        }
    }
}
