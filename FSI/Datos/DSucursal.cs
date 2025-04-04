using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DSucursal
    {
        public List<Sucursal> ListarTodo()
        {
            List<Sucursal> sucursal = new List<Sucursal>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    sucursal = context.Sucursal.ToList();
                }
                return sucursal;
            }
            catch (Exception ex)
            {
                return sucursal;
            }
        }

    }
}
