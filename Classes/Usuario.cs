using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppMobileEscolaDanca.Classes
{
    public class Usuario
    {
        [JsonPropertyName("userIdFirebase")]
        public string UserIdFirebase { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("cpf")]
        public string CPF { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("telefone")]
        public string Telefone { get; set; }

        [JsonPropertyName("dataNascimento")]
        public DateTime DataNascimento { get; set; }


        public string ValidarCampos(string senha, string confirmarSenha)
        {
            var mensagemErro = new StringBuilder();

            if (string.IsNullOrEmpty(Nome)) mensagemErro.AppendLine("O campo 'Nome' está vazio ou nulo.");
            if (string.IsNullOrEmpty(CPF)) mensagemErro.AppendLine("O campo 'CPF' está vazio ou nulo.");
            if (string.IsNullOrEmpty(Email)) mensagemErro.AppendLine("O campo 'Email' está vazio ou nulo.");
            if (string.IsNullOrEmpty(Telefone)) mensagemErro.AppendLine("O campo 'Telefone' está vazio ou nulo.");
            if (string.IsNullOrEmpty(senha)) mensagemErro.AppendLine("O campo 'Senha' está vazio ou nulo.");
            if (string.IsNullOrEmpty(confirmarSenha)) mensagemErro.AppendLine("O campo 'Confirmar' está vazio ou nulo.");

            if (senha != confirmarSenha)
                mensagemErro.AppendLine("As senhas não coincidem.");

            return mensagemErro.ToString();
        }




    }


}
