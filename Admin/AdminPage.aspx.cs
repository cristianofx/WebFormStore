using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsStore.Models;

namespace WebFormsStore.Admin
{
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getNumeroProdutos();
            getBloqueados();
            getDesisti();
            getVendido();
            getUsuario();
            getExpirados();

            if (!Page.IsPostBack)
            {
                if (HttpContext.Current.User.IsInRole("SiteAdmin"))
                {
                    Usuarios.SelectedIndex = -1;
                }
            }
        }

        protected void getNumeroProdutos()
        {
            var _db = new ProdutoContexto();
            int x = _db.Produtos.Count();
            Label5.Text = x.ToString();
            
        }

        public IQueryable<Produto> getProdutosBloqueados()
        {
            var _db = new ProdutoContexto();
            IQueryable<Produto> Produtos = _db.Produtos;
            Produtos = Produtos.Where(p => p.bloqueado == true);
            return Produtos;
        }

        public IQueryable<Produto> getDesistiu()
        {
            var _db = new ProdutoContexto();
            IQueryable<Produto> Produto = _db.Produtos;
            Produto = Produto.Where(p => p.desistiu == true);
            return Produto;
        }

        public IQueryable<Produto> getVendidos()
        {
            var _db = new ProdutoContexto();
            IQueryable<Produto> Produto = _db.Produtos;
            Produto = Produto.Where(p => p.vendido == true);
            return Produto;
        }

        public IQueryable getUsuarios()
        {
            var _db = new ProdutoContexto();
            IQueryable<Usuario> Usuario = _db.Usuarios;

            IQueryable users = from p in _db.Usuarios
                        select new
                        {
                            UsuarioID = p.UsuarioID,
                            Nome = p.Nome + " " + p.Sobrenome
                        };
            
            return users;
        }

        public void getBloqueados()
        {
            var _db = new ProdutoContexto();
            IQueryable<Produto> prod = _db.Produtos.Where(p => p.bloqueado == true);
            Validade.Text = prod.Count().ToString();

        }

        public void getDesisti()
        {
            var _db = new ProdutoContexto();
            IQueryable<Produto> desis = _db.Produtos.Where(p => p.desistiu == true);
            Desistencia.Text = desis.Count().ToString();
        }

        public void getVendido()
        {
            var _db = new ProdutoContexto();
            IQueryable<Produto> venda = _db.Produtos.Where(p => p.vendido == true);
            Vendidos.Text = venda.Count().ToString();
        }

        public void getExpirados()
        {
            var _db = new ProdutoContexto();
            DateTime dataExp = DateTime.Now.AddDays(-1);
            IQueryable<Produto> expirados = _db.Produtos.Where(p => p.DataExpiracao < dataExp);
            ExpiradosLabel.Text = expirados.Count().ToString();
        }

        public void getUsuario()
        {
            var _db = new ProdutoContexto();
            IQueryable<Usuario> vend = _db.Usuarios.Where(u => true);
            NumVendedores.Text = vend.Count().ToString();
        }

        public void loadDetalhesUsuario(object sender, EventArgs e)
        {
            string userID = Usuarios.SelectedItem.Value;
            string url = "/Admin/DetalhesUsuario.aspx?userID=" + userID;
            Response.Redirect(url);
        }

    }
}