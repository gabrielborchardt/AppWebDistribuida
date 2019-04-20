namespace Models
{
    public class Frete
    {
        public string cepOrigem { get; set; }

        public string cepDestino { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }

        public decimal valor { get; set; }
        public int tempo { get; set; } //Em dias
    }
}
