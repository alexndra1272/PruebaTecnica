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
using Frontend.models;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Frontend.Views
{
    /// <summary>
    /// Lógica de interacción para CrudFactura.xaml
    /// </summary>
    public partial class CrudFactura : Page
    {
        private readonly HttpClient client = new HttpClient();

        public CrudFactura()
        {
            InitializeComponent();

            client.BaseAddress = new Uri("https://localhost:7277/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );

            // Registra el evento Loaded
            Loaded += CrudPersona_Loaded

        }
        private void CrudPersona_Loaded(object sender, RoutedEventArgs e)
        {
            // cargar personas
            cargarPersonas();
        }

        private void cargarPersonas()
        {
            // Llamada a la API
            HttpResponseMessage response = client.GetAsync("persona").Result;
            // Verificar si la respuesta es exitosa
            if (response.IsSuccessStatusCode)
            {
                // Obtener los datos del API y asignarlos a la propiedad Items
                var personas = response.Content.ReadAsAsync<IEnumerable<Personas>>().Result;
                // Asignar los datos en el DataGrid
                CboxPersona.ItemsSource = personas;
            }
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
