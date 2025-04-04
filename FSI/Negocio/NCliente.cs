using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
namespace Negocio
{
    public class NCliente
    {
        private DCliente dCliente = new DCliente();

        public String Registrar(Cliente cliente)
        {
            return dCliente.Registrar(cliente);
        }

        public String Modificar(Cliente cliente)
        {
            return dCliente.Modificar(cliente);
        }

        public String Eliminar(int id)
        {
            return dCliente.Eliminar(id);
        }

        public List<Cliente> ListarTodo()
        {
            return dCliente.ListarTodo();
        }

       
    }
}
