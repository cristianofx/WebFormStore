using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using WebFormsStore.Models;

namespace WebFormsStore.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");
                //string[] dataN = NascimentoField.Text.Split('/');
                //int dia = int.Parse(dataN[0]);
                //int mes = int.Parse(dataN[1]);
                //int ano = int.Parse(dataN[2]);
                signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                Usuario usuario = new Usuario
                {
                    Email = user.Email,
                    Nome = nomeUserField.Text,
                    Sobrenome = SobrenomeField.Text,
                    DataNascimento = Convert.ToDateTime(NascimentoField.Text),
                    IdentityLink = user.Id
                };
                var _db = new ProdutoContexto();
                _db.Usuarios.Add(usuario);
                _db.SaveChanges();

                //passa o carrinho de compras anônimo para o usuario que se registrou
                using (WebFormsStore.Logic.CarrinhoComprasAcoes usersShoppingCart = new WebFormsStore.Logic.CarrinhoComprasAcoes())
                {
                    String cartId = usersShoppingCart.GetCarrinhoID();
                    usersShoppingCart.MigrateCart(cartId, user.Id);
                }

                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                string jaExiste = result.Errors.FirstOrDefault();
                if (jaExiste.Contains("is already taken"))
                {
                    jaExiste = "Email já está cadastrado.";
                }
                if (jaExiste.Contains("Passwords must be at least 5 characters"))
                {
                    jaExiste = "A senha deve ter mais de 5 caracteres";
                }
                ErrorMessage.Text = jaExiste;
            }
        }
    }
}