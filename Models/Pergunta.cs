using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace WebFormsStore.Models
{
    public class Pergunta
    {
        [ScaffoldColumn(false)]
        public int PerguntaID { get; set; }

        public int ProdutoID { get; set; }

        [Required, StringLength(10000), Display(Name = "Pergunta sobre o produto"), DataType(DataType.MultilineText)]
        public string PerguntaFeita { get; set; }

        [StringLength(10000), Display(Name = "Resposta do usuário"), DataType(DataType.MultilineText)]
        public string Resposta { get; set; }

        public Produto Produto { get; set; }
    }
}
