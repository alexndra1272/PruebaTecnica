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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Frontend.Views
{
    /// <summary>
    /// Lógica de interacción para CrudFactura.xaml
    /// </summary>
    public partial class CrudFactura : Page
    {
        public CrudFactura()
        {
            InitializeComponent();

        }
        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Content = new Factura();
        }
        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
           
        }
        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Content = new Factura();
        }

    }
}
