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

        private async void Logiar(object sender, EventArgs e)
        {
            Login_Clase log = new Login_Clase()
            {
                username = txtUsername.Text,
                password = txtPassword.Text,
            };

            // Verifica las credenciales (aquí deberías agregar tu lógica de autenticación)
            Uri RequestUri = new Uri("https://7f3a-213-173-36-2.ngrok-free.app/api/login");
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(log);
            var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(RequestUri, contentJson);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();

                ApiResponse responseData = JsonConvert.DeserializeObject<ApiResponse>(content);
                int userId = responseData.id;

                // Guarda el ID en una variable global o en AppSettings
                AppSettings.Instance.UserId = userId;

                // Guarda el nombre completo en AppSettings
                string fullName = responseData.fullnombre; // Reemplaza esto con el nombre real obtenido de la API
                AppSettings.Instance.FullName = fullName;

                System.Diagnostics.Debug.WriteLine($"claseId: {userId}");
                System.Diagnostics.Debug.WriteLine($"Nombre Completo: {fullName}");

                await DisplayAlert("Datos", "Se logueó correctamente", "OK");
                txtPassword.Text = "";
                txtUsername.Text = "";
                
                await Navigation.PushAsync(new Pagina_Principal());
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