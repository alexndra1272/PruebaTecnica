
using System.Windows;
using System.Windows.Controls;
using Frontend.models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.ConstrainedExecution;



namespace Frontend.Views
{
    /// <summary>
    /// Lógica de interacción para Factura.xaml
    /// </summary>
    public partial class Factura : UserControl
    {
        private readonly HttpClient client = new HttpClient();
        public Factura()
        {
            client.BaseAddress = new Uri("https://localhost:7277/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
            // Registra el evento Loaded
            Loaded += Factura_Loaded;

            InitializeComponent();
        }
        private void Factura_Loaded(object sender, RoutedEventArgs e)
        {
            // Llamada al método de carga después de que el control se ha cargado
            cargarFacturas();
        }
        private void cargarFacturas()
        {
            // Llamada a la API
            HttpResponseMessage response = client.GetAsync("factura").Result;
            // Verificar si la respuesta es exitosa
            if (response.IsSuccessStatusCode)
            {
                // Obtener los datos del API y asignarlos a la propiedad Items
                var facturas = response.Content.ReadAsAsync<IEnumerable<Facturas>>().Result;
                // Asignar los datos en el DataGrid
                DatosFactura.ItemsSource = facturas;
            }
        }
        private void TxtBuscarFact_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BtnAgregarFact_Click(object sender, RoutedEventArgs e)
        {
            // Mostrar ventana de agregar persona
            CrudFactura ventana = new CrudFactura();
            FrameFactura.Content = ventana;

            // Hacer visible el botón de guardar
            ventana.BtnGuardar.Visibility = Visibility.Visible;

        }
        private void BtnEliminarFact_Click(object sender, RoutedEventArgs e)
        {
            // Obtener el id de la factura seleccionada
            var id = ((Button)sender).CommandParameter.ToString();

            // Mostrar ventana de eliminar factura
            CrudFactura ventana = new CrudFactura();
            FrameFactura.Content = ventana;
            ventana.Titulo.Text = "Eliminar factura";

            // Asignar el id a la variable global
            ventana.idFactura = Int32.Parse(id);

            // Obtener la factura seleccionada
            Facturas factura = (Facturas)DatosFactura.SelectedItem;

            // Asignar los valores a los campos
            ventana.tboxMonto.Text = factura.Monto.ToString();
            ventana.Fecha.SelectedDate = factura.Fecha;
            ventana.tboxMonto.Text = factura.Monto.ToString();
            ventana.CboxPersona.Text = factura.NombrePersona;

            // Hacer visible el botón de eliminar
            ventana.BtnEliminar.Visibility = Visibility.Visible;

            // Deshabilitar los campos
            ventana.tboxMonto.IsEnabled = false;
            ventana.Fecha.IsEnabled = false;
            ventana.CboxPersona.IsEnabled = false;
            
        }
        private void BtnEditarFact_Click(object sender, RoutedEventArgs e)
        {
            // Obtener el id de la factura seleccionada
            var id = ((Button)sender).CommandParameter.ToString();

            // Mostrar ventana de editar factura
            CrudFactura ventana = new CrudFactura();
            FrameFactura.Content = ventana;
            ventana.Titulo.Text = "Editar factura";

            // Asignar el id a la variable global
            ventana.idFactura = Int32.Parse(id);

            // Obtener la factura seleccionada
            Facturas factura = (Facturas)DatosFactura.SelectedItem;

            // Asignar los valores a los campos
            ventana.tboxMonto.Text = factura.Monto.ToString();
            ventana.Fecha.SelectedDate = factura.Fecha;
            ventana.tboxMonto.Text = factura.Monto.ToString();
            ventana.CboxPersona.Text = factura.NombrePersona;


            // Hacer visible el botón de actualizar
            ventana.BtnModificar.Visibility = Visibility.Visible;

        }
    }
}
