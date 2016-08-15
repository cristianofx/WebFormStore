using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WebFormsStore.Models;
using Microsoft.AspNet.Identity.EntityFramework;


namespace WebFormsStore.Models
{
    public class Usuario
    {
        [ScaffoldColumn(false)]
        public int UsuarioID { get; set; }

        
        [Required, StringLength(100), Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required, StringLength(100), Display(Name = "Sobrenome")]
        public string Sobrenome { get; set; }

        [StringLength(11), Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Required, StringLength(100), Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(20), Display(Name = "Telefone")]
        public string Telefone { get; set; }

        public DateTime DataNascimento { get; set; }

        public int? EnderecoID { get; set; }

        public Endereco Endereco { get; set; }

        [Required, StringLength(100), Display(Name = "IdentityLink")]
        public string IdentityLink { get; set; }

        public virtual ICollection<ResenhaUsuario> ResenhasUsuario { get; set; }

        public int? ProdutoID { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }

        public virtual ICollection<Produto> ProdutosComprados { get; set; }

        public virtual ICollection<OrdemDeCompra> OrdensDeCompra { get; set; }

    }
}