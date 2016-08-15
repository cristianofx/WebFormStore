using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebFormsStore.Models
{
    public class ItemCarrinho
    {

        [Key]
        public string ItemId { get; set; }

        public string CarrinhoId { get; set; }

        public int Quantidade { get; set; }

        public System.DateTime DataCriado { get; set; }

        public int ProdutoId { get; set; }

        public virtual Produto Produto { get; set; }
    }
}