using Datos.BaseDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.BaseDatos
{
    public class RentaContext: DbContext
    {
        public RentaContext() : base("name=RentaVideo")
        {            

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Peliculas> pelicula { get; set; }
        public DbSet<Clientes> cliente { get; set; }
        public DbSet<Renta> renta { get; set; }
    }
}
