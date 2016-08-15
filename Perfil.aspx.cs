using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using WebFormsStore.Models;

namespace WebFormsStore
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            procuraEndereco();
        }

        public IQueryable<Usuario> getUser()
        {

            string userKey = HttpContext.Current.User.Identity.GetUserId();
            var _db = new ProdutoContexto();
            IQueryable<Usuario> usuarioDB = _db.Usuarios.Where(u => u.IdentityLink == userKey);
            return usuarioDB;

        }

        public Usuario getCurrentUser()
        {
            string userKey = HttpContext.Current.User.Identity.GetUserId();
            var _db = new ProdutoContexto();
            IQueryable<Usuario> usuarioDB = _db.Usuarios.Where(u => u.IdentityLink == userKey);
            Usuario usuario = usuarioDB.FirstOrDefault();
            return usuario;
        }

        public class ProdutosID{
            public ProdutosID(){

            }

            public int ProdutoID {get;set;}

        }

        public List<Produto> GetProducts()
        {
            //pega userID da conta do usuário logado
            string userKey = HttpContext.Current.User.Identity.GetUserId();
            var _db = new ProdutoContexto();
            //Pega o perfil do usuário logado
            IQueryable<Usuario> usuarioDB = _db.Usuarios.Where(u => u.IdentityLink == userKey);
            Usuario usuario = usuarioDB.FirstOrDefault();
            //Pega todas as ordens de compra do usuário logado
            IQueryable<OrdemDeCompra> minhasOrdens = _db.OrdensDeCompra.Where(o => o.UsuarioID == usuario.UsuarioID);
            //pega cada ProdutoID de todos os detalhes de todas as compras do usuário
            List<ProdutosID> produtosID = _db.DetalhesDasOrdensDeCompra.Join(minhasOrdens,
                d => d.OrdemDeCompraID,
                o => o.OrdemDeCompraID,
                (d, o) => new ProdutosID { ProdutoID = d.ProdutoID }).ToList(); ;

            List<Produto> meusProdutosComprados = new List<Produto>();

            foreach (ProdutosID prod in produtosID)
            {
                meusProdutosComprados.Add(_db.Produtos.Where(p => p.ProdutoID == prod.ProdutoID).FirstOrDefault());
            }
            return meusProdutosComprados;

        }

        public void procuraEndereco()
        {
            Usuario usuario = getCurrentUser();
            if (usuario.EnderecoID == null)
            {
                addEndLink.Visible = true;
            }
            else
            {
                addEndLink.Visible = false;
            }
        }

        public IQueryable<Endereco> getEndereco()
        {
            var _db = new ProdutoContexto();
            Usuario usuario = getCurrentUser();
            IQueryable<Endereco> endereco = _db.Enderecos.Where(e => e.EnderecoID == usuario.EnderecoID);
            return endereco;
        }

    }
}