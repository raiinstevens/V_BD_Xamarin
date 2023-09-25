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
    public partial class DetallesVuelos : ContentPage
    {
        public DetallesVuelos(int paisId)
        {
            InitializeComponent();

            System.Diagnostics.Debug.WriteLine($"El valor de paisId antes de la asignación es: {paisId}");

            ObtenerEntrada(paisId);

            // Resto del constructor
        }
        private async void ObtenerEntrada(int paisId)
        {
            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri($"https://7f3a-213-173-36-2.ngrok-free.app/api/vuelos/pais/{paisId}");
            request.Headers.Add("Accept", "application/json");
            var client = new HttpClient();
            try
            {
                HttpResponseMessage response = await client.SendAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<List<DatosVuelos>>(content);
                    Lista_Entrada.ItemsSource = resultado;
                }
                else
                {
                    await DisplayAlert("Error", "Problemas técnicos", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Error al realizar la solicitud: {ex.Message}", "OK");
            }

        }

        private async void btn_ComprarVueloP(object sender, EventArgs e)
        {
            // Obtener el elemento seleccionado en la colección
            DatosVuelos vueloSeleccionado = (sender as Button)?.BindingContext as DatosVuelos;

            if (vueloSeleccionado != null)
            {
                // Obtener los valores de claseProbreId e id del vuelo seleccionado
                int claseProbreId = vueloSeleccionado.claseProbreId;
                int vueloId = vueloSeleccionado.id;

                // Asignar los valores a claseId y vueloId
                ComprarVuelo compraVuelo = new ComprarVuelo
                {
                    claseId = claseProbreId,
                    vueloId = vueloId,
                    // También puedes asignar otros valores según sea necesario
                    paqueteId = null,
                    userId = AppSettings.Instance.UserId,
                };

                // Aquí puedes realizar la lógica para enviar la información de compra
                // Puedes enviar 'compraVuelo' al servidor o realizar cualquier otra acción que necesites.

                // Ejemplo de impresión para verificar los valores
                System.Diagnostics.Debug.WriteLine($"claseId: {compraVuelo.claseId}, vueloId: {compraVuelo.vueloId}, userId: {compraVuelo.userId}");

                Uri RequestUri = new Uri("https://7f3a-213-173-36-2.ngrok-free.app/api/comprar");
                var client = new HttpClient();
                var json = JsonConvert.SerializeObject(compraVuelo);
                var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(RequestUri, contentJson);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //string content = await response.Content.ReadAsStringAsync();
                    await DisplayAlert("Datos", "Se compro correctamente", "OK");
                    //await Navigation.PushAsync(new Pagina_Principal());
                }
                else
                {
                    await DisplayAlert("Datos", "Usuario no encontrado", "OK");
                }
            }
        }


        private async void btn_ComprarVueloV(object sender, EventArgs e)
        {
            // Obtener el elemento seleccionado en la colección
            DatosVuelos vueloSeleccionado = (sender as Button)?.BindingContext as DatosVuelos;

            if (vueloSeleccionado != null)
            {
                // Obtener los valores de claseProbreId e id del vuelo seleccionado
                int claseProbreId = vueloSeleccionado.claseVipId;
                int vueloId = vueloSeleccionado.id;

                // Asignar los valores a claseId y vueloId
                ComprarVuelo compraVuelo = new ComprarVuelo
                {
                    claseId = claseProbreId,
                    vueloId = vueloId,
                    // También puedes asignar otros valores según sea necesario
                    paqueteId = null,
                    userId = AppSettings.Instance.UserId,
                };

                // Aquí puedes realizar la lógica para enviar la información de compra
                // Puedes enviar 'compraVuelo' al servidor o realizar cualquier otra acción que necesites.

                // Ejemplo de impresión para verificar los valores
                System.Diagnostics.Debug.WriteLine($"claseId: {compraVuelo.claseId}, vueloId: {compraVuelo.vueloId}, userId: {compraVuelo.userId}");

                Uri RequestUri = new Uri("https://7f3a-213-173-36-2.ngrok-free.app/api/comprar");
                var client = new HttpClient();
                var json = JsonConvert.SerializeObject(compraVuelo);
                var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(RequestUri, contentJson);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //string content = await response.Content.ReadAsStringAsync();
                    await DisplayAlert("Datos", "Se compro correctamente", "OK");
                    //await Navigation.PushAsync(new Pagina_Principal());
                }
                else
                {
                    await DisplayAlert("Datos", "Usuario no encontrado", "OK");
                }
            }
        }
        private async void btn_ComprarVueloF(object sender, EventArgs e)
        {
            // Obtener el elemento seleccionado en la colección
            DatosVuelos vueloSeleccionado = (sender as Button)?.BindingContext as DatosVuelos;

            if (vueloSeleccionado != null)
            {
                // Obtener los valores de claseProbreId e id del vuelo seleccionado
                int claseProbreId = vueloSeleccionado.claseFacheroId;
                int vueloId = vueloSeleccionado.id;

                // Asignar los valores a claseId y vueloId
                ComprarVuelo compraVuelo = new ComprarVuelo
                {
                    claseId = claseProbreId,
                    vueloId = vueloId,
                    // También puedes asignar otros valores según sea necesario
                    paqueteId = null,
                    userId = AppSettings.Instance.UserId,
                };

                // Aquí puedes realizar la lógica para enviar la información de compra
                // Puedes enviar 'compraVuelo' al servidor o realizar cualquier otra acción que necesites.

                // Ejemplo de impresión para verificar los valores
                System.Diagnostics.Debug.WriteLine($"claseId: {compraVuelo.claseId}, vueloId: {compraVuelo.vueloId}, userId: {compraVuelo.userId}");

                Uri RequestUri = new Uri("https://7f3a-213-173-36-2.ngrok-free.app/api/comprar");
                var client = new HttpClient();
                var json = JsonConvert.SerializeObject(compraVuelo);
                var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(RequestUri, contentJson);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //string content = await response.Content.ReadAsStringAsync();
                    await DisplayAlert("Datos", "Se compro correctamente", "OK");
                    //await Navigation.PushAsync(new Pagina_Principal());
                }
                else
                {
                    await DisplayAlert("Datos", "Usuario no encontrado", "OK");
                }
            }
        }
    }
}