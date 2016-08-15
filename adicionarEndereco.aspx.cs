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
    public partial class adicionarEndereco : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userKey = HttpContext.Current.User.Identity.GetUserId();
            var _db = new ProdutoContexto();
            IQueryable<Usuario> usuarioDB = _db.Usuarios.Where(u => u.IdentityLink == userKey);
            Usuario usuario = usuarioDB.FirstOrDefault();
            if (usuario.EnderecoID != null)
            {
                tudo.Visible = false;
            }
        }


        public void salvarEndereco(object sender, EventArgs e)
        {
            
            var _db = new ProdutoContexto();
            Endereco endereco = new Endereco
            {
                Rua = RuaBox.Text,
                Numero = NumeroBox.Text,
                Complemento = ComplementoBox.Text,
                Cep = CepBox.Text,
                Cidade = CidadeBox.Text,
                Bairro = BairroBox.Text
            };
            _db.Enderecos.Add(endereco);
            _db.SaveChanges();
            int id = endereco.EnderecoID; //pega o id do endereço gerado


            string userKey = HttpContext.Current.User.Identity.GetUserId();
            _db = new ProdutoContexto();
            IQueryable<Usuario> usuarioDB = _db.Usuarios.Where(u => u.IdentityLink == userKey);
            Usuario usuario = usuarioDB.FirstOrDefault();
            //adiciona o id do endereço no usuario e faz update no banco
            usuario.EnderecoID = id;
            _db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
            Response.Redirect("/Perfil.aspx");
        }
    }
}