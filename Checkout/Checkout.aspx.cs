using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsStore.Checkout
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string confirma = Request.QueryString["sucesso"];
            if (confirma.Contains("sim"))
            {
                ResultadoSalvar.CssClass = "alert alert-dismissible alert-success";
                ResultadoSalvar.Text = @"Você comprou com sucesso, vá em ""Meu Perfil"" para visualizar suas compras. ";
                ResultadoSalvar.Visible = true;
            }
            else
            {
                ResultadoSalvar.CssClass = "alert alert-dismissible alert-danger";
                ResultadoSalvar.Text = "Erro";
                ResultadoSalvar.Visible = true;
            }
        }
    }
}