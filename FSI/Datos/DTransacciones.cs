using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DTransacciones
    {
        public String Registrar(Transacciones transaccion)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Transacciones.Add(transaccion);
                    context.SaveChanges();
                }
                return "Registrado exitosamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public String Modificar(Transacciones transaccion)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    Transacciones transaccionTemp = context.Transacciones.Find(transaccion.TransaccionID);
                    transaccionTemp.Monto = transaccion.Monto;
                    transaccionTemp.Fecha = transaccion.Fecha;
                    transaccionTemp.Tipo_Transaccion = transaccion.Tipo_Transaccion;
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
                    Transacciones transaccionTemp = context.Transacciones.Find(id);
                    context.Transacciones.Remove(transaccionTemp);
                    context.SaveChanges();
                }
                return "Eliminado exitosamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Transacciones> ListarTodo()
        {
            List<Transacciones> transacciones = new List<Transacciones>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    transacciones = context.Transacciones.ToList();
                }
                return transacciones;
            }
            catch (Exception ex)
            {
                return transacciones;
            }
        }

    }
}
