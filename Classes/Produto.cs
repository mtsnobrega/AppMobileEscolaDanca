﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMobileEscolaDanca.Classes
{
    public class Produto
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public decimal ValorMensal { get; set; }
        public string NivelDificuldade { get; set; }
        public string DiaDaSemana { get; set; }
        public string Horario { get; set; }
        public string Professor { get; set; }
        public string ImagemUrl { get; set; }
        public string TipoPlano { get; set; }
        public string QtdAulas { get; set; }

    }
}
