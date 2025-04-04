using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DCliente
    {
        public String Registrar(Cliente cliente)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Cliente.Add(cliente);
                    context.SaveChanges();
                }
                return "Registrado exitosamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public String Modificar(Cliente cliente)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    Cliente clienteTemp = context.Cliente.Find(cliente.ClienteID);
                    clienteTemp.Dni = cliente.Dni;
                    clienteTemp.Nombre = cliente.Nombre;
                    clienteTemp.Apellido = cliente.Apellido;
                    clienteTemp.Direccion = cliente.Direccion;
                    clienteTemp.Telefono = cliente.Telefono;
                    clienteTemp.Tipo_Cliente = cliente.Tipo_Cliente;
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
                    Cliente clienteTemp = context.Cliente.Find(id);
                    context.Cliente.Remove(clienteTemp);
                    context.SaveChanges();
                }
                return "Eliminado exitosamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Cliente> ListarTodo()
        {
            List<Cliente> clientes = new List<Cliente>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    clientes = context.Cliente.ToList();
                }
                return clientes;
            }
            catch (Exception ex)
            {
                return clientes;
            }
        }
       
    }
}
