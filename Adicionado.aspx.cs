using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsStore
{
    public partial class Adicionado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string confirma = Request.QueryString["sucesso"];
            if (confirma.Contains("sim"))
            {
                ResultadoSalvar.CssClass = "alert alert-dismissible alert-success";
                ResultadoSalvar.Text = "Sucesso";
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