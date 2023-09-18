using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using Login.Model;
using System.Net.Http;
using System.Net;
using Login.View;

namespace Login.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pagina_Entrada : ContentPage
    {
        public Pagina_Entrada()
        {
            InitializeComponent();
            asiento = this.FindByName<Entry>("asiento"); // Asigna el Entry a la variable global asiento

        }

        private async void btn_ObtenerEntrada(object sender, EventArgs e)
        {
            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Get;
            request.RequestUri = new Uri("https://b372-213-173-36-2.ngrok-free.app/api/entradas");
            request.Headers.Add("Accept", "application/json");
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Entrada_Clase>>(content);
                Lista_Entrada.ItemsSource = resultado;
            }
            else
            {
                await DisplayAlert("Error", "Problemas tecnicos", "OK");
            }
        }


        private int selectedEntradaId;

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Entrada_Clase selectedEntrada)
            {
                // Almacena el ID de la entrada seleccionada
                selectedEntradaId = selectedEntrada.id;
            }
        }

    //        string valorGlobal = AppSettings.Instance.email;



        private Entry asiento;

        private async void btn_ComprarEntrada(object sender, EventArgs e)
        {

            // Aquí puedes realizar la solicitud GET con el id

            // Realiza una solicitud GET utilizando HttpClient y apiUrl
            ComprarEntrada_Clase com = new ComprarEntrada_Clase
            {
                entrada_id = selectedEntradaId,
                asiento = asiento.Text,
                email = AppSettings.Instance.email,

            };
            Uri RequestUri = new Uri("https://b372-213-173-36-2.ngrok-free.app/api/comprarEntrada");
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(com);
            var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(RequestUri, contentJson);
            // Maneja la respuesta de acuerdo a tus necesidades
            if (response.StatusCode == HttpStatusCode.OK)
            {
                await DisplayAlert("Datos", "Se Ha comprado correctamente", "OK");

                await Navigation.PushAsync(new Pagina_Principal());
            }
            else
            {
                await DisplayAlert("Datos", "Error al comprar", "OK");
            }



        }
    }
}