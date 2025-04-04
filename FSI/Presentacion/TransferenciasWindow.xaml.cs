using Datos;
using Negocio;
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
namespace Presentacion
{
    /// <summary>
    /// Lógica de interacción para TransferenciasWindow.xaml
    /// </summary>
    public partial class TransferenciasWindow : Window
    {
        private NTransacciones nTransacciones = new NTransacciones();
        private NCuenta nCuentas = new NCuenta();
        private NCuenta nCuenta = new NCuenta();
        public TransferenciasWindow()
        {
            InitializeComponent();
            MostrarCuentas(nCuenta.ListarTodo());
            MostrarCuentasDatagrip(nCuenta.ListarTodo());
            MostrarTransaccionesDatagrip(nTransacciones.ListarTodo());
        }
        private void MostrarCuentas(List<Cuenta> cuentas)
        {
            cbCuenta1.ItemsSource = new List<Cuenta>();
            cbCuenta1.ItemsSource = cuentas;
            cbCuenta1.DisplayMemberPath = "CuentaID";
            cbCuenta1.SelectedValuePath = "CuentaID";

            cbCuenta2.ItemsSource = new List<Cuenta>();
            cbCuenta2.ItemsSource = cuentas;
            cbCuenta2.DisplayMemberPath = "CuentaID";
            cbCuenta2.SelectedValuePath = "CuentaID";
        }

        private void MostrarTransaccionesDatagrip(List<Transacciones> transacciones)
        {
            dgTransaccion.ItemsSource = new List<Transacciones>();
            dgTransaccion.ItemsSource = transacciones;
        }
        private void MostrarCuentasDatagrip(List<Cuenta> cuentas)
        {
            dgCuentas.ItemsSource = new List<Cuenta>();
            dgCuentas.ItemsSource = cuentas;
        }
        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            // Validación de campos
            if (cbCuenta1.Text == "" || cbCuenta2.Text == "" || date_Fecha.Text == "" || tbMonto.Text == "")
            {
                MessageBox.Show("Ingrese todos los campos");
                return;
            }
            
            // Creación del objeto
            Transacciones transaccion = new Transacciones
            {
                Monto = decimal.Parse(tbMonto.Text),
                Fecha = (DateTime)date_Fecha.SelectedDate,
                Tipo_Transaccion = "Transferencia",
                CuentaID = (int)cbCuenta1.SelectedValue,
            };


            // Registrar el objeto
            String mensaje = nTransacciones.Registrar(transaccion);
            

            int CuentaID1 = (int)cbCuenta1.SelectedValue;
            int CuentaID2 = (int)cbCuenta2.SelectedValue;
            decimal monto = decimal.Parse(tbMonto.Text);
            nCuentas.Actualizar_Transferencia(CuentaID1, CuentaID2, monto);
            // Mostrar en el DataGrid
            MessageBox.Show(mensaje);
            MostrarTransaccionesDatagrip(nTransacciones.ListarTodo());
            MostrarCuentasDatagrip(nCuenta.ListarTodo());

        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgTransaccion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dgCuentas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
