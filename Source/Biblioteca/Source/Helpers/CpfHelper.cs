using System;

namespace Helpers
{
    public class CpfHelper
    {
        public static string IsValid(string cpf)
        {

            if (cpf == null)
            {
                return "Informe o CPF.";
            }

            if (cpf.Length != 11)
            {
                return "CPF Inválido! O CPF deve conter 11 caracteres.";
            }

            if (!Int64.TryParse(cpf, out Int64 NovoCpf))
            {
                return "CPF Inválido! O CPF deve conter apenas números.";
            }

            return "OK";
        }
    }
}
