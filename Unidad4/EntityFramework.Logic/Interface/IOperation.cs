using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Logic.Interface
{
    public interface IOperation<T> where T : class
    {
        List<T> GetAll();
        T GetId(int Id);
        void Insert(T entidad);
        void Update(T entidad);
        void Delete(int Id);
    }

}