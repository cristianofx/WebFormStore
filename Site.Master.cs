using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using WebFormsStore.Models;
using WebFormsStore.Logic;
using Microsoft.AspNet.Identity;


namespace WebFormsStore
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Verifica se o usuário é Admin para liberar a página de Admin no menu
            if (HttpContext.Current.User.IsInRole("SiteAdmin"))
            {
                adminLink.Visible = true;
            }
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                AdicionaProdutoMenu.Visible = true;
            }

            //string href = "~/Perfil?email=" + Context.User.Identity.Name;
            //linkPerfil.HRef = href;

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            using (CarrinhoComprasAcoes usersShoppingCart = new CarrinhoComprasAcoes())
            {
                string cartStr = string.Format("Carrinho ({0})", usersShoppingCart.GetCount());
                cartCount.InnerText = cartStr;
            }
        }

        public IQueryable<Categoria> GetCategories()
        {
            var _db = new WebFormsStore.Models.ProdutoContexto(); //cria conexão com banco
            IQueryable<Categoria> query = _db.Categorias;
            return query;
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut();

        }


    }

}