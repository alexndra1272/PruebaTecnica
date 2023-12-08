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
    /// Lógica de interacción para Persona.xaml
    /// </summary>
    public partial class Persona : UserControl
    {
        HttpClient client = new HttpClient();
        public Persona()
        {
            client.BaseAddress = new Uri("https://localhost:44315/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );

            InitializeComponent();
            cargarPersonas();
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            CrudPersona ventana = new CrudPersona();
            FramePersona.Content = ventana;
        }
        void cargarPersonas()
        {
            HttpResponseMessage response = client.GetAsync("persona").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var personas = JsonConvert.DeserializeObject<List<Persona>>(data);
                dgPersonas.ItemsSource = personas;
            }
        }
        
    }
}
