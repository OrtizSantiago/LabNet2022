using ProyectoExcepciones.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoExcepciones
{
    internal class Program
    {

        static void Main(string[] args)
        {
            void SeparandoEjercicios()
            {
                Console.WriteLine("\nPerfecto! Presione una tecla para poder continuar.");
                Console.ReadKey(true);
                Console.Clear();
            }

            Console.WriteLine("\nEjercicio 1: \nPor favor... ¡Delire! niegue las matemáticas por un instante e ingrese un valor para realizar una division por cero:");
            try
            {
                int n = int.Parse(Console.ReadLine());
                n.DivisionPorCero();
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("\nTerminó de realizarse la operación.");
            }

            SeparandoEjercicios();
            Console.WriteLine("\nMuy Bien! \n Ejercicio 2: Ahora...ingrese dos valores que desee dividir!");
            try
            {
                Console.WriteLine("\nIngrese dividendo:");
                string a = Console.ReadLine();
                if (a == "")
                {
                    throw new IngresoVacioExcepcion();
                }
                Console.WriteLine("Continue ingresando el divisor:");
                string b = Console.ReadLine();
                if (b == "")
                {
                    throw new IngresoVacioExcepcion();
                }
                double n = Convert.ToDouble(a);
                double m = Convert.ToDouble(b);
                double result = n.DivisionRacional(m);
                Console.WriteLine("\nEl cociente de su operación es: " + result);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Solo Chuck Norris divide por cero!");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Te tomaste en serio en el método anterior negar las matemáticas xD \nDale, mandale un númerito!");
            }
            //Mi Excepcion
            catch (IngresoVacioExcepcion ex)
            {
                Console.WriteLine(ex.Message);
            }

            SeparandoEjercicios();
            Console.WriteLine("Ahora... realizaremos una division publica y no estatica por medio de una instancia:");

            //Instancia clase logic, metodo publico no estático
            Logic logic = new Logic();

            try
            {
                Console.WriteLine("\nIngrese dividendo:");
                double a = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Continue ingresando el divisor:");
                double b = Convert.ToDouble(Console.ReadLine());
                double result = logic.División(a, b);
                Console.WriteLine("\nEl cociente de su operación es: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            SeparandoEjercicios();
            Console.WriteLine("Ejercicio 3: Excepcion lanzada desde clase Logic:\n");

            try
            {
                logic.ExcepcionLanzada();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
            finally
            {
                Console.WriteLine("\nTerminó de realizarse la operación.");
            }
            Console.ReadKey(true);
        }

    }
}
