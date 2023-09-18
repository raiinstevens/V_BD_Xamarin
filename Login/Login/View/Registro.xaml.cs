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

namespace Login.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        public Registro()
        {
            InitializeComponent();
        }
        private async void btn_Registro(object sender, EventArgs e)
        {
            Registro_Clase reg = new Registro_Clase
            {
                nombre = txtNombre.Text,
                app = txtApp.Text,
                apm = txtApm.Text,
                email =txtEmail.Text,
                password = txtPassword.Text,
                dni = txtDni.Text,
            };

            Uri RequestUri = new Uri("https://b372-213-173-36-2.ngrok-free.app/api/register");
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(reg);
            var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(RequestUri, contentJson);
            if (response.StatusCode==HttpStatusCode.OK)
            {
                await DisplayAlert("Datos", "Se registro correctamente", "OK");
                txtNombre.Text = "";
                txtApp.Text = "";
                txtApm.Text = "";
                txtEmail.Text = "";
                txtPassword.Text = "";
                txtDni.Text = "";
                await Navigation.PushAsync(new Page1());

            }
            else
            {
                await DisplayAlert("Datos", "No se pudo registrar", "OK");
            }

        }

  
    }
}