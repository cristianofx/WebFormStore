using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsStore.Models;
using Microsoft.AspNet.Identity;
using System.IO;
using System.Globalization;


namespace WebFormsStore
{
    public partial class AdicionarProduto : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Calendar1.SelectedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            }
        }

        public string getCurrentLoggedUser()
        {
            //teste para pegar o email do usuário logado
            var db = new WebFormsStore.Models.ApplicationDbContext();
            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);
            string imagepath = currentUser.Email.ToString();
            string retorno = imagepath.Replace("@", "");
            return imagepath;
        }

        protected string UploadButton_Click(object sender, EventArgs e)
        {
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
                            if (!Directory.Exists(Server.MapPath("~/Images/" + getCurrentLoggedUser()) + "/"))
                            {
                                Directory.CreateDirectory(Server.MapPath("~/Images/" + getCurrentLoggedUser()) + "/");
                            }
                            FileUploadControl.SaveAs(Server.MapPath("~/Images/" + getCurrentLoggedUser()) + "/" + filename);
                            diretorioDoUsuario = "/Images/" + getCurrentLoggedUser().ToString() + "/" + filename;
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

        protected void enviar(object sender, EventArgs e)
        {

            //DateTime x;
            //DateTime y = DateTime.Now;
            //x = Calendar1.SelectedDate;
            //if (x <= y || x == null)
            //{
            //    cvCaltest.IsValid = false;
            //    return;
            //}

            string userKey = HttpContext.Current.User.Identity.GetUserId();
            var _db = new ProdutoContexto();
            IQueryable<Usuario> usuarioDB = _db.Usuarios.Where(u => u.IdentityLink == userKey);
            Usuario usuario = usuarioDB.FirstOrDefault();
            string precoString = preco.Text;
            precoString = precoString.Substring(3);

            // This is invariant
            NumberFormatInfo format = new NumberFormatInfo();
            // Set the 'splitter' for thousands
            format.NumberGroupSeparator = ".";
            // Set the decimal seperator
            format.NumberDecimalSeparator = ",";

            double precoFinal = double.Parse(precoString, format);
            string imagem = UploadButton_Click(sender, e);
            int catID = int.Parse(DropDownList1.SelectedItem.Value);
            string Email = getCurrentLoggedUser();

            Produto produto = new Produto
            {
                ProdutoNome = NomeProduto.Text,
                CategoriaID = catID,
                PrecoUnitario = precoFinal,
                Descricao = descricao.Text,
                ImagePath = imagem,
                emailUser = Email,
                DataExpiracao = Calendar1.SelectedDate,
                UserID = usuario.UsuarioID
            };

            try
            {




                var db = new WebFormsStore.Models.ProdutoContexto();
                db.Produtos.Add(produto);
                db.SaveChanges();
                Response.Redirect("~/adicionado?sucesso=sim", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch
            {
                Response.Redirect("~/adicionado?sucesso=nao");
            }

        }

        public IQueryable<Categoria> GetCategories()
        {
            var _db = new WebFormsStore.Models.ProdutoContexto(); //cria conexão com banco
            IQueryable<Categoria> query = _db.Categorias;
            return query;
        }


    }
}