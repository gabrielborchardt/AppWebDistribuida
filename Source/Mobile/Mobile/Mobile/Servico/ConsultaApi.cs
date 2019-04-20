using Newtonsoft.Json;
using Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mobile.Servico
{
    public class ConsultaApi
    {
        private static readonly string _baseUrl = "https://localhost/apiAps";

        public async static Task<Usuario> Login(Usuario usuario)
        {
            var url = _baseUrl + "/usuario";

            var parameters = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string,string>("email",usuario.email),
                new KeyValuePair<string,string>("password",usuario.senha),
            });

            var request = new HttpClient();

            var response = await request.PostAsync(url, parameters);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var conteudo = await response.Content.ReadAsStringAsync();

                if (conteudo != null)
                    if (conteudo.Length > 2)
                        return JsonConvert.DeserializeObject<Usuario>(conteudo);

            }

            return null;
        }

        public static Frete BuscarFrete(string origem, string destino, decimal peso)
        {
            var parameters = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("origem", origem),
                new KeyValuePair<string, string>("destino", destino),
                new KeyValuePair<string, string>("peso", peso.ToString())
            });

            var urlFrete = _baseUrl + "/frete";

            var request = new HttpClient();
            var response = request.PostAsync(urlFrete, parameters).GetAwaiter().GetResult();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var conteudo = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (conteudo != null)
                    return JsonConvert.DeserializeObject<Frete>(conteudo);
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
