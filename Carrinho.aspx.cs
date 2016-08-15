using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsStore.Logic;
using WebFormsStore.Models;
using System.Collections.Specialized;
using System.Collections;
using System.Web.ModelBinding;
using Microsoft.AspNet.Identity;

namespace WebFormsStore
{
    public partial class Carrinho : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (CarrinhoComprasAcoes usersShoppingCart = new CarrinhoComprasAcoes())
            {
                decimal cartTotal = 0;
                cartTotal = usersShoppingCart.GetTotal();
                if (cartTotal > 0)
                {
                    // Display Total.
                    lblTotal.Text = String.Format("{0:c}", cartTotal);
                    if (!HttpContext.Current.User.Identity.IsAuthenticated)
                    {
                        LinkButton1.Visible = false;
                        labelConectar.Visible = true;
                    }
                }
                else
                {
                    LabelTotalText.Text = "";
                    lblTotal.Text = "";
                    TituloCarrinho.InnerText = "";
                    CarrinhoVazio.InnerHtml = "<h2>Seu carrinho está vazio.<h2><br />";
                    LinkButton1.Visible = false;
                    UpdateBtn.Visible = false;
                }
            }



        }

        public List<ItemCarrinho> GetShoppingCartItems()
        {
            CarrinhoComprasAcoes actions = new CarrinhoComprasAcoes();
            return actions.GetItensCarrinho();
        }

        public List<ItemCarrinho> UpdateCartItems()
        {
            using (CarrinhoComprasAcoes usersShoppingCart = new CarrinhoComprasAcoes())
            {
                String cartId = usersShoppingCart.GetCarrinhoID();

                CarrinhoComprasAcoes.ShoppingCartUpdates[] cartUpdates = new CarrinhoComprasAcoes.ShoppingCartUpdates[CartList.Rows.Count];
                for (int i = 0; i < CartList.Rows.Count; i++)
                {
                    IOrderedDictionary rowValues = new OrderedDictionary();
                    rowValues = GetValues(CartList.Rows[i]);
                    cartUpdates[i].ProductId = Convert.ToInt32(rowValues["ProdutoID"]);

                    CheckBox cbRemove = new CheckBox();
                    cbRemove = (CheckBox)CartList.Rows[i].FindControl("Remove");
                    cartUpdates[i].RemoveItem = cbRemove.Checked;

                    TextBox quantityTextBox = new TextBox();
                    quantityTextBox = (TextBox)CartList.Rows[i].FindControl("PurchaseQuantity");
                    cartUpdates[i].PurchaseQuantity = Convert.ToInt16(quantityTextBox.Text.ToString());
                }
                usersShoppingCart.UpdateShoppingCartDatabase(cartId, cartUpdates);
                CartList.DataBind();
                lblTotal.Text = String.Format("{0:c}", usersShoppingCart.GetTotal());
                return usersShoppingCart.GetItensCarrinho();
            }
        }

        public static IOrderedDictionary GetValues(GridViewRow row)
        {
            IOrderedDictionary values = new OrderedDictionary();
            foreach (DataControlFieldCell cell in row.Cells)
            {
                if (cell.Visible)
                {
                    // Extract values from the cell.
                    cell.ContainingField.ExtractValuesFromCell(values, cell, row.RowState, true);
                }
            }
            return values;
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            UpdateCartItems();
            using (CarrinhoComprasAcoes usersShoppingCart = new CarrinhoComprasAcoes())
            {
                decimal cartTotal = 0;
                cartTotal = usersShoppingCart.GetTotal();
                if (cartTotal > 0)
                {
                    // Display Total.
                    lblTotal.Text = String.Format("{0:c}", cartTotal);
                }
                else
                {
                    LabelTotalText.Text = "";
                    lblTotal.Text = "";
                    TituloCarrinho.InnerText = "";
                    CarrinhoVazio.InnerHtml = "<h2>Seu carrinho está vazio.<h2><br />";
                    UpdateBtn.Visible = false;
                }
            }
        }

        public Usuario getCurrentUser()
        {
            string userKey = HttpContext.Current.User.Identity.GetUserId();
            var _db = new ProdutoContexto();
            IQueryable<Usuario> usuarioDB = _db.Usuarios.Where(u => u.IdentityLink == userKey);
            Usuario usuario = usuarioDB.FirstOrDefault();
            return usuario;
        }

        protected void FinalizarCompra(object sender, EventArgs e)
        {
            decimal cartTotal = 0;
            using (CarrinhoComprasAcoes usersShoppingCart = new CarrinhoComprasAcoes())
            {
                cartTotal = usersShoppingCart.GetTotal();
            }

            Usuario usuario = getCurrentUser();

            var MinhaOrdem = new OrdemDeCompra
            {
                DataDaCompra = DateTime.Now,
                Total = cartTotal,
                UsuarioID = usuario.UsuarioID
            };

            // Get DB context.
            ProdutoContexto _db = new ProdutoContexto();

            // Add order to DB.
            _db.OrdensDeCompra.Add(MinhaOrdem);
            _db.SaveChanges();

            // Get the shopping cart items and process them.
            using (WebFormsStore.Logic.CarrinhoComprasAcoes usersShoppingCart = new WebFormsStore.Logic.CarrinhoComprasAcoes())
            {
                //try
                //{
                    List<ItemCarrinho> myOrderList = usersShoppingCart.GetItensCarrinho();

                    _db = new ProdutoContexto();
                    // Add OrderDetail information to the DB for each product purchased.
                    for (int i = 0; i < myOrderList.Count; i++)
                    {
                        // Create a new OrderDetail object.
                        var myOrderDetail = new DetalhesDaOrdemDeCompra();
                        myOrderDetail.OrdemDeCompraID = MinhaOrdem.OrdemDeCompraID;
                        myOrderDetail.ProdutoID = myOrderList[i].ProdutoId;
                        myOrderDetail.PrecoUnitario = myOrderList[i].Produto.PrecoUnitario;
                        // Add OrderDetail to DB.
                        _db.DetalhesDasOrdensDeCompra.Add(myOrderDetail);
                        _db.SaveChanges();
                    }

                    // Set OrderId.
                    Session["currentOrderId"] = MinhaOrdem.OrdemDeCompraID;

                    _db = new ProdutoContexto();
                    for (int i = 0; i < myOrderList.Count; i++)
                    {
                        //modifica produto para vendido
                        int prodID = myOrderList[i].ProdutoId;
                        IQueryable<Produto> prodDB = _db.Produtos.Where(p => p.ProdutoID == prodID);
                        Produto produto = prodDB.FirstOrDefault();
                        if (!produto.vendido)
                        {
                            produto.vendido = true;
                            _db.Entry(produto).State = System.Data.Entity.EntityState.Modified;
                            _db.SaveChanges();
                        }
                    }

                    //// Display Order information.
                    //List<OrdemDeCompra> orderList = new List<OrdemDeCompra>();
                    //orderList.Add(MinhaOrdem);

                    // esvazia o carrinho.

                    usersShoppingCart.EmptyCart();


                    Response.Redirect("/Checkout/Checkout.aspx?sucesso=sim");

                //}
                //catch
                //{
                //    Response.Redirect("/Checkout/Checkout.aspx?sucesso=nao");
                //}


            }

        }
    }
}