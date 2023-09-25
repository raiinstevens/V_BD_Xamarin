using Login.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Login.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pagina_Paquetes : ContentPage
    {
        public Pagina_Paquetes()
        {
            InitializeComponent();
        }
        private async void btn_ObtenerEntrada(object sender, EventArgs e)
        {
            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Get;
            request.RequestUri = new Uri("https://7f3a-213-173-36-2.ngrok-free.app/api/paises");
            request.Headers.Add("Accept", "application/json");
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Paises>>(content);
                Lista_Entrada.ItemsSource = resultado;
            }
            else
            {
                await DisplayAlert("Error", "Problemas tecnicos", "OK");
            }
        }
        private async void btn_VerVuelos(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Paises pais = (Paises)button.BindingContext; // Obtener el objeto Paises asociado al botón

            // Realizar la navegación y pasar el ID del país como parámetro
            await Navigation.PushAsync(new DetallesPaquetes(pais.id));
        }
    }
}