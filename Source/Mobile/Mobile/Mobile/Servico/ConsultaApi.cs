using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;
using System;
using Mobile.Model;
using System.Text;

namespace Mobile.Servico
{
    public class ConsultaApi
    {
        private static readonly string _baseUrl = "http://192.168.100.86/Aps/Api";

        public static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

            return pingable;
        }

        public async static Task<Mensagem> Login(Usuario usuario)
        {

            PingHost("192.168.100.86");

            var url = _baseUrl + "/authentication";

            var loginBase64 = Helpers.Base64Helper.Base64Encode(usuario.email + ":" + usuario.senha);

            var mensagem = new Mensagem();

            try
            {
                using (var api = new HttpClient { BaseAddress = new Uri(url) })
                {
                    api.DefaultRequestHeaders.Add("Authorization", "Basic " + loginBase64);
                    var apiResult = await api.PostAsync(api.BaseAddress, null);

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

        public static async Task<Models.Parameter.Response.FreightConsult> BuscarFrete(string origem, string destino, decimal peso, decimal tamanho)
        { 
            var url = _baseUrl + "/freight/consult";

            var usuario = Util.UsuarioUtil.GetUsuarioLogado();

            var frete = new Models.Parameter.Request.FreightConsult()
            {
                CepOrigem = origem,
                CepDestino = destino,
                Peso = peso,
                Tamanho = tamanho
            };

            var json = JsonConvert.SerializeObject(frete);

            try
            {
                using (var api = new HttpClient { BaseAddress = new Uri(url) })
                {
                    api.DefaultRequestHeaders.Add("Authorization", usuario.authenticationKey);
                    var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                    var apiResult = await api.PostAsync(api.BaseAddress, httpContent);

                    switch (apiResult.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            var result = apiResult.Content.ReadAsStringAsync().Result;
                            return JsonConvert.DeserializeObject<Models.Parameter.Response.FreightConsult>(result);
                        default:
                            return null;
                    }
                }
            }
            catch (Exception wex)
            {
                return null;
            }
        }

        public static async Task<Models.Parameter.Response.CreditConsult> BuscarFinanceiro(string cpf)
        {
            var url = _baseUrl + "/credit/consult";

            var usuario = Util.UsuarioUtil.GetUsuarioLogado();

            var credit = new Models.Parameter.Request.CreditConsult()
            {
                Cpf = cpf
            };

            var json = JsonConvert.SerializeObject(credit);

            try
            {
                using (var api = new HttpClient { BaseAddress = new Uri(url) })
                {
                    api.DefaultRequestHeaders.Add("Authorization", usuario.authenticationKey);
                    var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                    var apiResult = api.PostAsync(api.BaseAddress, httpContent).Result;

                    switch (apiResult.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            var result = apiResult.Content.ReadAsStringAsync().Result;
                            return JsonConvert.DeserializeObject<Models.Parameter.Response.CreditConsult>(result);
                        default:
                            return null;
                    }
                }
            }
            catch (Exception wex)
            {
                return null;
            }
        }
    }
}
