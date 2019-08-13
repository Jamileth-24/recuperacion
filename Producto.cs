using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Examen.Models
{
    public class Producto
    {

        public int Id { get; set; }
        public string Cantidad { get; set; }
        public string Descripcion { get; set; }

        public int IdGuia { get; set; }
        [ForeignKey("IdGuia")]
        public virtual Guia Guia{ get; set; }

    }
}