using System;
using System.Collections.Generic;
using System.Text;

namespace Mobile.Util
{
    public class ConfiguracaoUtil
    {
        public static void SetIpConexao(string ip)
        {
            App.Current.Properties["IP"] = ip;
        }

        public static string GetIpConexao()
        {
            if (App.Current.Properties.ContainsKey("IP"))
                return (string)App.Current.Properties["IP"];
            else
                return "";
        }
    }
}
