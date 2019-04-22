using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Address
    {
        public string logradouro { get; set; }
        public string uf { get; set; }
        public string bairro { get; set; }
        public string cep { get; set; }
        public string localidade { get; set; }
        public string complemento { get; set; }
        public string ibge { get; set; }
        public string cidade { get; set; }
    }
}
