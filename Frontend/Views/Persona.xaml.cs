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
        private bool personasCargadas = false;  // Bandera para rastrear si las personas ya se cargaron

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
        }
        private void Persona_Loaded(object sender, RoutedEventArgs e)
        {
            // Llamada al método de carga después de que el control se ha cargado
            cargarPersonas();
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
