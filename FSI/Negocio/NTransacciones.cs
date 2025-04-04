using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class NTransacciones
    {
        private DTransacciones dTransacciones = new DTransacciones();
        private DCuenta dCuenta = new DCuenta();
        public String Registrar(Transacciones transaccion)
        {
           
            return dTransacciones.Registrar(transaccion);
        }
        public void Actualizar(Transacciones transaccion)
        {
             decimal _monto=transaccion.Monto;
             int _id =transaccion.CuentaID;
            switch (transaccion.Tipo_Transaccion)
            {
                case "Retiro": dCuenta.Actualizar_Retiro(_monto, _id); ; break;
                case "Deposito": dCuenta.Actualizar_Deposito(_monto, _id); ; break;
            }
        }

        public String Modificar(Transacciones transaccion)
        {
            return dTransacciones.Modificar(transaccion);
        }

        public String Eliminar(int id)
        {
            return dTransacciones.Eliminar(id);
        }

        public List<Transacciones> ListarTodo()
        {
            return dTransacciones.ListarTodo();
        }


    }
}
