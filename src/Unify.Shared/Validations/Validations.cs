using System.Linq;
using System.Text.RegularExpressions;

namespace Unify.Shared.Validations
{
    public class Validations
    {
        #region Telefone
        public static bool ValidaFone(string telefone)
        {
            if (string.IsNullOrWhiteSpace(telefone))
                return false;

            // Remove tudo que não for número
            var numeros = Regex.Replace(telefone, @"\D", "");

            // Remove código do país se existir
            if (numeros.StartsWith("55") && numeros.Length > 11)
                numeros = numeros.Substring(2);

            // Telefones válidos possuem 10 (fixo) ou 11 (celular) dígitos
            if (numeros.Length != 10 && numeros.Length != 11)
                return false;

            // Rejeita números com todos os dígitos iguais
            if (numeros.All(c => c == numeros[0]))
                return false;

            // Validação do DDD
            var ddd = int.Parse(numeros.Substring(0, 2));
            if (!IsDddValido(ddd))
                return false;

            // Validação celular
            if (numeros.Length == 11)
            {
                // Terceiro dígito deve ser 9
                if (numeros[2] != '9')
                    return false;
            }
            else
            {
                // Terceiro dígito entre 2 e 5
                var terceiroDigito = numeros[2];
                if (terceiroDigito < '2' || terceiroDigito > '5')
                    return false;
            }

            return true;
        }

        private static bool IsDddValido(int ddd)
        {
            int[] dddsValidos =
            {
                11,12,13,14,15,16,17,18,19,
                21,22,24,
                27,28,
                31,32,33,34,35,37,38,
                41,42,43,44,45,46,
                47,48,49,
                51,53,54,55,
                61,
                62,64,
                63,
                65,66,
                67,
                68,
                69,
                71,73,74,75,77,
                79,
                81,87,
                82,
                83,
                84,
                85,88,
                86,89,
                91,93,94,
                92,97,
                95,
                96,
                98,99
            };

            return dddsValidos.Contains(ddd);
        }

        #endregion

        #region CEP
        public static bool ValidaCep(string cep)
        {
            if (string.IsNullOrWhiteSpace(cep))
                return false;

            // Remove tudo que não for número
            var numeros = Regex.Replace(cep, @"\D", "");

            // CEP deve ter exatamente 8 dígitos
            if (numeros.Length != 8)
                return false;

            // Rejeita CEPs com todos os dígitos iguais
            if (numeros.All(c => c == numeros[0]))
                return false;

            return true;
        }
        #endregion
    }
}
