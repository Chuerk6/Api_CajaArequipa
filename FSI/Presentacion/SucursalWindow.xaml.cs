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
    /// Lógica de interacción para SucursalWindow.xaml
    /// </summary>
    public partial class SucursalWindow : Window
    {
        private NSucursal nSucursal = new NSucursal();
        public SucursalWindow()
        {
            InitializeComponent();
            MostrarSucursales(nSucursal.ListarTodo());
        }
        private void MostrarSucursales(List<Sucursal> sucursales)
        {
            dgSucursales.ItemsSource = new List<Sucursal>();
            dgSucursales.ItemsSource = sucursales;
        }

        private void dgSucursales_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
