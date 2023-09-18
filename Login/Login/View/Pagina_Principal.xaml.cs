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
    public partial class Pagina_Principal : ContentPage
    {
        public Pagina_Principal()
        {
            InitializeComponent();
        }
        private async void btn_Paquetes(object sender, EventArgs e) 
        {
            await Navigation.PushAsync(new Pagina_Paquetes());
        }

        private async void btn_Entradas(object sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new Pagina_Entrada());
        }
    }
}