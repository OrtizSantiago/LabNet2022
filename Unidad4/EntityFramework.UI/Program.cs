using EntityFramework.Entities;
using EntityFramework.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Common common = new Common();
            void Menu()
            {
                string opcion = "";

                Console.WriteLine("***** Menú principal ***** \n" +
                       "\n 1. Mostrar empleados" +
                       "\n 2. Agregar empleado" +
                       "\n 3. Modificar empleado" +
                       "\n 4. Eliminar empleado" +
                       "\n 5. Consulta básica a Orders" +
                       "\n 6. Salir \n" +
                       "\n Elige tu opción:");
                opcion = Console.ReadLine();
                if (opcion != null)
                {
                    switch (opcion)
                    {
                        case "1":
                            Console.Clear();
                            common.GetAllEmployee();
                            Console.WriteLine("");
                            Menu();
                            break;

                        case "2":
                            Console.Clear();
                            common.AddEmployee();
                            Console.WriteLine("");
                            Menu();
                            break;

                        case "3":
                            Console.Clear();
                            common.UpdateEmployee();
                            Console.WriteLine("");
                            Menu();
                            break;

                        case "4":
                            Console.Clear();
                            common.GetAllEmployee();
                            Console.WriteLine("");    
                            common.DeleteEmployee();
                            Console.WriteLine("");
                            common.GetAllEmployee();
                            Console.WriteLine("");
                            Menu();
                            break;

                        case "5":
                            Console.Clear();
                            common.GetAllOrders();
                            Console.WriteLine("");
                            Menu();
                            break;

                        case "6":
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
