using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsStore.Models;

//Logica do carrinho de compras:

//1 - Adicionar itens ao carrinho
//2 - Remover itens do carrinho
//3 - Receber um ID do carrinho
//4 - Buscar itens do carrinho
//5 - Total de itens do carrinho
//6 - Atualizar os dados do carrinho

namespace WebFormsStore.Logic
{
    public class CarrinhoComprasAcoes : IDisposable
    {

        public string CarrinhoComprasID { get; set; }

        private ProdutoContexto _db = new ProdutoContexto();

        public const string CartSessionKey = "CarrinhoID";

        public void AdicionaAoCarrinho(int id)
        {
            CarrinhoComprasID = GetCarrinhoID();

            var ItemCarrinho = _db.ItensDoCarrinho.SingleOrDefault(c => c.CarrinhoId == CarrinhoComprasID && c.ProdutoId == id);

            if (ItemCarrinho == null)
            {
                //cria um item de carrinho se nenhum existir
                {
                    ItemCarrinho = new ItemCarrinho
                    {
                        ItemId = Guid.NewGuid().ToString(),
                        ProdutoId = id,
                        CarrinhoId = CarrinhoComprasID,
                        Produto = _db.Produtos.SingleOrDefault(p => p.ProdutoID == id),
                        Quantidade = 1,
                        DataCriado = DateTime.Now
                    };

                    _db.ItensDoCarrinho.Add(ItemCarrinho);
                }
            }
            else
            {
                //Se o item já existe no carrinho, adiciona na quantidade (NÃO IMPLEMENTADO PARA ESTA LOJA)
                //ItemCarrinho.Quantidade++;
            }
            _db.SaveChanges();
        }

        public void Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
                _db = null;
            }
        }

        public string GetCarrinhoID()
        {
            if (HttpContext.Current.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                {
                    HttpContext.Current.Session[CartSessionKey] = HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    //gera um GUID aleatório
                    Guid carrinhoTempID = Guid.NewGuid();
                    HttpContext.Current.Session[CartSessionKey] = carrinhoTempID.ToString();
                }
            }
            return HttpContext.Current.Session[CartSessionKey].ToString();
        }

        public List<ItemCarrinho> GetItensCarrinho()
        {
            CarrinhoComprasID = GetCarrinhoID();
            return _db.ItensDoCarrinho.Where(c => c.CarrinhoId == CarrinhoComprasID).ToList();
        }


        public decimal GetTotal()
        {
            CarrinhoComprasID = GetCarrinhoID();
            // Multiply product price by quantity of that product to get        
            // the current price for each of those products in the cart.  
            // Sum all product price totals to get the cart total.   
            decimal? total = decimal.Zero;
            total = (decimal?)(from cartItems in _db.ItensDoCarrinho
                               where cartItems.CarrinhoId == CarrinhoComprasID
                               select (int?)cartItems.Quantidade *
                               cartItems.Produto.PrecoUnitario).Sum();
            return total ?? decimal.Zero;
        }


        public CarrinhoComprasAcoes GetCart(HttpContext context)
        {
            using (var cart = new CarrinhoComprasAcoes())
            {
                cart.CarrinhoComprasID = cart.GetCarrinhoID();
                return cart;
            }
        }

        public void UpdateShoppingCartDatabase(String cartId, ShoppingCartUpdates[] CartItemUpdates)
        {
            using (var db = new WebFormsStore.Models.ProdutoContexto())
            {
                try
                {
                    int CartItemCount = CartItemUpdates.Count();
                    List<ItemCarrinho> myCart = GetItensCarrinho();
                    foreach (var cartItem in myCart)
                    {
                        // Iterate through all rows within shopping cart list
                        for (int i = 0; i < CartItemCount; i++)
                        {
                            if (cartItem.Produto.ProdutoID == CartItemUpdates[i].ProductId)
                            {
                                if (CartItemUpdates[i].PurchaseQuantity < 1 || CartItemUpdates[i].RemoveItem == true)
                                {
                                    RemoveItem(cartId, cartItem.ProdutoId);
                                }
                                else
                                {
                                    UpdateItem(cartId, cartItem.ProdutoId, CartItemUpdates[i].PurchaseQuantity);
                                }
                            }
                        }
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERRO: Não foi possível atualizar os dados do carrinho - " + exp.Message.ToString(), exp);
                }
            }
        }

        public void RemoveItem(string removeCartID, int removeProductID)
        {
            using (var _db = new WebFormsStore.Models.ProdutoContexto())
            {
                try
                {
                    var myItem = (from c in _db.ItensDoCarrinho where c.CarrinhoId == removeCartID && c.Produto.ProdutoID == removeProductID select c).FirstOrDefault();
                    if (myItem != null)
                    {
                        // Remove Item.
                        _db.ItensDoCarrinho.Remove(myItem);
                        _db.SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERRO: Não foi possível remover o ítem do carrinho - " + exp.Message.ToString(), exp);
                }
            }
        }

        public void UpdateItem(string updateCartID, int updateProductID, int quantity)
        {
            using (var _db = new WebFormsStore.Models.ProdutoContexto())
            {
                try
                {
                    var myItem = (from c in _db.ItensDoCarrinho where c.CarrinhoId == updateCartID && c.Produto.ProdutoID == updateProductID select c).FirstOrDefault();
                    if (myItem != null)
                    {
                        myItem.Quantidade = quantity;
                        _db.SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERRO: Não foi possível atualizar o item do carrinho - " + exp.Message.ToString(), exp);
                }
            }
        }

        public void EmptyCart()
        {
            CarrinhoComprasID = GetCarrinhoID();
            var cartItems = _db.ItensDoCarrinho.Where(
                c => c.CarrinhoId == CarrinhoComprasID);
            foreach (var cartItem in cartItems)
            {
                _db.ItensDoCarrinho.Remove(cartItem);
            }
            // Save changes.             
            _db.SaveChanges();
        }

        public int GetCount()
        {
            CarrinhoComprasID = GetCarrinhoID();

            // Get the count of each item in the cart and sum them up          
            int? count = (from cartItems in _db.ItensDoCarrinho
                          where cartItems.CarrinhoId == CarrinhoComprasID
                          select (int?)cartItems.Quantidade).Sum();
            // Return 0 if all entries are null         
            return count ?? 0;
        }

        public struct ShoppingCartUpdates
        {
            public int ProductId;
            public int PurchaseQuantity;
            public bool RemoveItem;
        }

        public void MigrateCart(string cartId, string userName)
        {
            var shoppingCart = _db.ItensDoCarrinho.Where(c => c.CarrinhoId == cartId);
            foreach (ItemCarrinho item in shoppingCart)
            {
                item.CarrinhoId = userName;
            }
            HttpContext.Current.Session[CartSessionKey] = userName;
            _db.SaveChanges();
        }

    }
}