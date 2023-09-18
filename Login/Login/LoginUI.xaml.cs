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
using Xamarin.Essentials;

namespace Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        /*private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender == txtUsername)
            {
                AppSettings.Instance.email = e.NewTextValue;
            }
        }*/


        private async void Logiar(object sender, EventArgs e)
        {
            Login_Clase log = new Login_Clase()
            {
                username = txtUsername.Text,
                password = txtPassword.Text,
            };

            // Verifica las credenciales (aquí deberías agregar tu lógica de autenticación)
            Uri RequestUri = new Uri("https://b372-213-173-36-2.ngrok-free.app/api/login");
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(log);
            var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(RequestUri, contentJson);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                /*string content = await response.Content.ReadAsStringAsync();

                // Deserializa la respuesta JSON para obtener el valor "email"
                dynamic responseData = JsonConvert.DeserializeObject(content);
                string email = responseData.email;

                // Guarda el valor "email" en una variable global
                AppSettings.Instance.email = email;

                await DisplayAlert("Datos", "Se logueó correctamente", "OK");
                await Navigation.PushAsync(new Pagina_Principal());*/
            }
            else
            {
                await DisplayAlert("Datos", "Usuario no encontrado", "OK");
            }
        }




        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }
    }
}