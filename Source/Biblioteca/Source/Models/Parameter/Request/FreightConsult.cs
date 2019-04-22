using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Parameter.Request
{
    public class FreightConsult
    {
        public decimal Peso { get; set; }
        public decimal Tamanho { get; set; }
        public string CepOrigem { get; set; }
        public string CepDestino { get; set; }
    }
}
