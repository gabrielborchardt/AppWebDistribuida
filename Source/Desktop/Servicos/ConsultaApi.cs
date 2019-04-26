using Desktop.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Servicos
{
    public class ConsultaApi
    {
        //private static readonly string _baseUrl = "http://192.168.100.86/Aps/Api";
        private static readonly string _baseUrl = ConfigurationManager.AppSettings["Api"];

        public static Mensagem Login(Usuario usuario)
        {
            var url = _baseUrl + "/authentication";

            var loginBase64 = Helpers.Base64Helper.Base64Encode(usuario.email + ":" + usuario.senha);

            var mensagem = new Mensagem();

            try
            {
                using (var api = new HttpClient())
                {
                    api.DefaultRequestHeaders.Add("Authorization", "Basic " + loginBase64);
                    var apiResult = api.PostAsync(url, null).Result;

                    switch (apiResult.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            mensagem.usuario = usuario;
                            mensagem.usuario.authenticationKey = apiResult.Content.ReadAsStringAsync().Result;
                            break;
                        default:
                            mensagem.usuario = null;
                            mensagem.mensagem = apiResult.Content.ReadAsStringAsync().Result;
                            break;
                    }
                }

                return mensagem;
            }
            catch (WebException wex)
            {

                mensagem.usuario = null;
                mensagem.mensagem = wex.Message;
            }

            return mensagem;
        }

        public static Models.Parameter.Response.FreightConsult BuscarFrete(Usuario usuario, string cep, decimal peso, decimal tamanho, ref string result)
        {
            var url = _baseUrl + "/freight/consult?";
            url += $"cep={cep}&";
            url += $"tamanho={tamanho.ToString().Replace(".", "").Replace(",", ".")}&";
            url += $"peso={peso.ToString().Replace(".", "").Replace(",", ".")}";

            try
            {
                using (var api = new HttpClient())
                {
                    api.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", usuario.authenticationKey);
                    api.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

                    var apiResult = api.GetAsync(url).Result;

                    switch (apiResult.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            var json = apiResult.Content.ReadAsStringAsync().Result;
                            return JsonConvert.DeserializeObject<Models.Parameter.Response.FreightConsult>(json);
                        default:
                            throw new Exception("Erro ao consultar CPF: " + apiResult.Content.ReadAsStringAsync().Result);
                    }

                }
            }
            catch (Exception wex)
            {
                result = wex.Message;
                return null;
            }
        }

        public static Models.Parameter.Response.CreditConsult BuscarFinanceiro(Usuario usuario, string cpf, ref string result)
        {
            var url = _baseUrl + "/credit/consult?";
            url += $"cpf={cpf}&";

            try
            {
                using (var api = new HttpClient())
                {
                    api.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", usuario.authenticationKey);
                    api.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

                    var apiResult = api.GetAsync(url).Result;

                    switch (apiResult.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            var json = apiResult.Content.ReadAsStringAsync().Result;
                            return JsonConvert.DeserializeObject<Models.Parameter.Response.CreditConsult>(json);
                        default:
                            throw new Exception("Erro ao consultar CPF: " + apiResult.Content.ReadAsStringAsync().Result);
                    }

                }
            }
            catch (Exception wex)
            {
                result = wex.Message;
                return null;
            }
        }
    }
}
