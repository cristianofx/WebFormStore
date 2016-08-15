using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsStore.Models;
using System.Web.ModelBinding;
using System.Data.Entity.Validation;
using Microsoft.AspNet.Identity;

namespace WebFormsStore
{
    public partial class DetalhesProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        //    int? prodID = null;
        //    try
        //    {
        //        prodID = int.Parse(Request.QueryString["productID"]);
        //    }
        //    catch
        //    {
        //        prodID = null;
        //    }


        //    var _db = new ProdutoContexto();
        //    Produto produto = _db.Produtos.Where(p => p.ProdutoID == prodID).FirstOrDefault();


        //    if (HttpContext.Current.User.IsInRole("SiteAdmin") && !produto.vendido)
        //    {
        //        Apagar.Visible = true;
        //    }
        }

        //query para buscar categorias do banco
        public IQueryable<Categoria> GetCategories()
        {
            var _db = new WebFormsStore.Models.ProdutoContexto(); //cria conexão com banco
            IQueryable<Categoria> query = _db.Categorias;
            return query;
        }

        //query para pegar o produto:
        public IQueryable<Produto> GetProduct([QueryString("productID")] int? productId)
        {
            var _db = new WebFormsStore.Models.ProdutoContexto();
            IQueryable<Produto> query = _db.Produtos;
            if (productId.HasValue && productId > 0)
            {
                query = query.Where(p => p.ProdutoID == productId);
            }
            else
            {
                query = null;
            }

            Produto produto = query.FirstOrDefault();
            if (produto.DataExpiracao < new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day))
            {
                produto.bloqueado = true;
                _db.Entry(produto).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                query = query.Where(p => p.ProdutoID == productId);
            }


            return query;
        }

        public IQueryable<Pergunta> GetPerguntas([QueryString("productID")] int? productId)
        {
            var _db = new WebFormsStore.Models.ProdutoContexto();
            IQueryable<Pergunta> query = _db.perguntas;
            if (productId.HasValue && productId > 0)
            {
                query = query.Where(p => p.ProdutoID == productId);
            }
            else
            {
                query = null;
            }
            return query;
        }



        
        public void SetPergunta(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)viewLoged.FindControl("txtPergunta");

            string v = Request.QueryString["productID"];
            int? productID = Int32.Parse(v);
            if (productID.HasValue && productID > 0)
            {
                try
                {
                    Pergunta pergunta = new Pergunta();
                    pergunta.PerguntaFeita = textBox.Text;
                    pergunta.ProdutoID = (int)productID;
                  

                    //novo contexto de conexão
                    var _db = new WebFormsStore.Models.ProdutoContexto();

                    _db.perguntas.Add(pergunta);
                    _db.SaveChanges();
                    Response.Redirect(Request.RawUrl);
                }
                catch (DbEntityValidationException ex)
                {
                    // Retrieve the error messages as a list of strings.
                    var errorMessages = ex.EntityValidationErrors
                            .SelectMany(x => x.ValidationErrors)
                            .Select(x => x.ErrorMessage);

                    // Join the list to a single string.
                    var fullErrorMessage = string.Join("; ", errorMessages);

                    // Combine the original exception message with the new one.
                    var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                    // Throw a new DbEntityValidationException with the improved exception message.
                    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                }
            }
        }

        public void getLoggedUser()
        {
            //teste para pegar o email do usuário logado
            var db = new WebFormsStore.Models.ApplicationDbContext();
            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);
            Label labelNome = (Label)productDetail.FindControl("nomeVendedor");
            labelNome.Text = currentUser.Email.ToString();
        }

        public void apagarProduto(object sender, EventArgs e)
        {
            int? prodID = null;
            try
            {
                prodID = int.Parse(Request.QueryString["productID"]);
            }
            catch
            {
                prodID = null;
            }

            if (prodID != null)
            {
                try
                {
                    var _db = new ProdutoContexto();
                    Produto produto = _db.Produtos.Where(p => p.ProdutoID == prodID).FirstOrDefault();
                    _db.Produtos.Remove(produto);
                    _db.SaveChanges();
                    Response.Redirect("~/apagado?sucesso=sim", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch
                {
                    Response.Redirect("~/apagado?sucesso=não");
                }
            }


        }

    }
}