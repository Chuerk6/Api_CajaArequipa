using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
namespace Negocio
{
    public class NCuenta
    {
        private DCuenta dCuenta = new DCuenta();

        public String Registrar(Cuenta cuenta)
        {
            return dCuenta.Registrar(cuenta);
        }

        public String Modificar(Cuenta cuenta)
        {
            return dCuenta.Modificar(cuenta);
        }
        public void Actualizar_Transferencia(int cuentaid1, int cuentaid2, decimal monto)
        {
           dCuenta.Actualizar_Transferencia(cuentaid1, cuentaid2, monto);
        }
        
        public String Eliminar(int id)
        {
            return dCuenta.Eliminar(id);
        }

        public List<Cuenta> ListarTodo()
        {
            return dCuenta.ListarTodo();
        }

        public List<Cuenta> FiltrarCliente(int id)
        {
            return dCuenta.FiltrarCliente(id);
        }
    }
}
