﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebFormsStore.Models
{
    public class Endereco
    {
        public int EnderecoID { get; set; }

        public string Rua {get ; set;}

        public string Numero {get ; set;}

        public string Complemento {get ; set;}

        public string Cep {get ; set;}

        public string Cidade { get; set; }

        public string Bairro { get; set; }


    }
}
