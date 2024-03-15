using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Pizzeria.Models
{
    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<Articolo> Articolo { get; set; }
        public virtual DbSet<Dettaglio> Dettaglio { get; set; }
        public virtual DbSet<Ordinazione> Ordinazione { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articolo>()
                .Property(e => e.Prezzo)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Articolo>()
                .HasMany(e => e.Dettaglio)
                .WithRequired(e => e.Articolo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ordinazione>()
                .Property(e => e.Totale)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Ordinazione>()
                .HasMany(e => e.Dettaglio)
                .WithRequired(e => e.Ordinazione)
                .HasForeignKey(e => e.OrdineId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Ordinazione)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
