using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsStore.Models;
using Microsoft.AspNet.Identity;

namespace WebFormsStore
{
    public partial class MeusProdutos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public IQueryable<Produto> GetProducts()
        {
            string userKey = HttpContext.Current.User.Identity.GetUserId();
            var _db = new ProdutoContexto();
            IQueryable<Usuario> usuarioDB = _db.Usuarios.Where(u => u.IdentityLink == userKey);
            Usuario usuario = usuarioDB.FirstOrDefault();
            IQueryable<Produto> produtos = _db.Produtos.Where(p => p.UserID == usuario.UsuarioID);
            return produtos;
        }
    }
}