using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsStore.Models;
using System.Web.ModelBinding;


namespace WebFormsStore
{
    public partial class ListaProdutos : System.Web.UI.Page
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

        public IQueryable<Produto> GetProducts([QueryString("id")] int? categoryId)
        {
            var _db = new WebFormsStore.Models.ProdutoContexto();
            IQueryable<Produto> query = _db.Produtos;
            if (categoryId.HasValue && categoryId > 0)
            {
                query = query.Where(p => p.CategoriaID == categoryId);
            }
            return query;
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