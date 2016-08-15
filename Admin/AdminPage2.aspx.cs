using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsStore.Models;

namespace WebFormsStore.Admin
{
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getNumeroProdutos();
        }

        protected void getNumeroProdutos()
        {
            var _db = new ProdutoContexto();
            int x = _db.Produtos.Count();
            Label2.Text = x.ToString();
        }

    }
}