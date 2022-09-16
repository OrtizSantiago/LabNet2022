using ConsolaTransporte.Logica;
using ConsolaTransporte.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaTransporte
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Comun comun = new Comun();
            void Menu()
            {
                string opcion = "";

                Console.WriteLine("***** Menú principal ***** \n" +
                       "\n 1. Agregar los 10 Transportes" +
                       "\n 2. Mostrar los 10 Transportes" +
                       "\n 3. Salir \n" +
                       "\n Elige tu opción:");
                opcion = Console.ReadLine();
                if (opcion != null)
                {
                    switch (opcion)
                    {
                        case "1":
                            Console.Clear();
                            comun.AgregarTransportes();
                            Console.WriteLine("");
                            Menu();
                            break;

                        case "2":
                            Console.Clear();
                            comun.MostrarTransportes();
                            Menu();
                            break;

                        case "3":
                            Console.Clear();
                            Console.WriteLine("Gracias por tu tiempo. Programa terminado.");
                            Console.ReadKey(true);
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("Por favor, selecciona una opción correcta. Intente nuevamente:\n ");
                            Menu();
                            break;
                    }
                }
            }

            Menu();
        }
    }
}
