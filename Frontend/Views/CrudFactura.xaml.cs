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
    /// 
    public class PersonaComboItem
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public override string ToString()
        {
            return Nombre; // Esto determina qué se mostrará en el ComboBox
        }
    }
    public partial class CrudFactura : Page
    {
        private readonly HttpClient client = new HttpClient();

        // idFactura
        public int idFactura;


        public CrudFactura()
        {
            InitializeComponent();

            client.BaseAddress = new Uri("https://localhost:7277/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );

            // Registra el evento Loaded
            Loaded += CrudPersona_Loaded;

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

                // Crear objetos PersonaComboItem con Id y Nombre
                var personasCombo = personas.Select(p => new PersonaComboItem { Id = p.IdPersona, Nombre = $"{p.Nombre} {p.ApellidPaterno}" });

                // Asignar los datos al ComboBox
                CboxPersona.ItemsSource = personasCombo;

                // Asignar el primer elemento como seleccionado
                CboxPersona.SelectedIndex = 0;
            }
        }

        private int ObtenerIdPersonaSeleccionada()
        {
            if (CboxPersona.SelectedItem is PersonaComboItem personaComboItem)
            {
                return personaComboItem.Id;
            }

            // En caso de que no haya una persona seleccionada, puedes devolver un valor predeterminado o lanzar una excepción según tus necesidades.
            throw new InvalidOperationException("No se ha seleccionado ninguna persona.");
        }
        private void txtNumero_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string newText = (sender as TextBox)?.Text + e.Text;

            // Verificar si el texto de entrada cumple con las restricciones
            if (!newText.All(char.IsDigit))
            {
                e.Handled = true; // Cancelar la entrada si no cumple con las restricciones
            }
        }

        
        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Content = new Factura();
        }
        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (tboxMonto.Text == "" || Fecha.SelectedDate == null || CboxPersona.SelectedItem == null)
            {
                MessageBox.Show("Favor de llenar todos los campos");
                return;
            }
            // Crear objeto Factura
            var factura = new Facturas
            {
                Fecha = Fecha.SelectedDate ?? DateTime.Now,
                Monto = Convert.ToDecimal(tboxMonto.Text),
                IdPersona = ObtenerIdPersonaSeleccionada()
            };

            // Llamada a la API
            HttpResponseMessage response = client.PostAsJsonAsync("factura", factura).Result;

            // Verificar si la respuesta es exitosa
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Factura agregada correctamente.");
                Content = new Factura();
            }
            else
            {
                MessageBox.Show("Error al agregar la factura.");
            }
        }
        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (tboxMonto.Text == "" || Fecha.SelectedDate == null || CboxPersona.SelectedItem == null)
            {
                MessageBox.Show("Favor de llenar todos los campos");
                return;
            }

            // Crear objeto Factura
            var factura = new Facturas
            {
                IdFactura = idFactura,
                Fecha = Fecha.SelectedDate ?? DateTime.Now,
                Monto = Convert.ToDecimal(tboxMonto.Text),
                IdPersona = ObtenerIdPersonaSeleccionada()
            };

            // Llamada a la API
            HttpResponseMessage response = client.PutAsJsonAsync("factura/" + factura.IdFactura, factura).Result;

            // Verificar si la respuesta es exitosa
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Factura modificada correctamente.");
                Content = new Factura();
            }
            else
            {
                MessageBox.Show("Error al modificar la factura.");
            }
            
        }
        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Content = new Factura();
        }

    }
}
