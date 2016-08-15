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
    public partial class DetalhesUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.IsInRole("SiteAdmin"))
            {
                painel.Visible = true;
                getDetailsProducts();
            }
        }

        public IQueryable<Usuario> getUser([QueryString("userID")] int? userID)
        {
            var _db = new ProdutoContexto();
            IQueryable<Usuario> usuarioDB = _db.Usuarios.Where(u => u.UsuarioID == userID);
            return usuarioDB;
        }


        public IQueryable<Endereco> getEndereco([QueryString("userID")] int? userID)
        {
            var _db = new ProdutoContexto();
            IQueryable<Usuario> usuarioDB = _db.Usuarios.Where(u => u.UsuarioID == userID);
            Usuario usuario = usuarioDB.FirstOrDefault();
            IQueryable<Endereco> endereco = _db.Enderecos.Where(e => e.EnderecoID == usuario.EnderecoID);
            return endereco;
        }

        public void getDetailsProducts()
        {
            string userIDString = Request.QueryString["userID"];
            try
            {
                int userID = int.Parse(userIDString);
                var _db = new ProdutoContexto();
                IQueryable<Usuario> user = _db.Usuarios.Where(u => u.UsuarioID == userID);
                Usuario usuario = user.FirstOrDefault();
                IQueryable<Produto> produtos = _db.Produtos.Where(p => p.UserID == userID);
                quantidadeProdutos.Text = produtos.Count().ToString();
                double valorTotal = 0;
                foreach(Produto prod in produtos){
                    if (!prod.bloqueado && !prod.desistiu && !prod.vendido)
                    {
                        valorTotal += prod.PrecoUnitario;
                    }
                }
                TotalOfertado.Text = valorTotal.ToString();

            }
            catch
            {

            }
        }

        public class perguntaUser{
            public perguntaUser(){

            }

            public string ProdutoNome {get; set;}
            public string PerguntaFeita { get; set;}
            public string Resposta {get;set;}

        }

        public List<perguntaUser> GetPerguntas([QueryString("userID")] int? userID)
        {
            //cria a lista de perguntas
            List<Pergunta> listaPerguntas = new List<Pergunta>();

            //if (userID.HasValue && userID > 0)
            //{
                //conexão com banco
                var _db = new WebFormsStore.Models.ProdutoContexto();
                IQueryable<Produto> prodDB = _db.Produtos.Where(p => p.UserID == userID);
                List<perguntaUser> lista = _db.perguntas.Join(prodDB,
                    per => per.ProdutoID,
                    prod => prod.ProdutoID,
                    (per, prod) => new perguntaUser { ProdutoNome = prod.ProdutoNome, PerguntaFeita = per.PerguntaFeita, Resposta = per.Resposta }).ToList();

                return lista;
            //    //busca todos os produtos do usuário
            //    IQueryable<Produto> prodDB = _db.Produtos.Where(p => p.UserID == userID);
            //    //busca todas as perguntas do banco
            //    IQueryable<Pergunta> perguntas = _db.perguntas;
            //    //para cada produto
            //    List<Produto> listaProdutos = prodDB.ToList();
            //    List<Pergunta> listaPerguntasDB = perguntas.ToList();
            //    foreach (Produto prod in listaProdutos)
            //    {
            //        foreach (Pergunta perg in listaPerguntasDB) //passa por cada pergunta
            //        {
            //            if (perg.ProdutoID == prod.ProdutoID) //se achou pergunta do produto
            //            {
            //                listaPerguntas.Add(perg); //adiciona na lista
            //            }
            //        }
            //    }
                
            //}
            //else
            //{
            //    listaPerguntas = null;
            //}
            //return listaPerguntas;
        }

        public void loadDetalhesUsuario(object sender, EventArgs e)
        {
            string userID = Usuarios.SelectedItem.Value;
            string url = "/Admin/DetalhesUsuario.aspx?userID=" + userID;
            Response.Redirect(url);
        }

        public IQueryable<Usuario> getUsuarios()
        {
            var _db = new ProdutoContexto();
            IQueryable<Usuario> Usuario = _db.Usuarios;
            return Usuario;
        }

    }

}