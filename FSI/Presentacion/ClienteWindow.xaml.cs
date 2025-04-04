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
    /// Lógica de interacción para ClienteWindow.xaml
    /// </summary>
    public partial class ClienteWindow : Window
    {
        private NCliente nCliente = new NCliente();
        Cliente clienteSeleccionado = null;
        public ClienteWindow()
        {
            InitializeComponent();
            MostrarClientes(nCliente.ListarTodo());

        }
        private void MostrarClientes(List<Cliente> clientes)
        {
            dgClientes.ItemsSource = new List<Cliente>();
            dgClientes.ItemsSource = clientes;
        }
        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            // Validación de campos
            if (tbDNI.Text == "" || tbNombre.Text == "" || tbApellido.Text == "" || tbDireccion.Text == "" || tbTelefono.Text == "" || cbTipo.Text == "")
            {
                MessageBox.Show("Ingrese todos los campos");
                return;
            }

            // Creación del objeto
            Cliente cliente = new Cliente
            {
                Dni = tbDNI.Text,
                Nombre = tbNombre.Text,
                Apellido = tbApellido.Text,
                Direccion = tbDireccion.Text,
                Telefono = tbTelefono.Text,
                Tipo_Cliente = cbTipo.Text,

            };

            // Registrar el objeto
            String mensaje = nCliente.Registrar(cliente);
            MessageBox.Show(mensaje);

            // Mostrar en el DataGrid
            MostrarClientes(nCliente.ListarTodo());
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            // Validación de campos
            if (tbDNI.Text == "" || tbNombre.Text == "" || tbApellido.Text == "" || tbDireccion.Text == "" || tbTelefono.Text == "" || cbTipo.Text == "")
            {
                MessageBox.Show("Ingrese todos los campos");
                return;
            }

            // Validación de selección
            if (clienteSeleccionado == null)
            {
                MessageBox.Show("Seleccione un cliente");
                return;
            }

            // Creación del objeto
            Cliente cliente = new Cliente
            {
                ClienteID=clienteSeleccionado.ClienteID,
                Dni = tbDNI.Text,
                Nombre = tbNombre.Text,
                Apellido = tbApellido.Text,
                Direccion = tbDireccion.Text,
                Telefono = tbTelefono.Text,
                Tipo_Cliente = cbTipo.Text,
            };

            // Registrar el objeto
            String mensaje = nCliente.Modificar(cliente);
            MessageBox.Show(mensaje);

            // Mostrar en el DataGrid
            MostrarClientes(nCliente.ListarTodo());
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            // Validación de selección
            if (clienteSeleccionado == null)
            {
                MessageBox.Show("Seleccione un cliente");
                return;
            }

            // Eliminar
            String mensaje = nCliente.Eliminar(clienteSeleccionado.ClienteID);
            MessageBox.Show(mensaje);

            // Mostrar en el DataGrid
            MostrarClientes(nCliente.ListarTodo());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CuentaWindow window = new CuentaWindow();
            window.Show();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgDocentes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            clienteSeleccionado = dgClientes.SelectedItem as Cliente;

        }
    }
}
