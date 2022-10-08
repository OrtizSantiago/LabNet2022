using EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EntityFramework.Logic
{
    public class Common
    {
        EmployeeLogic empLogic = new EmployeeLogic();
        OrderLogic orderLogic = new OrderLogic();

        public bool WithRegEx(string stringToVerify)
        {
            return Regex.IsMatch(stringToVerify, @"^[a-zA-Z]+$");
        }
        public void GetAllEmployee()
        {
            Console.WriteLine("Lista de empleados por Id, Nombre y Apellido:\n");
            foreach (Employees i in empLogic.GetAll())
            {
                Console.WriteLine($"{i.EmployeeID} - {i.FirstName} {i.LastName}");
            }

        }
        public void GetAllOrders()
        {
            Console.WriteLine("Lista de orders por Id, Nombre y Dirección:\n");
            foreach (Orders i in orderLogic.GetAll())
            {
                Console.WriteLine($"{i.OrderID} - {i.ShipName} | {i.ShipAddress}");
            }

        }

        public void AddEmployee()
        {
            try
            {
                Console.WriteLine("Agregue nombre del nuevo empleado:");
                var name = Console.ReadLine();
                bool vn = WithRegEx(name);
                Console.WriteLine("Agregue apellido del nuevo empleado:");
                var lastName = Console.ReadLine();
                bool vln = WithRegEx(lastName);
                //name != null && lastName != null
                if (vn && vln)
                {
                    empLogic.Insert(new Employees
                    {
                        FirstName = name,
                        LastName = lastName
                    });

                    Console.WriteLine("Empleado agregado.");
                }
                else
                {
                    Console.WriteLine("Datos incorrectos");
                }
            }
            catch (DbEntityValidationException)
            {
                Console.WriteLine("No ingresaste valor correcto obligatorio.");
            }
            catch (Exception)
            {
                Console.WriteLine("Ha ocurrido un error, por favor, intente nuevamente.");
            }

        }

        public void UpdateEmployee()
        {
            try
            {
                Console.WriteLine("Ingrese Id de empleado que desea cambiar:");
                var n = int.Parse(Console.ReadLine());

                var dbEmployee = empLogic.GetId(n).EmployeeID;
            
                Console.WriteLine("Ingrese Nombre que desea cambiar:");
                var name = Console.ReadLine();
                bool vn = WithRegEx(name);
                Console.WriteLine("Ingrese Apellido que desea cambiar:"); 
                var lastName = Console.ReadLine();
                bool vln = WithRegEx(lastName);

                //name != "" && lastName != ""
                if ((n == dbEmployee) && (vn)&&(vln))
                {
                    empLogic.Update(new Employees
                    {
                        EmployeeID = n,
                        FirstName = name,
                        LastName = lastName
                    });
                    Console.WriteLine("Empleado modificado.");
                }
                else
                {
                    throw new Exception();                    
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("El empleado que desea modificar no existe en la base de datos.");
            }
            catch (Exception )
            {
                Console.WriteLine("Ha ocurrido un error, por favor ingrese datos correctos.");
            }
           
        }

        public void DeleteEmployee()
        {
            try
            {
                Console.WriteLine("Ingrese Id de empleado que desea eliminar:");
                var n = int.Parse(Console.ReadLine());

                if (n != 0)
                {
                    empLogic.Delete(n);
                }
                
                Console.WriteLine("Empleado eliminado.");
            }
            catch (FormatException)
            {
                Console.WriteLine("El valor ingresado no es un número.");
            }
            catch (ArgumentNullException) 
            {
                Console.WriteLine("El empleado que desea eliminar no existe en la base de datos.");
            }
            catch (DbUpdateException)
            {
                Console.WriteLine("El empleado que desea eliminar presenta información relacionada.");
            }
        }

    }
}
