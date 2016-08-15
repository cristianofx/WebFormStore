using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormsStore.Models
{
    public class OrdemDeCompra
    {

        public int OrdemDeCompraID { get; set; }

        public System.DateTime DataDaCompra { get; set; }

        public decimal Total { get; set; }

        public int UsuarioID { get; set; }

        public List<DetalhesDaOrdemDeCompra> Detalhes { get; set; }

    }
}