using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsStore.Models;

namespace WebFormsStore
{
    public partial class Gerenciar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (HttpContext.Current.User.IsInRole("SiteAdmin"))
                {
                    painel.Visible = true;
                    DropDownList1.SelectedIndex = -1;
                }
            }
        }


        protected void adicionaCategoria(object sender, EventArgs e)
        {
            Categoria categoria = new Categoria
            {
                CategoriaNome = NomeCategoria.Text,
                Descricao = DescricaoCategoria.Text
            };
            try
            {
                var _db = new ProdutoContexto();
                _db.Categorias.Add(categoria);
                _db.SaveChanges();
                NomeCategoria.Text = "";
                DescricaoCategoria.Text = "";
                resultado.Text = "Categoria " + categoria.CategoriaNome + " adicionado com sucesso.";
                resultado.CssClass = "alert alert-dismissible alert-success";
                resultado.Visible = true;
            }
            catch(Exception err)
            {
                resultado.Text = "Erro, categoria não adicionada. Mensagem de erro: " + err.Message;
                resultado.CssClass = "alert alert-dismissible alert-danger";
                resultado.Visible = true;
            }
        }

        public IQueryable<Categoria> GetCategories()
        {
            var _db = new WebFormsStore.Models.ProdutoContexto(); //cria conexão com banco
            IQueryable<Categoria> query = _db.Categorias;
            return query;
        }

        public void modificaCategoria(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex > 0)
            {
                try
                {
                    int CategoriaID = int.Parse(DropDownList1.SelectedItem.Value);
                    var _db = new ProdutoContexto();
                    Categoria categoria = new Categoria();
                    IQueryable<Categoria> categorias;
                    categorias = _db.Categorias.Where(c => c.CategoriaID == CategoriaID);
                    categoria = categorias.FirstOrDefault();
                    categoria.CategoriaNome = NomeCategoriaMudar.Text;
                    categoria.Descricao = DescricaoCategoriaMudar.Text;
                    _db.Entry(categoria).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                    ResultadoSalvar.Text = "Categoria " + categoria.CategoriaNome + " modificada com sucesso.";
                    ResultadoSalvar.CssClass = "alert alert-dismissible alert-success";
                    ResultadoSalvar.Visible = true;
                }
                catch (Exception err)
                {
                    ResultadoSalvar.Text = "Erro, categoria não modificada. Mensagem de erro: " + err.Message;
                    ResultadoSalvar.CssClass = "alert alert-dismissible alert-danger";
                    ResultadoSalvar.Visible = true;
                }
            }
        }

        public void loadCategoria(object sender, EventArgs e)
        {
            if (ResultadoSalvar.Visible == true)
            {
                ResultadoSalvar.Visible = false;
            }
            if (DropDownList1.SelectedIndex > 0)
            {
                int CategoriaID = int.Parse(DropDownList1.SelectedItem.Value);
                var _db = new ProdutoContexto();
                Categoria categoria = new Categoria();
                IQueryable<Categoria> categorias;
                categorias = _db.Categorias.Where(c => c.CategoriaID == CategoriaID);
                categoria = categorias.FirstOrDefault();
                NomeCategoriaMudar.Text = categoria.CategoriaNome;
                DescricaoCategoriaMudar.Text = categoria.Descricao;
            }
            else
            {
                NomeCategoriaMudar.Text = "";
                DescricaoCategoriaMudar.Text = "";
            }
        }

        public IQueryable<Usuario> GetSearch([QueryString("search")] string searchString)
        {
            string v = Request.QueryString["search"];
            var _db = new WebFormsStore.Models.ProdutoContexto();
            IQueryable<Usuario> usuario = _db.Usuarios;
            if (!String.IsNullOrEmpty(searchString))
            {
                usuario = usuario.Where(p => p.Nome.Contains(v) || p.Email.Contains(v));
                return usuario;
            }
            return null;
        }

    }
}