namespace Helpers
{
    public class CepHelper
    {
        public static string IsValid(string cep)
        {
            if (cep.Length != 8)
            {
                return "CEP Inválido! O CEP deve conter 8 caracteres.";
            }

            if (!int.TryParse(cep, out int NovoCep))
            {
                return "CEP Inválido! O CEP deve conter apenas números.";
            }

            return "OK";
        }
    }
}
