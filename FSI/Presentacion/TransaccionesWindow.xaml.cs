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
    /// Lógica de interacción para TransaccionesWindow.xaml
    /// </summary>
    public partial class TransaccionesWindow : Window
    {
        private NTransacciones nTransacciones = new NTransacciones();
        private NCuenta nCuenta = new NCuenta();
        Transacciones transaccionSeleccionado = null;

        public TransaccionesWindow()
        {
            InitializeComponent();
            MostrarCuentas(nCuenta.ListarTodo());
            MostrarTransacciones(nTransacciones.ListarTodo());
        }

        private void MostrarCuentas(List<Cuenta> cuentas)
        {
            cbCuenta.ItemsSource = new List<Cuenta>();
            cbCuenta.ItemsSource = cuentas;
            cbCuenta.DisplayMemberPath = "CuentaID";
            cbCuenta.SelectedValuePath = "CuentaID";
        }
         
        private void MostrarTransacciones(List<Transacciones> transacciones)
        {
            dgTransaccion.ItemsSource = new List<Transacciones>();
            dgTransaccion.ItemsSource = transacciones;
        }
        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            // Validación de campos
            if (tbMonto.Text == "" || cbCuenta.Text == ""  || date_Fecha.Text == "" || cb_TipoTransaccion.Text == "")
            {
                MessageBox.Show("Ingrese todos los campos");
                return;
            }
             
            // Creación del objeto
            Transacciones transaccion = new Transacciones
            {
                Monto = decimal.Parse(tbMonto.Text),
                Fecha = (DateTime)date_Fecha.SelectedDate,
                Tipo_Transaccion = cb_TipoTransaccion.Text,
                CuentaID = (int)cbCuenta.SelectedValue,
            };

            // Registrar el objeto
            String mensaje = nTransacciones.Registrar(transaccion);
            MessageBox.Show(mensaje);
            nTransacciones.Actualizar(transaccion);
            // Mostrar en el DataGrid
            MostrarTransacciones(nTransacciones.ListarTodo());
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (tbMonto.Text == "" || cbCuenta.Text == "" || date_Fecha.Text == "" || cb_TipoTransaccion.Text == "")
            {
                MessageBox.Show("Ingrese todos los campos");
                return;
            }
            if (transaccionSeleccionado == null)
            {
                MessageBox.Show("Seleccione una transaccion");
                return;
            }
            // Creación del objeto
            Transacciones transaccion = new Transacciones
            {
                TransaccionID = transaccionSeleccionado.TransaccionID,
                Monto = decimal.Parse(tbMonto.Text),
                Fecha = (DateTime)date_Fecha.SelectedDate,
                Tipo_Transaccion = cb_TipoTransaccion.Text,
                CuentaID = (int)cbCuenta.SelectedValue,
            };

            // Registrar el objeto
            String mensaje = nTransacciones.Modificar(transaccion);
            MessageBox.Show(mensaje);

            // Mostrar en el DataGrid
            MostrarTransacciones(nTransacciones.ListarTodo());
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            // Validación de selección
            if (transaccionSeleccionado == null)
            {
                MessageBox.Show("Seleccione una transaccion");
                return;
            }
            // Eliminar
            String mensaje = nTransacciones.Eliminar(transaccionSeleccionado.TransaccionID);
            MessageBox.Show(mensaje);

            // Mostrar en el DataGrid
            MostrarTransacciones(nTransacciones.ListarTodo());
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgTransaccion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            transaccionSeleccionado = dgTransaccion.SelectedItem as Transacciones;
        }

        private void btnTransferencia_Click(object sender, RoutedEventArgs e)
        {
            TransferenciasWindow window = new TransferenciasWindow();
            window.Show();
        }
    }
}
