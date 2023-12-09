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
    /// Lógica de interacción para CrudPersona.xaml
    /// </summary>
    public partial class CrudPersona : Page
    {

        HttpClient client = new HttpClient();
        public CrudPersona()
        {

            client.BaseAddress = new Uri("https://localhost:7277/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );

            InitializeComponent();
   
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Content = new Persona();
        }
       private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (tboxName.Text == "" || tboxApPat.Text == "" || tboxid.Text == "")
            {
                MessageBox.Show("Favor de llenar todos los campos");
                return;
            }

            // Crear objeto persona
            Personas persona = new Personas();
            persona.Nombre = tboxName.Text;
            persona.ApellidoPaterno = tboxApPat.Text;
            persona.ApellidoMaterno = tboxApMat.Text;
            persona.Identificacion = tboxid.Text;


            // Enviar al backend
            var response = client.PostAsJsonAsync("persona", persona).Result;
            if (response.IsSuccessStatusCode)
            {
                Content = new Persona();
            }
            else
            {
                MessageBox.Show(response.StatusCode.ToString());
            }
        }

    }
}
