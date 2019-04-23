using Newtonsoft.Json;
using Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Models.Parameter.Response;
using Mobile.Models;

namespace Mobile.Servico
{
    public class ConsultaApi
    {
        private static readonly string _baseUrl = "https://localhost:44322";

        public async static Task<Mensagem> Login(Usuario usuario)
        {
            var url = _baseUrl + "/authentication";

            var loginBase64 = Helpers.Base64Helper.Base64Decode(usuario.email + ":" + usuario.senha);

            var parameters = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string,string>("Authorization",loginBase64),
            });

            var request = new HttpClient();

            var response = await request.PostAsync(url, parameters);

            var mensagem = new Mensagem();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var conteudo = await response.Content.ReadAsStringAsync();

                mensagem.usuario = usuario;
                mensagem.usuario.authenticationKey = conteudo;

                return mensagem;
            }
            else
            {

                var conteudo = await response.Content.ReadAsStringAsync();

                mensagem.mensagem = conteudo;
                mensagem.usuario = null;
            }

            return null;
        }

        public static FreightConsult BuscarFrete(string origem, string destino, decimal peso, decimal tamanho)
        {
            var parameters = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("origem", origem),
                new KeyValuePair<string, string>("destino", destino),
                new KeyValuePair<string, string>("peso", peso.ToString()),
                new KeyValuePair<string, string>("peso", tamanho.ToString())
            });

            var urlFrete = _baseUrl + "/freight/consult";

            var request = new HttpClient();
            var response = request.PostAsync(urlFrete, parameters).GetAwaiter().GetResult();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var conteudo = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (conteudo != null)
                    return JsonConvert.DeserializeObject<FreightConsult>(conteudo);
            }

            return null;
        }

        public static Financeiro BuscarFinanceiro(string cpf)
        {
            var parameters = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("origem", cpf)
            });

            var urlFrete = _baseUrl + "/financeiro";

            var request = new HttpClient();
            var response = request.PostAsync(urlFrete, parameters).GetAwaiter().GetResult();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var conteudo = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (conteudo != null)
                    return JsonConvert.DeserializeObject<Financeiro>(conteudo);
            }

            return null;
        }
    }
}
