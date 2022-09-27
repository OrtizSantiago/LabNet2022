using EntityFramework.Data;
using EntityFramework.Logic.Interface;
using EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Logic
{
    public class EmployeeLogic : BaseLogic, IOperation<Employees>
    {

        public List<Employees> GetAll()
        {
            return context.Employees.ToList();
        }
        public Employees GetId(int n)
        {
            return context.Employees.Where(e => e.EmployeeID == n).First();
        }

        public void Insert(Employees entidad)
        {
            context.Employees.Add(entidad);
            context.SaveChanges();     
        }

        public void Update(Employees entidad)
        {
            var employeeUpdate = context.Employees.Find(entidad.EmployeeID);
            employeeUpdate.FirstName = entidad.FirstName;
            employeeUpdate.LastName = entidad.LastName;
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            var employeeDelete = context.Employees.Find(Id);
            context.Employees.Remove(employeeDelete);
            context.SaveChanges(); 
        }
    }
}
