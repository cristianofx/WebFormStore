using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsStore.Models;
using Microsoft.AspNet.Identity;
using System.IO;
using System.Globalization;

namespace WebFormsStore
{
    public partial class EditarProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetPerguntas();
            if (!IsPostBack)
            {
                //método para iniciar as peguntars
                


                int x = Int32.Parse(Request.QueryString["productID"]);

                //Pega a chave da conta do usuário logado
                string userKey = HttpContext.Current.User.Identity.GetUserId();
                //Instancia objeto de conexão com banco onde o perfil do usuário se encontra
                var _db_user = new ProdutoContexto();
                //Busca o perfil com a chave da conta do usuário
                IQueryable<Usuario> usuarioDB = _db_user.Usuarios.Where(u => u.IdentityLink == userKey);
                Usuario usuario = usuarioDB.FirstOrDefault();
                //Busca todos os produtos do usuário
                IQueryable<Produto> produtos = _db_user.Produtos.Where(p => p.UserID == usuario.UsuarioID);
                //Busca o produto específico da página com a chave productId
                produtos = produtos.Where(p => p.ProdutoID == x);
                Produto prod = produtos.FirstOrDefault();
                if (prod != null)
                {
                    if (!prod.vendido && !prod.bloqueado && !prod.desistiu)
                    {
                        vendidoOuBloqueadoBotaoEditar.Visible = true;
                        vendidoOuBloqueadoBotaoCancelar.Visible = true;
                    }
                    else
                    {
                        vendidoOuBloqueadoBotaoEditar.Visible = false;
                        vendidoOuBloqueadoBotaoCancelar.Visible = true;
                    }

                    if (prod.vendido)
                    {
                        LabelVendido.Visible = true;
                    }
                    if (prod.bloqueado || prod.desistiu)
                    {
                        LabelBloqueado.Visible = true;
                    }


                    dataExpiracao.Text = prod.DataExpiracao.ToString();
                    imagemUrl.Src = prod.ImagePath;
                    imagemUrl.Alt = prod.ProdutoNome;
                    //bizu para pegar dados em formato adequado para o textbox
                    decimal precoProd = decimal.Parse(prod.PrecoUnitario.ToString());
                    preco.Text = String.Format("{0, -10:C}", precoProd);
                    descricao.Text = prod.Descricao;
                    nome.Text = prod.ProdutoNome;
                    if (prod.bloqueado == true)
                    {
                        //Button button = (Button)productDetail.FindControl("botao_cancelar");
                        botao_cancelar.Visible = false;
                    }
                }
            }
        }

        public string getCurrentLoggedUser2()
        {
            //teste para pegar o email do usuário logado
            var db = new WebFormsStore.Models.ApplicationDbContext();
            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);
            return currentUser.Email.ToString();
        }

        //query para pegar o produto:
        public IQueryable<Produto> GetProduct([QueryString("productID")] int? productId)
        {

            //Pega a chave da conta do usuário logado
            string userKey = HttpContext.Current.User.Identity.GetUserId();
            //Instancia objeto de conexão com banco onde o perfil do usuário se encontra
            var _db_user = new ProdutoContexto();
            //Busca o perfil com a chave da conta do usuário
            IQueryable<Usuario> usuarioDB = _db_user.Usuarios.Where(u => u.IdentityLink == userKey);
            Usuario usuario = usuarioDB.FirstOrDefault();
            //Busca todos os produtos do usuário
            IQueryable<Produto> produtos = _db_user.Produtos.Where(p => p.UserID == usuario.UsuarioID);
            //Busca o produto específico da página com a chave productId
            produtos = produtos.Where(p => p.ProdutoID == productId);
            return produtos;

        }

        //método para fazer upload da imagem
        protected string UploadButton_Click2(object sender, EventArgs e)
        {
            //FileUpload FileUploadControl = (FileUpload)productDetail.FindControl("FileUploadControl");
            //Label StatusLabel = (Label)productDetail.FindControl("StatusLabel");

            string diretorioDoUsuario = "";

            if (FileUploadControl.HasFile)
            {
                try
                {
                    if (FileUploadControl.PostedFile.ContentType == "image/jpeg")
                    {
                        if (FileUploadControl.PostedFile.ContentLength < 16777216)
                        {

                            string filename = Path.GetFileName(FileUploadControl.FileName);
                            if (!Directory.Exists(Server.MapPath("~/Images/" + getCurrentLoggedUser2()) + "/"))
                            {
                                Directory.CreateDirectory(Server.MapPath("~/Images/" + getCurrentLoggedUser2()) + "/");
                            }
                            FileUploadControl.SaveAs(Server.MapPath("~/Images/" + getCurrentLoggedUser2()) + "/" + filename);
                            diretorioDoUsuario = "/Images/" + getCurrentLoggedUser2() + "/" + filename;
                            StatusLabel.Text = "Imagem enviada com sucesso!";
                        }
                        else
                            StatusLabel.Text = "O arquivo deve ser menor do que 2 MB!";
                    }
                    else
                        StatusLabel.Text = "Apenas arquivos JPEG são permitidos.";
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "O arquivo não pode ser enviado. Mensagem de erro: " + ex.Message;
                }
            }
            else
            {
                diretorioDoUsuario = "/Images/semImagem.gif";
            }

            return diretorioDoUsuario;
        }

        //edita o produto no banco de dados
        public void editarProduto(object sender, EventArgs e)
        {
            string idBrowser = Request.QueryString["productID"];
            int productId = Int32.Parse(idBrowser);

            var _db = new ProdutoContexto();
            IQueryable<Produto> prod = _db.Produtos.Where(p => p.ProdutoID == productId);
            Produto produto = prod.FirstOrDefault();

            string precoString = preco.Text;
            precoString = precoString.Substring(3);

            // This is invariant
            NumberFormatInfo format = new NumberFormatInfo();
            // Set the 'splitter' for thousands
            format.NumberGroupSeparator = ".";
            // Set the decimal seperator
            format.NumberDecimalSeparator = ",";

            double precoFinal = double.Parse(precoString, format);

            //try
            //{
                if (FileUploadControl.HasFile)
                {
                    string imagem = UploadButton_Click2(sender, e);
                    produto.ImagePath = imagem;
                }

                produto.ProdutoNome = nome.Text;
                produto.CategoriaID = Int32.Parse(DropDownList1.SelectedItem.Value); //adicionar controle de categorias
                produto.PrecoUnitario = precoFinal;
                produto.Descricao = descricao.Text;

                _db.Entry(produto).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();

                Response.Redirect("~/adicionado?sucesso=sim", false);
                Context.ApplicationInstance.CompleteRequest();
            //}
            //catch
            //{
            //    Response.Redirect("~/adicionado?sucesso=nao");
            //}


        }

        public void cancelarProduto(object sender, EventArgs e)
        {
            int productId = Int32.Parse(Request.QueryString["productID"]);
            //Pega a chave da conta do usuário logado
            string userKey = HttpContext.Current.User.Identity.GetUserId();
            //Instancia objeto de conexão com banco onde o perfil do usuário se encontra
            var _db = new ProdutoContexto();
            //Busca o perfil com a chave da conta do usuário
            IQueryable<Usuario> usuarioDB = _db.Usuarios.Where(u => u.IdentityLink == userKey);
            Usuario usuario = usuarioDB.FirstOrDefault();
            //Busca todos os produtos do usuário
            IQueryable<Produto> produtos = _db.Produtos.Where(p => p.UserID == usuario.UsuarioID);
            //Busca o produto específico da página com a chave productId
            produtos = produtos.Where(p => p.ProdutoID == productId);
            Produto prod = produtos.FirstOrDefault();
            prod.desistiu = true;
            _db.Entry(prod).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
            Response.Redirect(Request.RawUrl);

        }


        public IQueryable<Categoria> GetCategories()
        {
            var _db = new WebFormsStore.Models.ProdutoContexto(); //cria conexão com banco
            IQueryable<Categoria> query = _db.Categorias;
            return query;
        }


        public void GetPerguntas()
        {
            string idBrowser = Request.QueryString["productID"];
            int productId = Int32.Parse(idBrowser);
            //Panel panel = (Panel)productDetail.FindControl("perguntas");

            var _db = new WebFormsStore.Models.ProdutoContexto();
            IQueryable<Pergunta> query = _db.perguntas;
            if (idBrowser != null && productId > 0)
            {
                query = query.Where(p => p.ProdutoID == productId);
            }
            else
            {
                query = null;
            }
            foreach (Pergunta pergunta in query)
            {
                Label label = new Label();
                TextBox textBox = new TextBox();
                panel.Controls.Add(new LiteralControl("<h5>Pergunta:</h5> &nbsp;"));
                textBox.ID = pergunta.PerguntaID.ToString();
                label.Text = pergunta.PerguntaFeita;
                panel.Controls.Add(label);
                panel.Controls.Add(new LiteralControl("<br />"));
                panel.Controls.Add(new LiteralControl("<h5>Resposta:</h5> &nbsp;"));
                if (pergunta.Resposta == null)
                {
                    panel.Controls.Add(textBox);
                }
                else
                {
                    label = new Label();
                    label.Text = pergunta.Resposta;
                    panel.Controls.Add(label);
                }
            }
            query = query.Where(p => p.Resposta == null);
            if (query.Count() > 0)
            {
                panel.Controls.Add(new LiteralControl("<br />"));
                panel.Controls.Add(new LiteralControl("<br />"));
                Button button = new Button();
                button.Text = "Responder";
                button.ID = "SalvaResposta";
                button.ControlStyle.CssClass = "btn btn-primary";
                button.Click += new EventHandler(salvaPerguntas);
                panel.Controls.Add(button);
            }
        }

        private void salvaPerguntas(object sender, EventArgs e)
        {

            var _db = new ProdutoContexto();


            //Panel panel = (Panel)productDetail.FindControl("perguntas");
            foreach (Control c in panel.Controls)
            {
                if (c is TextBox)
                {
                    TextBox t = (TextBox)c;
                    int idPanel = Int32.Parse(c.ID);
                    IQueryable<Pergunta> pergunta = _db.perguntas.Where(p => p.PerguntaID == idPanel);
                    Pergunta perg = pergunta.FirstOrDefault();
                    perg.Resposta = t.Text;
                    _db.Entry(perg).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                    Response.Redirect(Request.RawUrl);
                }
            }

        }


    }
}