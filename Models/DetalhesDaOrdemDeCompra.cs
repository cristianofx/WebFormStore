using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebFormsStore.Models
{
    public class DetalhesDaOrdemDeCompra
    {
        public int DetalhesDaOrdemDeCompraID {get; set;}

        public int OrdemDeCompraID { get; set; }

        public int ProdutoID { get; set; }

        public double? PrecoUnitario { get; set; }

    }
}
