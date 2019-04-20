namespace Helpers
{
    public class CpfHelper
    {
        public static string IsValid(string cpf)
        {
            if (cpf.Length != 11)
            {
                return "CPF Inválido! O CPF deve conter 11 caracteres.";
            }

            if (!int.TryParse(cpf, out int NovoCpf))
            {
                return "CPF Inválido! O CPF deve conter apenas números.";
            }

            return "OK";
        }
    }
}
