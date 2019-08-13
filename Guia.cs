using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Examen.Models
{
    public class Guia
    {

        public int Id { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string Tipo { get; set; }
        public string NoAutorizacion { get; set; }
        public string NoComprobante { get; set; }

        public int IdTransportista { get; set; }
        [ForeignKey("IdTransportista")]
        public virtual Transportista Transportista { get; set; }

        public int IdDestinatario { get; set; }
        [ForeignKey("IdDestinatario")]
        public virtual Destinatario Destinatario{ get; set; }

        public virtual List<Producto> ListaProducto { get; set; }
    }
}