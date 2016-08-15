using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsStore.Models;
using Microsoft.AspNet.Identity;
using System.Web.ModelBinding;

namespace WebFormsStore
{
    public partial class ProcuraPreco : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Categoria> GetCategories()
        {
            var _db = new WebFormsStore.Models.ProdutoContexto(); //cria conexão com banco
            IQueryable<Categoria> query = _db.Categorias;
            return query;
        }

        public IQueryable<Produto> GetProducts([QueryString("preco")] int? preco)
        {
            var _db = new WebFormsStore.Models.ProdutoContexto();
            IQueryable<Produto> produtos = _db.Produtos;
            if (preco.HasValue && preco > 0)
            {
                if (preco == 1)
                {
                    produtos = produtos.Where(p => p.PrecoUnitario < 10);
                }
                else if (preco == 2)
                {
                    produtos = produtos.Where(p => p.PrecoUnitario > 10 && p.PrecoUnitario < 100);
                }
                else if (preco == 3)
                {
                    produtos = produtos.Where(p => p.PrecoUnitario > 100 && p.PrecoUnitario < 1000);
                }
                else if (preco == 4)
                {
                    produtos = produtos.Where(p => p.PrecoUnitario > 1000);
                }
                else
                {
                    produtos = null;
                }


            }
            return produtos;
        }


        public IQueryable<Produto> GetSearch(string searchString)
        {
            var _db = new WebFormsStore.Models.ProdutoContexto();
            IQueryable<Produto> query = _db.Produtos;
            if (!String.IsNullOrEmpty(searchString))
            {
                query = query.Where(p => p.ProdutoNome.Contains(searchString) || p.Descricao.Contains(searchString));
            }
            return query;
        }

        public void procuraPorFaixaDepreco(object sender, EventArgs e)
        {
            if (precos.SelectedIndex > 0)
            {
                Response.Redirect("/ProcuraPreco?preco=" + precos.SelectedIndex);
            }
        }
    }
}