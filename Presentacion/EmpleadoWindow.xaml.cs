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
    /// Lógica de interacción para EmpleadoWindow.xaml
    /// </summary>
    public partial class EmpleadoWindow : Window
    {
        private NEmpleado nEmpleado = new NEmpleado();
        private NSucursal nSucursal = new NSucursal();
        Empleado empleadoSeleccionado = null;

        public EmpleadoWindow()
        {
            InitializeComponent();
            MostrarSucursal(nSucursal.ListarTodo());
            MostrarEmpleado(nEmpleado.ListarTodo());
        }
        private void MostrarSucursal(List<Sucursal> sucursals)
        {
            cbSucursal.ItemsSource = new List<Sucursal>();
            cbSucursal.ItemsSource = sucursals;
            cbSucursal.DisplayMemberPath = "Ubicacion";
            cbSucursal.SelectedValuePath = "ID";
        }
        private void MostrarEmpleado(List<Empleado> empleados)
        {
            dgEmpleado.ItemsSource = new List<Empleado>();
            dgEmpleado.ItemsSource = empleados;
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            // Validación de campos
            if (tbNombre.Text == "" || cbSucursal.Text == "" || tbApellido.Text == "" || cbCargo.Text == "" )
            {
                MessageBox.Show("Ingrese todos los campos");
                return;
            }

            // Creación del objeto
            Empleado c = new Empleado
            {
                Nombre =tbNombre.Text,
                Apellido = tbApellido.Text,
                Cargo = cbCargo.Text,
                Sucursal_ID = (int)cbSucursal.SelectedValue,
            };

            // Registrar el objeto
            String mensaje = nEmpleado.Registrar(c);
            MessageBox.Show(mensaje);

            // Mostrar en el DataGrid
            MostrarEmpleado(nEmpleado.ListarTodo());
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (tbNombre.Text == "" || cbSucursal.Text == "" || tbApellido.Text == "" || cbCargo.Text == "")
            {
                MessageBox.Show("Ingrese todos los campos");
                return;
            }
            if (empleadoSeleccionado == null)
            {
                MessageBox.Show("Seleccione una empleado");
                return;
            }
            // Creación del objeto
            Empleado empleado = new Empleado
            {
                EmpleadoID = empleadoSeleccionado.EmpleadoID,
                Nombre = tbNombre.Text,
                Apellido = tbApellido.Text,
                Cargo = cbCargo.Text,
                Sucursal_ID = (int)cbSucursal.SelectedValue,
            };

            // Registrar el objeto
            String mensaje = nEmpleado.Modificar(empleado);
            MessageBox.Show(mensaje);

            // Mostrar en el DataGrid
            MostrarEmpleado(nEmpleado.ListarTodo());
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            // Validación de selección
            if (empleadoSeleccionado == null)
            {
                MessageBox.Show("Seleccione una empleado");
                return;
            }

            // Eliminar
            String mensaje = nEmpleado.Eliminar(empleadoSeleccionado.EmpleadoID);
            MessageBox.Show(mensaje);

            // Mostrar en el DataGrid
            MostrarEmpleado(nEmpleado.ListarTodo());
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgDocentes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            empleadoSeleccionado = dgEmpleado.SelectedItem as Empleado;

        }
    }
}
