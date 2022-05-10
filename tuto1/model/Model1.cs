using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace tuto1.model
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Donnée")
        {
        }

        public virtual DbSet<produits> produits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<produits>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<produits>()
                .Property(e => e.prix)
                .IsUnicode(false);

            modelBuilder.Entity<produits>()
                .Property(e => e.image)
                .IsUnicode(false);


        }
    }
}
