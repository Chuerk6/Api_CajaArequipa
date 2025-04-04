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
    /// Lógica de interacción para CuentaWindow.xaml
    /// </summary>
    public partial class CuentaWindow : Window
    {
        private NCuenta nCuenta = new NCuenta();
        private NCliente nCliente = new NCliente();
        private NSucursal nSucursal = new NSucursal();

        Cuenta cuentaSeleccionado = null;

        public CuentaWindow()
        {
            InitializeComponent();
            MostrarClientes(nCliente.ListarTodo());
            MostrarSucursal(nSucursal.ListarTodo());
            MostrarCuenta(nCuenta.ListarTodo());

        }
        private void MostrarClientes(List<Cliente> clientes)
        {
            cbCliente.ItemsSource = new List<Cliente>();
            cbCliente.ItemsSource = clientes;
            cbCliente.DisplayMemberPath = "Nombre";
            cbCliente.SelectedValuePath = "ClienteID";
        }
         
        private void MostrarSucursal(List<Sucursal> sucursals)
        {
            cbSucursal.ItemsSource = new List<Sucursal>();
            cbSucursal.ItemsSource = sucursals;
            cbSucursal.DisplayMemberPath = "Ubicacion";
            cbSucursal.SelectedValuePath = "ID";
        }
        private void MostrarCuenta(List<Cuenta> cuentas)
        {
            dgCuenta.ItemsSource = new List<Cuenta>();
            dgCuenta.ItemsSource = cuentas;
        }
        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            // Validación de campos
            if (tbSaldo.Text == "" || cbCliente.Text == "" || cbSucursal.Text == ""||date_Fecha.Text==""|| cb_TipoCuenta.Text=="")
            {
                MessageBox.Show("Ingrese todos los campos");
                return;
            }

            // Creación del objeto
            Cuenta c = new Cuenta
            {
                Saldo = decimal.Parse(tbSaldo.Text),
                FechaApertura= (DateTime)date_Fecha.SelectedDate,
                Tipo_Cuenta=cb_TipoCuenta.Text,
                ClienteID = (int)cbCliente.SelectedValue,
                Sucursal_ID = (int)cbSucursal.SelectedValue,
            };

            // Registrar el objeto
            String mensaje = nCuenta.Registrar(c);
            MessageBox.Show(mensaje);

            // Mostrar en el DataGrid
            MostrarCuenta(nCuenta.ListarTodo());
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (tbSaldo.Text == "" || cbCliente.Text == "" || cbSucursal.Text == "" || date_Fecha.Text == "" || cb_TipoCuenta.Text == "")
            {
                MessageBox.Show("Ingrese todos los campos");
                return;
            }
            if (cuentaSeleccionado == null)
            {
                MessageBox.Show("Seleccione una cuenta");
                return;
            }
            // Creación del objeto
            Cuenta cuenta = new Cuenta
            {
                CuentaID=cuentaSeleccionado.CuentaID,
                Saldo = decimal.Parse(tbSaldo.Text),
                FechaApertura = (DateTime)date_Fecha.SelectedDate,
                Tipo_Cuenta = cb_TipoCuenta.Text,
                ClienteID = (int)cbCliente.SelectedValue,
                Sucursal_ID = (int)cbSucursal.SelectedValue,
            };

            // Registrar el objeto
            String mensaje = nCuenta.Modificar(cuenta);
            MessageBox.Show(mensaje);

            // Mostrar en el DataGrid
            MostrarCuenta(nCuenta.ListarTodo());
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            // Validación de selección
            if (cuentaSeleccionado == null)
            {
                MessageBox.Show("Seleccione una cuenta");
                return;
            }

            // Eliminar
            String mensaje = nCuenta.Eliminar(cuentaSeleccionado.CuentaID);
            MessageBox.Show(mensaje);

            // Mostrar en el DataGrid
            MostrarCuenta(nCuenta.ListarTodo());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TransaccionesWindow window = new TransaccionesWindow();
            window.Show();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSucursal_Click(object sender, RoutedEventArgs e)
        {
            SucursalWindow window = new SucursalWindow();
            window.Show();
        }

        private void dgDocentes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cuentaSeleccionado = dgCuenta.SelectedItem as Cuenta;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SolicitudPrestamoWindow window = new SolicitudPrestamoWindow();
            window.Show();
        }

         

        private void ButtonActualizar_Click(object sender, RoutedEventArgs e)
        {
            MostrarCuenta(nCuenta.ListarTodo());

        }

        private void ButtonFiltrar_Click(object sender, RoutedEventArgs e)
        {
            // Validación de campos
            if (tbClienteFiltrar.Text == "")
            {
                MessageBox.Show("Ingrese el ID cliente");
                return;
            }

            // Mostrar en el DataGrid
            MostrarCuenta(nCuenta.FiltrarCliente(int.Parse(tbClienteFiltrar.Text)));
        }
    }
}
