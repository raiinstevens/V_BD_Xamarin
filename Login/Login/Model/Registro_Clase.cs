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
    }

    internal class Login_Clase
    {
        public string username { get; set; }

        public string password { get; set; }

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

    public class AppSettings
    {
        private static AppSettings _instance;

        public static AppSettings Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AppSettings();

                return _instance;
            }
        }

        private string _entryValue;

        public string email
        {
            get { return _entryValue; }
            set { _entryValue = value; }
        }
    }


}
