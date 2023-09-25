using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Login.Model
{
    internal class Registro_Clase
    {
        public string nombre { get; set; }

        public string dni { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public string app { get; set; }

        public string apm { get; set; }

        public string targeta { get; set; }
    }

    internal class Login_Clase
    {
        public string username { get; set; }

        public string password { get; set; }

    }

    public class ApiResponse
    {
        public int id { get; set; }
        public string fullnombre { get; set; }
    }

    public class AppSettings
{
        private const string UserIdKey = "UserId";
        private const string FullNameKey = "FullName";

        public static AppSettings Instance { get; } = new AppSettings();

        public int UserId
        {
            get => Preferences.Get(UserIdKey, 0);
            set => Preferences.Set(UserIdKey, value);
        }

        public string FullName
        {
            get => Preferences.Get(FullNameKey, string.Empty);
            set => Preferences.Set(FullNameKey, value);
        }
    }

    internal class Entrada_Clase
    {
        public int id { get; set; }

        public string entrada_hora { get; set; }

        public string entrada_fecha { get; set; }

        public string entrada_lugar { get; set; }

        public string entrada_destino { get; set; }

        public string entrada_pais { get; set; }

    }


    

    internal class ComprarEntrada_Clase
    {
        public int entrada_id { get; set; }

        public string email { get; set; }

        public string asiento { get; set; }
    }

    internal class Paises
    {
        public int id { get; set; }

        public string nombre { get; set; }

    }

    public class Asiento
    {
        public int id { get; set; }
        public int asi_numero { get; set; }
        public int asi_estado { get; set; }
        public int vue_id { get; set; }
    }

    public class DatosVuelos
    {
        public int id { get; set; }
        public string vue_fecha { get; set; }
        public string vue_hora { get; set; }
        public string pais { get; set; }
        public int precio { get; set; }
        public int claseProbre { get; set; }
        public int claseProbreId { get; set; }
        public int claseVip { get; set; }
        public int claseVipId { get; set; }
        public int claseFachero { get; set; }
        public int claseFacheroId { get; set; }
        public List<Asiento> asientos { get; set; }
    }

    public class ComprarVuelo
    {
        public int vueloId { get; set; }
        public object paqueteId { get; set; }
        public int userId { get; set; }
        public int claseId { get; set; }
    }

    public class DatosPaquetes
    {
        public int id { get; set; }
        public string pais { get; set; }
        public int precio { get; set; }
        public double claseProbre { get; set; }
        public int claseProbreId { get; set; }
        public double claseVip { get; set; }
        public int claseVipId { get; set; }
        public double claseFachero { get; set; }
        public int claseFacheroId { get; set; }
        public string hot_ubicacion { get; set; }
        public string res_ubicacion { get; set; }
        public string tra_ubicacion { get; set; }
        public List<Asiento> asientos { get; set; }
    }

    public class ComprarPaquete
    {
        public object vueloId { get; set; }
        public int paqueteId { get; set; }
        public int userId { get; set; }
        public int claseId { get; set; }
    }
}
