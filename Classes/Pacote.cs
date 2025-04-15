using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMobileEscolaDanca.Classes
{
    public class Pacote
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Duracao { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal Valor { get; set; }
    }
}
