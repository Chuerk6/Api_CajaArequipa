using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Datos;
using Negocio;

namespace Presentacion
{
    /// <summary>
    /// Lógica de interacción para SolicitudPrestamoWindow.xaml
    /// </summary>
    public partial class SolicitudPrestamoWindow : Window
    {
        private NSolicitudPrestamo nSolicitudPrestamo = new NSolicitudPrestamo();
        private NEmpleado nEmpleado = new NEmpleado();
        private NCuenta nCuenta = new NCuenta();
        SolicitudPrestamo solicitudSeleccionado = null;

        public SolicitudPrestamoWindow()
        {
            InitializeComponent();
            MostrarEmpleado(nEmpleado.ListarTodo());
            MostrarCuenta(nCuenta.ListarTodo());
            MostrarSolicitudPrestamo(nSolicitudPrestamo.ListarTodo());
        }
        private void MostrarEmpleado(List<Empleado> empleados)
        {
            cbEmpleado.ItemsSource = new List<Sucursal>();
            cbEmpleado.ItemsSource = empleados;
            cbEmpleado.DisplayMemberPath = "Nombre";
            cbEmpleado.SelectedValuePath = "EmpleadoID";
        }
        private void MostrarCuenta(List<Cuenta> cuentas)
        {
            cbCuenta.ItemsSource = new List<Cuenta>();
            cbCuenta.ItemsSource = cuentas;
            cbCuenta.DisplayMemberPath = "CuentaID";
            cbCuenta.SelectedValuePath = "CuentaID";
        }
        private void MostrarSolicitudPrestamo(List<SolicitudPrestamo> solicitudes)
        {
            dgSolicitudPrestamo.ItemsSource = new List<SolicitudPrestamo>();
            dgSolicitudPrestamo.ItemsSource = solicitudes;
        }
        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            // Validación de campos
            if (tbMonto.Text == "" || date_Fecha.Text == "" || cbCuenta.Text == "" || cbEmpleado.Text == "")
            {
                MessageBox.Show("Ingrese todos los campos");
                return;
            }

            // Creación del objeto
            SolicitudPrestamo solicitud = new SolicitudPrestamo
            {
                MontoSolicitado = decimal.Parse(tbMonto.Text),
                FechaSolicitud = (DateTime)date_Fecha.SelectedDate,
                EmpleadoID = (int)cbEmpleado.SelectedValue,
                CuentaID = (int)cbCuenta.SelectedValue,
            };

            // Registrar el objeto
            String mensaje = nSolicitudPrestamo.Registrar(solicitud);
            MessageBox.Show(mensaje);
            // Mostrar en el DataGrid
            MostrarSolicitudPrestamo(nSolicitudPrestamo.ListarTodo());
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (tbMonto.Text == "" || date_Fecha.Text == "" || cbCuenta.Text == "" || cbEmpleado.Text == "")
            {
                MessageBox.Show("Ingrese todos los campos");
                return;
            }
            if (solicitudSeleccionado == null)
            {
                MessageBox.Show("Seleccione una cuenta");
                return;
            }
            // Creación del objeto
            SolicitudPrestamo solicitud = new SolicitudPrestamo
            {
                SolicitudID = solicitudSeleccionado.SolicitudID,
                MontoSolicitado = decimal.Parse(tbMonto.Text),
                FechaSolicitud = (DateTime)date_Fecha.SelectedDate,
                EmpleadoID = (int)cbEmpleado.SelectedValue,
                CuentaID = (int)cbCuenta.SelectedValue,
            };

            // Registrar el objeto
            String mensaje = nSolicitudPrestamo.Modificar(solicitud);
            MessageBox.Show(mensaje);

            // Mostrar en el DataGrid
            MostrarSolicitudPrestamo(nSolicitudPrestamo.ListarTodo());
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            // Validación de selección
            if (solicitudSeleccionado == null)
            {
                MessageBox.Show("Seleccione una cuenta");
                return;
            }

            // Eliminar
            String mensaje = nSolicitudPrestamo.Eliminar(solicitudSeleccionado.SolicitudID);
            MessageBox.Show(mensaje);

            // Mostrar en el DataGrid
            MostrarSolicitudPrestamo(nSolicitudPrestamo.ListarTodo());
        }
        private void btnEmpleados_Click(object sender, RoutedEventArgs e)
        {
            EmpleadoWindow window = new EmpleadoWindow();
            window.Show();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void dgDocentes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            solicitudSeleccionado = dgSolicitudPrestamo.SelectedItem as SolicitudPrestamo;

        }
    }
}
