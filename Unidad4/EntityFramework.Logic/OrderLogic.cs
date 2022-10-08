using EntityFramework.Entities;
using EntityFramework.Logic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Logic
{
    public class OrderLogic : BaseLogic, IOperation<Orders>
    {
        
        public List<Orders> GetAll()
        {
            return context.Orders.ToList();
        }

        public void Insert(Orders entidad)
        {
            context.Orders.Add(entidad);
            context.SaveChanges();
        }

        public void Update(Orders entidad)
        {
            var orderUpdate = context.Orders.Find(entidad.OrderID);
            orderUpdate.ShipName = entidad.ShipName;
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            var orderDelete = context.Orders.Find(Id);
            context.Orders.Remove(orderDelete);
            context.SaveChanges();
        }

        public Orders GetId(int Id)
        {
            return context.Orders.Where(e => e.OrderID == Id).FirstOrDefault();
        }
    }
}
