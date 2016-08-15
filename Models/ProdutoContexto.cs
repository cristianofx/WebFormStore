using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebFormsStore.Models
{
    //Classe que representa o contexto de Produto no Entity Framework
    //Essa classe lida com a busca, armazenamento e atualização da intancia de classe Produto no banco de dados
    public class ProdutoContexto : DbContext
    {

        public ProdutoContexto()
            : base("WebFormsStore")
        {
        }

        //Este contexto adiciona acesso aos itens do banco de dados

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pergunta> perguntas { get; set; }
        public DbSet<ResenhaProduto> ResenhasProduto { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ResenhaUsuario> ResenhasUsuario { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<ItemCarrinho> ItensDoCarrinho { get; set; }
        public DbSet<OrdemDeCompra> OrdensDeCompra { get; set; }
        public DbSet<DetalhesDaOrdemDeCompra> DetalhesDasOrdensDeCompra { get; set; }


        

    }
}