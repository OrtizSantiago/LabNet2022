using LabNet.Linq.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNet.Linq.Logic
{
    public class CustomerLogic : BaseLogic
    {
        public IEnumerable<Customers> CustomerId(string n)
        {
            var customers = context.Customers.ToList();
            var result = from customer in customers
                       where customer.CustomerID == n
                       select customer;
            return result;
        }

        public IEnumerable<Customers> CustomerRegionWA()
        {
            var result = context.Customers.Where(c => c.Region == "WA").ToList();
            return result;
        }

        public IEnumerable<String> CustomersName()
        {
            var customers = context.Customers.ToList();
            var result = from customer in customers
                         select customer.ContactName;
            return result;
        }

        public IEnumerable<Customers> CustomersRegioWAandGreaterthan1_1_1997()
        {
            DateTime fecha = new DateTime(1997, 1, 1, 0, 0, 0);
            var result = from orders in context.Orders
                         join customer in context.Customers
                         on orders.CustomerID equals customer.CustomerID
                         where customer.Region == "WA" && orders.OrderDate > fecha
                         select customer;

            return result;
        }

        public IEnumerable<Customers> Customers3RegioWA()
        {
            var result = context.Customers.Where(c => c.Region == "WA").ToList();
            return result;
        }

        public IEnumerable<CustomersCount> CustomersWithOrders()
        {
            var result = (from customer in context.Customers
                         join order in context.Orders
                         on customer.CustomerID equals order.CustomerID
                         select new CustomersCount
                         {
                             CustomerID = customer.CustomerID,
                             CustomerName = customer.CompanyName,
                             CountOrders = customer.Orders.Count()
                         }).Distinct();
            return result;
        }

    }

    public class CustomersCount
    { 
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }   
        public int CountOrders { get; set; }

    }
}
