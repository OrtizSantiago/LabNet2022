using LabNet.Linq.Logic;
using LabNet.Linq.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNet.Linq.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductLogic productLogic = new ProductLogic(); 
            CustomerLogic customerLogic = new CustomerLogic();  
            CategoryLogic categoryLogic = new CategoryLogic();  
            void Menu()
            {
                string opcion = "";

                Console.WriteLine("***** Menú principal de Ejercicios Linq ***** \n" +
                       "\n 1. Query para devolver objeto customer." +
                       "\n 2. Query para devolver todos los productos sin stock." +
                       "\n 3. Query para devolver todos los productos que tienen stock y que cuestan más de 3 por unidad." +
                       "\n 4. Query para devolver todos los customers de la Región WA." +
                       "\n 5. Query para devolver el primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789." +
                       "\n 6. Query para devolver los nombre de los Customers. Mostrarlos en Mayuscula y en Minuscula." +
                       "\n 7. Query para devolver Join entre Customers y Orders donde los customers sean de la Región WA y la fecha de orden sea mayor a 1/1/1997." +
                       "\n 8. Query para devolver los primeros 3 Customers de la  Región WA." +
                       "\n 9. Query para devolver lista de productos ordenados por nombre." +
                       "\n 10.Query para devolver lista de productos ordenados por unit in stock de mayor a menor." +
                       "\n 11.Query para devolver las distintas categorías asociadas a los productos." +
                       "\n 12.Query para devolver el primer elemento de una lista de productos." +
                       "\n 13.Query para devolver los customer con la cantidad de ordenes asociadas." +
                       "\n 14.Salir. \n" +
                       "\n Elige tu opción:");
                opcion = Console.ReadLine();
                if (opcion != null)
                {
                    switch (opcion)
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine("Ingrese Id de customer: (Ejemplo = ALFKI)");
                            var customerId = Console.ReadLine().ToUpper();
                            Console.WriteLine($"{customerLogic.CustomerId(customerId).FirstOrDefault().CustomerID} - {customerLogic.CustomerId(customerId).FirstOrDefault().CompanyName}");
                            Console.WriteLine("");
                            Menu();
                            break;

                        case "2":
                            Console.Clear();
                            Console.WriteLine("Lista de Productos Sin Stock:\n");
                            foreach (var i in productLogic.ProductsWithOutStock())
                            {
                                Console.WriteLine($"{i.ProductID} - {i.ProductName}");
                            }
                            Console.WriteLine("");
                            Menu();
                            break;

                        case "3":
                            Console.Clear();
                            Console.WriteLine("Lista de Productos con Stock y Precio por unidad mayor que 3:\n");
                            foreach (var i in productLogic.ProductsWithStockAndCost3())
                            {
                                Console.WriteLine($"{i.ProductID} - {i.ProductName} | precio: ${i.UnitPrice}");
                            }
                            Console.WriteLine("");
                            Menu();
                            break;

                        case "4":
                            Console.Clear();
                            Console.WriteLine("Lista de Customers de la Region WA\n");
                            foreach (var i in customerLogic.CustomerRegionWA())
                            {
                                Console.WriteLine($"{i.CustomerID} - {i.CompanyName}");
                            }
                            Console.WriteLine("");
                            Menu();
                            break;

                        case "5":
                            Console.Clear();
                            productLogic.ProductId789();
                            if (productLogic.ProductId789() == null)
                            {
                                Console.WriteLine("Nulo. No existe producto con ese Id.");
                            }
                            Console.WriteLine("");
                            Menu();
                            break;

                        case "6":
                            Console.Clear();
                            Console.WriteLine("Lista de nombres de los Customers\n");
                            foreach (var i in customerLogic.CustomersName())
                            {
                                Console.WriteLine($"{i.ToUpper()} - {i.ToLower()}");
                            }
                            Console.WriteLine("");
                            Menu();
                            break;

                        case "7":
                            Console.Clear();
                            Console.WriteLine("Lista de Customers de Region WA y mayor que 1/1/1997: \n");
                            foreach (var i in customerLogic.CustomersRegioWAandGreaterthan1_1_1997())
                            {
                                Console.WriteLine($"{i.CustomerID} - {i.CompanyName}");
                            }
                            Console.WriteLine("");
                            Menu();
                            break;

                        case "8":
                            Console.Clear();
                            Console.WriteLine("Lista de Customers de 3 customer de la Region WA: \n");
                            foreach (var i in customerLogic.CustomerRegionWA())
                            {
                                Console.WriteLine($"{i.CustomerID} - {i.CompanyName}");
                            }
                            Console.WriteLine("");
                            Menu();
                            break;

                        case "9":
                            Console.Clear();
                            Console.WriteLine("Lista de Productos ordenados por nombre: \n");
                            foreach (var i in productLogic.ProductsOrderByName())
                            {
                                Console.WriteLine($"{i.ProductID} - {i.ProductName}");
                            }
                            Console.WriteLine("");
                            Menu();
                            break;

                        case "10":
                            Console.Clear();
                            Console.WriteLine("Lista de Productos ordenados Stock: \n");
                            foreach (var i in productLogic.ProductsOrderByStock())
                            {
                                Console.WriteLine($"{i.ProductID} - {i.ProductName} | Stock: {i.UnitsInStock}");
                            }
                            Console.WriteLine("");
                            Menu();
                            break;

                        case "11":
                            Console.Clear();
                            Console.WriteLine("Lista de Categorias por Productos: \n");
                            foreach (var i in categoryLogic.CategoriesByProducts())
                            {
                                Console.WriteLine($"{i.CategoryID} - {i.CategoryName}");
                            }
                            Console.WriteLine("");
                            Menu();
                            break;

                        case "12":
                            Console.Clear();
                            Console.WriteLine("Primer elemento de Lista de Productos: \n");
                            Console.WriteLine($"{productLogic.FirstProduct().ProductID} - {productLogic.FirstProduct().ProductName}");
                            Console.WriteLine("");
                            Menu();
                            break;

                        case "13":
                            Console.Clear();
                            Console.WriteLine("Customers con cantidad de ordenes: \n");
                            foreach (var i in customerLogic.CustomersWithOrders())
                            {
                                Console.WriteLine($"{i.CustomerID} - {i.CustomerName} | Cantidad de ordenes: {i.CountOrders}");
                            }
                            Console.WriteLine("");
                            Menu();
                            break;

                        case "14":
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
