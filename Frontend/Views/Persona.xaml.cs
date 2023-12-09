using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;
using System.Windows.Controls;
using Frontend.models;

namespace Frontend.Views
{
    public partial class Persona : UserControl
    {
        private readonly HttpClient client = new HttpClient();

        public Persona()
        {
            client.BaseAddress = new Uri("https://localhost:7277/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );

            // Registra el evento Loaded
            Loaded += Persona_Loaded;

            InitializeComponent();
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            // Mostrar ventana de agregar persona
            CrudPersona ventana = new CrudPersona();
            FramePersona.Content = ventana;

            // Hacer visible el botón de guardar
            ventana.BtnGuardar.Visibility = Visibility.Visible;
        }
        private void Persona_Loaded(object sender, RoutedEventArgs e)
        {
            // Llamada al método de carga después de que el control se ha cargado
            cargarPersonas();
        }
        // Llamar a la ventana de edición
        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            // Obtener el id de la persona seleccionada
            var id = ((Button)sender).CommandParameter.ToString();
            

            // Mostrar ventana de editar persona
            CrudPersona ventana = new CrudPersona();
            FramePersona.Content = ventana;
            ventana.Titulo.Text = "Editar persona";
            // Asignar el id a la variable global
            ventana.idPersona = Int32.Parse(id);
            // Obtener la persona seleccionada
            Personas persona = (Personas)DatosPersona.SelectedItem;

            // Asignar los valores a los campos
            ventana.tboxName.Text = persona.Nombre;
            ventana.tboxApPat.Text = persona.ApellidPaterno;
            ventana.tboxApMat.Text = persona.ApellidMaterno;
            ventana.tboxid.Text = persona.Identificacion;

            // Deshabilitar el campo de identificación

            ventana.tboxid.IsEnabled = false;

            // Hacer visible el botón de actualizar
            ventana.BtnActualizar.Visibility = Visibility.Visible;

            

        }
        void cargarPersonas()
        {
            HttpResponseMessage response = client.GetAsync("persona").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var personas = JsonConvert.DeserializeObject<List<Personas>>(data);
                DatosPersona.ItemsSource = personas;
            }
        }
    }
}
