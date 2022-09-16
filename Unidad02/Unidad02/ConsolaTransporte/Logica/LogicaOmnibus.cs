using ConsolaTransporte.Interfaces;
using ConsolaTransporte.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaTransporte.Logica
{
    public class LogicaOmnibus : IOperaciones<Omnibus>
    {
        public List<Omnibus> ListaOmbibus = new List<Omnibus>();
        public void Agregar(Omnibus entidad)
        {
            if (entidad != null)
            {
                ListaOmbibus.Add(entidad);
            }
        }

        public string Mostrar()
        {
            string text = "Lista de Ómnibus \n";
            int n = 1;
            foreach (Omnibus i in ListaOmbibus)
            {
                text += "Ómnibus #" + n + ": " + i.Pasajeros + " pasajeros. \n";
                n++;
            }
            return text;
        }
    }
}
