using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Examen.Models
{
    public class RemisionContext: DbContext
    {
        public DbSet<Destinatario> Destinatarios { get; set; }
        public DbSet<Guia> Guias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Transportista> Transportistas{ get; set; }


        public RemisionContext()
        {
                
        }
    }
    

}