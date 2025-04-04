using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
namespace Negocio
{
    public class NEmpleado
    {
        private DEmpleado dEmpleado = new DEmpleado();

        public String Registrar(Empleado empleado)
        {
            return dEmpleado.Registrar(empleado);
        }

        public String Modificar(Empleado empleado)
        {
            return dEmpleado.Modificar(empleado);
        }

        public String Eliminar(int id)
        {
            return dEmpleado.Eliminar(id);
        }

        public List<Empleado> ListarTodo()
        {
            return dEmpleado.ListarTodo();
        }


    }
}
