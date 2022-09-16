using ConsolaTransporte.Modelo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaTransporte.Logica
{
    public class Comun
    {
        LogicaOmnibus omnibus = new LogicaOmnibus();
        LogicaTaxi taxi = new LogicaTaxi();

        public void AgregarTransportes()
        {
            int cant_pasajeros = 0;

            Console.WriteLine("Genial! Comencemos con los Ómnibus... \n");
            for (int i = 1; i < 6; i++)
            {
                Console.WriteLine("Escriba la cantidad de pasajeros del Ómnibus #" + i + " :");
                cant_pasajeros = int.Parse(Console.ReadLine());
                if (cant_pasajeros != 0)
                {
                    omnibus.Agregar(new Omnibus(cant_pasajeros));
                }
            }
            Console.Clear();
            Console.WriteLine("Ahora, continuemos con los Taxis... \n");
            for (int i = 1; i < 6; i++)
            {
                Console.WriteLine("Escriba la cantidad de pasajeros del Taxi #" + i + " :");
                cant_pasajeros = int.Parse(Console.ReadLine());
                if (cant_pasajeros != 0)
                {
                    taxi.Agregar(new Taxi(cant_pasajeros));
                }
            }
        }


        public void MostrarTransportes()
        {
            Console.WriteLine(omnibus.Mostrar() + " \n" + taxi.Mostrar());
        }

    }
}
