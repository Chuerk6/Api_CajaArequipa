using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
namespace Negocio
{
    public class NSolicitudPrestamo
    {
        private DSolicitudPrestamo dSolicitudPrestamo = new DSolicitudPrestamo();

        public String Registrar(SolicitudPrestamo solicitud)
        {
            // Aplicamos un 2% de interes al prestamo
            solicitud.TasaInteres = 0.02m; // 0.02m representa 2%
            return dSolicitudPrestamo.Registrar(solicitud);
        }
         
        public String Modificar(SolicitudPrestamo solicitud)
        {
            return dSolicitudPrestamo.Modificar(solicitud);
        }

        public String Eliminar(int id)
        {
            return dSolicitudPrestamo.Eliminar(id);
        }

        public List<SolicitudPrestamo> ListarTodo()
        {
            return dSolicitudPrestamo.ListarTodo();
        }


    }
}
