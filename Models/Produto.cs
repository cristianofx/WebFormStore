using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebFormsStore.Models
{
    public class Produto
    {
        [ScaffoldColumn(false)]
        public int ProdutoID { get; set; }

        [Required, StringLength(100), Display(Name = "Nome")]
        public string ProdutoNome { get; set;}

        [Required, StringLength(10000), Display(Name = "Descrição do Produto"), DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        [Display(Name = "Preço")]
        public double PrecoUnitario { get; set; }

        public string ImagePath { get; set; }

        public bool vendido { get; set; }

        public bool bloqueado { get; set; }

        public bool desistiu { get; set; }

        [Display(Name = "Oferta válida até")]
        public DateTime? DataExpiracao { get; set; }

        public int CategoriaID { get; set; }

        public int UserID { get; set; }

        public string emailUser { get; set; }

        public virtual Categoria Categoria { get; set; }

        public virtual ICollection<Pergunta> Perguntas { get; set; }

        public virtual ICollection<ResenhaProduto> ResenhasProduto { get; set; }
    }
}