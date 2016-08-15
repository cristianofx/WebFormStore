using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using WebFormsStore.Logic;

namespace WebFormsStore
{
    public partial class AdicionarAoCarrinho : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rawId = Request.QueryString["ProductID"];
            int ProdutoID;
            if (!String.IsNullOrEmpty(rawId) && int.TryParse(rawId, out ProdutoID))
            {
                using (CarrinhoComprasAcoes usersShoppingCart = new CarrinhoComprasAcoes())
                {
                    usersShoppingCart.AdicionaAoCarrinho(Convert.ToInt16(rawId));
                }

            }
            else
            {
                Debug.Fail("ERRO : Não deve-se chegar ao AdicionarAoCarrinho.aspx sem um ProdutoID.");
                throw new Exception("ERRO : Ilegal carregar AdicionaAoCarrinho.aspx sem setar um ProdutoID.");
            }
            Response.Redirect("Carrinho.aspx");
        }
    }
}