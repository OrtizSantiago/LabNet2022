using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaTransporte.Interfaces
{
    public interface IOperaciones<T> where T : class
    {
        void Agregar(T entidad);
        string Mostrar();
    }




}
