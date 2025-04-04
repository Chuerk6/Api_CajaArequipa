using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class NSucursal
    {
        private DSucursal dSucursal = new DSucursal();


        public List<Sucursal> ListarTodo()
        {
            return dSucursal.ListarTodo();
        }


    }
}
