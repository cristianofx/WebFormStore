using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsStore.Models;



namespace WebFormsStore
{
    public partial class Procura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Produto> GetSearch([QueryString("search")] string searchString)
        {
            string v = Request.QueryString["search"];
            var _db = new WebFormsStore.Models.ProdutoContexto();
            IQueryable<Produto> query = _db.Produtos;
            if (!String.IsNullOrEmpty(searchString))
            {
                query = query.Where(p => p.ProdutoNome.Contains(v) || p.Descricao.Contains(v));
            }
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

        public IQueryable<Categoria> GetCategories()
        {
            var _db = new WebFormsStore.Models.ProdutoContexto(); //cria conexão com banco
            IQueryable<Categoria> query = _db.Categorias;
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