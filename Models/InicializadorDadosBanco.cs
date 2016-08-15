using System.Collections.Generic;
using System.Data.Entity;

namespace WebFormsStore.Models
{
    public class InicializadorDadosBanco : DropCreateDatabaseIfModelChanges<ProdutoContexto>
    {
        protected override void Seed(ProdutoContexto context)
        {
            GetCategories().ForEach(c => context.Categorias.Add(c));
            GetProdutos().ForEach(p => context.Produtos.Add(p));
        }

        private static List<Categoria> GetCategories()
        {
            var categorias = new List<Categoria> {
                new Categoria
                {
                    CategoriaID = 1,
                    CategoriaNome = "Imóvel"
                },
                new Categoria
                {
                    CategoriaID = 2,
                    CategoriaNome = "Veículos"
                },
                new Categoria
                {
                    CategoriaID = 3,
                    CategoriaNome = "Eletrônicos"
                },
                new Categoria
                {
                    CategoriaID = 4,
                    CategoriaNome = "Eletrodomésticos"
                },
                new Categoria
                {
                    CategoriaID = 5,
                    CategoriaNome = "Informática"
                },
            };

            return categorias;
        }

        private static List<Produto> GetProdutos()
        {
            var Produtos = new List<Produto> {
                new Produto
                {
                    ProdutoID = 1,
                    ProdutoNome = "Convertible Car",
                    Descricao = "This convertible car is fast! The engine is powered by a neutrino based battery (not included)." + 
                                  "Power it up and let it go!", 
                    PrecoUnitario = 22.50,
                    CategoriaID = 2,
               },
                new Produto 
                {
                    ProdutoID = 2,
                    ProdutoNome = "Old-time Car",
                    Descricao = "There's nothing old about this toy car, except it's looks. Compatible with other old toy cars.",
                    PrecoUnitario = 15.95,
                     CategoriaID = 2,
               },
                new Produto
                {
                    ProdutoID = 3,
                    ProdutoNome = "Fast Car",
                    Descricao = "Yes this car is fast, but it also floats in water.",
                    PrecoUnitario = 32.99,
                    CategoriaID = 1
                },
                new Produto
                {
                    ProdutoID = 4,
                    ProdutoNome = "Super Fast Car",
                    Descricao = "Use this super fast car to entertain guests. Lights and doors work!",
                    PrecoUnitario = 8.95,
                    CategoriaID = 1
                },
                new Produto
                {
                    ProdutoID = 5,
                    ProdutoNome = "Old Style Racer",
                    Descricao = "This old style racer can fly (with user assistance). Gravity controls flight duration." + 
                                  "No batteries required.",
                    PrecoUnitario = 34.95,
                    CategoriaID = 1
                },
                new Produto
                {
                    ProdutoID = 6,
                    ProdutoNome = "Ace Plane",
                    Descricao = "Authentic airplane toy. Features realistic color and details.",
                    PrecoUnitario = 95.00,
                    CategoriaID = 2
                },
                new Produto
                {
                    ProdutoID = 7,
                    ProdutoNome = "Glider",
                    Descricao = "This fun glider is made from real balsa wood. Some assembly required.",
                    PrecoUnitario = 4.95,
                    CategoriaID = 2
                },
                new Produto
                {
                    ProdutoID = 8,
                    ProdutoNome = "Paper Plane",
                    Descricao = "This paper plane is like no other paper plane. Some folding required.",
                    PrecoUnitario = 2.95,
                    CategoriaID = 2
                },
                new Produto
                {
                    ProdutoID = 9,
                    ProdutoNome = "Propeller Plane",
                    Descricao = "Rubber band powered plane features two wheels.",
                    PrecoUnitario = 32.95,
                    CategoriaID = 2
                },
                new Produto
                {
                    ProdutoID = 10,
                    ProdutoNome = "Early Truck",
                    Descricao = "This toy truck has a real gas powered engine. Requires regular tune ups.",
                    PrecoUnitario = 15.00,
                    CategoriaID = 3
                },
                new Produto
                {
                    ProdutoID = 11,
                    ProdutoNome = "Fire Truck",
                    Descricao = "You will have endless fun with this one quarter sized fire truck.",
                    PrecoUnitario = 26.00,
                    CategoriaID = 3
                },
                new Produto
                {
                    ProdutoID = 12,
                    ProdutoNome = "Big Truck",
                    Descricao = "This fun toy truck can be used to tow other trucks that are not as big.",
                    PrecoUnitario = 29.00,
                    CategoriaID = 3
                },
                new Produto
                {
                    ProdutoID = 13,
                    ProdutoNome = "Big Ship",
                    Descricao = "Is it a boat or a ship. Let this floating vehicle decide by using its " + 
                                  "artifically intelligent computer brain!",
                    PrecoUnitario = 95.00,
                    CategoriaID = 4
                },
                new Produto
                {
                    ProdutoID = 14,
                    ProdutoNome = "Paper Boat",
                    Descricao = "Floating fun for all! This toy boat can be assembled in seconds. Floats for minutes!" + 
                                  "Some folding required.",
                    PrecoUnitario = 4.95,
                    CategoriaID = 4
                },
                new Produto
                {
                    ProdutoID = 15,
                    ProdutoNome = "Sail Boat",
                    Descricao = "Put this fun toy sail boat in the water and let it go!",
                    PrecoUnitario = 42.95,
                    CategoriaID = 4
                },
                new Produto
                {
                    ProdutoID = 16,
                    ProdutoNome = "Rocket",
                    Descricao = "This fun rocket will travel up to a height of 200 feet.",
                    PrecoUnitario = 122.95,
                    CategoriaID = 5
                }
            };

            return Produtos;
        }
    }
}