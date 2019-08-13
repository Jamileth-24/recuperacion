using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen.Models
{
    public class Destinatario
    {
        public int Id { get; set; }
        public string CI { get; set; }
        public string RazonSocial { get; set; }


        public virtual List<Guia> ListaGuia { get; set; }
    }
}