using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Parameter.Response
{
    public class CreditConsult
    {
        public bool PossuiDividasEmpresa { get; set; }
        public bool PossuiDividasSerasa { get; set; }
        public decimal ValorDisponivel { get; set; }
    }
}
