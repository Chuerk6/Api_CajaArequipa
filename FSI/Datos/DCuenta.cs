using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DCuenta
    {
        public String Registrar(Cuenta cuenta)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Cuenta.Add(cuenta);
                    context.SaveChanges();
                }
                return "Registrado exitosamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public String Modificar(Cuenta cuenta)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    Cuenta cuentaTemp = context.Cuenta.Find(cuenta.CuentaID);
                    cuentaTemp.Saldo = cuenta.Saldo;
                    cuentaTemp.FechaApertura = cuenta.FechaApertura;
                    cuentaTemp.Tipo_Cuenta = cuenta.Tipo_Cuenta;
                    context.SaveChanges();
                }
                return "Modificado exitosamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public void Actualizar_Retiro(decimal _Monto, int id )
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    Cuenta cuentaTemp = context.Cuenta.Find(id);
                    cuentaTemp.Saldo = cuentaTemp.Saldo - _Monto;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
            }
        }
        public void Actualizar_Transferencia(int cuentaid1, int cuentaid2, decimal monto)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    Cuenta cuentaTemp1 = context.Cuenta.Find(cuentaid1);
                    cuentaTemp1.Saldo = cuentaTemp1.Saldo - monto;
                    context.SaveChanges();

                    Cuenta cuentaTemp2 = context.Cuenta.Find(cuentaid2);
                    cuentaTemp2.Saldo = cuentaTemp2.Saldo + monto;
                    context.SaveChanges();

                }
            }
            catch (Exception ex)
            {
            }
        }
        public void Actualizar_Deposito(decimal _Monto, int id)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    Cuenta cuentaTemp = context.Cuenta.Find(id);
                    cuentaTemp.Saldo = cuentaTemp.Saldo + _Monto;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
            }
        }
        public String Eliminar(int id)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    Cuenta cuentaTemp = context.Cuenta.Find(id);
                    context.Cuenta.Remove(cuentaTemp);
                    context.SaveChanges();
                }
                return "Eliminado exitosamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Cuenta> ListarTodo()
        {
            List<Cuenta> cuentas = new List<Cuenta>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    cuentas = context.Cuenta.ToList();
                }
                return cuentas;
            }
            catch (Exception ex)
            {
                return cuentas;
            }
        }

        public List<Cuenta> FiltrarCliente(int id)
        {
            List<Cuenta> cuentas = new List<Cuenta>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    cuentas = context.Cuenta.Where(d => d.ClienteID.Equals(id)).ToList();
                }
                return cuentas;
            }
            catch (Exception ex)
            {
                return cuentas;
            }
        }

    }
}
