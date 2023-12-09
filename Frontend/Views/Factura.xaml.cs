
using System.Windows;
using System.Windows.Controls;
using Frontend.models;
using System.Net.Http;
using System.Net.Http.Headers;



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

        }
        private void BtnEliminarFact_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BtnEditarFact_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
