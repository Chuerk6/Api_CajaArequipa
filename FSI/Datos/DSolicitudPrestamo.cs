using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DSolicitudPrestamo
    {
        public String Registrar(SolicitudPrestamo solicitud)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.SolicitudPrestamo.Add(solicitud);
                    context.SaveChanges();
                }
                return "Registrado exitosamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public String Modificar(SolicitudPrestamo solicitud)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    SolicitudPrestamo solicitudTemp = context.SolicitudPrestamo.Find(solicitud.SolicitudID);
                    solicitudTemp.MontoSolicitado = solicitud.MontoSolicitado;
                    solicitudTemp.FechaSolicitud = solicitud.FechaSolicitud;
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
                    SolicitudPrestamo solicitudTemp = context.SolicitudPrestamo.Find(id);
                    context.SolicitudPrestamo.Remove(solicitudTemp);
                    context.SaveChanges();
                }
                return "Eliminado exitosamente";
            }
            catch (Exception ex)
            {
                return "error";
            }
        }

        public List<SolicitudPrestamo> ListarTodo()
        {
            List<SolicitudPrestamo> solicituds = new List<SolicitudPrestamo>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    solicituds = context.SolicitudPrestamo.ToList();
                }
                return solicituds;
            }
            catch (Exception ex)
            {
                return solicituds;
            }
        }

    }
}
