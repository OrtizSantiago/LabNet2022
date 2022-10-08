using EntityFramework.Entities;
using EntityFramework.Logic;
using EntityFramework.MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFramework.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeLogic logic = new EmployeeLogic();

        // GET: Employee
        public ActionResult Index()
        {
            List<Employees> regiones = logic.GetAll();
            List<EmployeeView> employeeViews = regiones.Select(s => new EmployeeView
            {
                EmployeeId = s.EmployeeID,
                Name = s.FirstName,
                LastName = s.LastName
            }).ToList();
            return View(employeeViews);
        }


        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(EmployeeView employeeView)
        {
            try
            {
                Employees employee = new Employees
                {
                    FirstName = employeeView.Name,
                    LastName = employeeView.LastName
                };

                logic.Insert(employee);

                return RedirectToAction("Index");
            }
       
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
           
        }

        public ActionResult Update(int Id)
        {
            var employee = logic.GetId(Id);
            EmployeeView employeeView = new EmployeeView
            {
                EmployeeId = employee.EmployeeID,
                Name = employee.FirstName,
                LastName = employee.LastName
            };

            return View(employeeView);
        }

        [HttpPost]
        public ActionResult Update(int Id, EmployeeView employeeView)
        {
            try
            {
                var emp = logic.GetId(Id);
                if (emp.EmployeeID == Id)
                {
                    Employees employee = new Employees
                    {
                        EmployeeID = Id,
                        FirstName = employeeView.Name,
                        LastName = employeeView.LastName
                    };

                    logic.Update(employee);
                }

                return RedirectToAction("Index");
            }
            catch (DbEntityValidationException)
            {
                return RedirectToAction("Null", "Error");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }

        }



        // DELETE: Employee
        public ActionResult Delete (int Id)
        {
            try
            {
                logic.Delete(Id);

                return RedirectToAction("Index");
            }
            catch (DbUpdateException)
            {
                return RedirectToAction("Asociados", "Error");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }

        }
    }
}