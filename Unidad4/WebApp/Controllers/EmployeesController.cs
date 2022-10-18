using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WebApp.Models;
using WebApp.Models.ViewModel;

namespace WebApp.Controllers
{
    [EnableCors(origins: "*", headers:"*", methods:"GET,POST,PUT,DELETE,OPTIONS")]
    public class EmployeesController : ApiController
    {
        private Northwind db = new Northwind();

        // GET: api/Employees
        public IEnumerable<EmployeeView> GetEmployees()
        {
            List<Employees> employees = db.Employees.ToList();
            List<EmployeeView> employeesView = employees.Select(e => new EmployeeView
            {
                EmployeeId = e.EmployeeID,
                Name = e.FirstName,
                LastName = e.LastName,
                Title = e.Title
            }).ToList();
            
            return employeesView;
        }

        // GET: api/Employees/5
        [ResponseType(typeof(Employees))]
        public IHttpActionResult GetEmployeeId(int id)
        {
            Employees employees = db.Employees.Find(id);
            EmployeeView employeeView = new EmployeeView()
            {
                EmployeeId = employees.EmployeeID,
                Name = employees.FirstName,
                LastName = employees.LastName,
                Title = employees.Title
            };
            if (employeeView == null)
            {
                return NotFound();
            }

            return Ok(employeeView);
        }

        // PUT: api/Employees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployees(int id, EmployeeView employeesView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employeesView.EmployeeId)
            {
                return BadRequest();
            }

            Employees employees = new Employees();
            employees.EmployeeID = id;
            employees.FirstName = employeesView.Name;
            employees.LastName = employeesView.LastName;
            employees.Title= employeesView.Title;

            db.Entry(employees).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Employees
        [ResponseType(typeof(Employees))]
        public IHttpActionResult PostEmployees(EmployeeView employeeView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Employees employees = new Employees()
            {
                EmployeeID = employeeView.EmployeeId,
                FirstName = employeeView.Name,
                LastName = employeeView.LastName,
                Title = employeeView.Title
            };
            db.Employees.Add(employees);
            db.SaveChanges();

            return Ok();
        }

        // DELETE: api/Employees/5
        [ResponseType(typeof(Employees))]
        public IHttpActionResult DeleteEmployees(int id)
        {
            Employees employees = db.Employees.Find(id);
            if (employees == null)
            {
                return NotFound();
            }

            db.Employees.Remove(employees);
            db.SaveChanges();

            return Ok(employees);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeesExists(int id)
        {
            return db.Employees.Count(e => e.EmployeeID == id) > 0;
        }
    }
}