using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebFormsStore.Models
{
    public class ResenhaUsuario
    {
        [ScaffoldColumn(false)]
        [Key]
        public int ResenhaUsuarioID { get; set; }

        public int UsuarioID { get; set; }

        [Required, StringLength(10000), Display(Name = "Resenha do produto"), DataType(DataType.MultilineText)]
        public string ResenhaDoUsuario { get; set; }

        public Usuario Usuario { get; set; }
    }
}