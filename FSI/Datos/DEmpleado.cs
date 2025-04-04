using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DEmpleado
    {
        public String Registrar(Empleado empleado)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Empleado.Add(empleado);
                    context.SaveChanges();
                }
                return "Registrado exitosamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public String Modificar(Empleado empleado)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    Empleado empleadoTemp = context.Empleado.Find(empleado.EmpleadoID);
                    empleadoTemp.Nombre = empleado.Nombre;
                    empleadoTemp.Apellido = empleado.Apellido;
                    empleadoTemp.Cargo = empleado.Cargo;
                    context.SaveChanges();
                }
                return "Modificado exitosamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public String Eliminar(int id)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    Empleado empleadoTemp = context.Empleado.Find(id);
                    context.Empleado.Remove(empleadoTemp);
                    context.SaveChanges();
                }
                return "Eliminado exitosamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Empleado> ListarTodo()
        {
            List<Empleado> empleados = new List<Empleado>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    empleados = context.Empleado.ToList();
                }
                return empleados;
            }
            catch (Exception ex)
            {
                return empleados;
            }
        }

    }
}
