using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace WebFormsStore.Models
{
    public class ResenhaProduto
    {

        [ScaffoldColumn(false)]
        [Key]
        public int ResenhaID { get; set; }

        public int ProdutoID { get; set; }

        [Required, StringLength(10000), Display(Name = "Resenha do produto"), DataType(DataType.MultilineText)]
        public string ResenhaDoProduto { get; set; }

        public Produto Produto { get; set; }
    }
}
