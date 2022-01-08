using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace AprozarModel
{
    public partial class AprozarEntitiesModel : DbContext
    {
        public AprozarEntitiesModel()
            : base("name=AprozarEntitiesModel")
        {
        }

        public virtual DbSet<Categorii> Categoriis { get; set; }
        public virtual DbSet<Clienti> Clientis { get; set; }
        public virtual DbSet<ComenziClienti> ComenziClientis { get; set; }
        public virtual DbSet<ComenziFurnizori> ComenziFurnizoris { get; set; }
        public virtual DbSet<Furnizori> Furnizoris { get; set; }
        public virtual DbSet<Produse> Produses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorii>()
                .HasMany(e => e.Produses)
                .WithOptional(e => e.Categorii)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Clienti>()
                .HasMany(e => e.ComenziClientis)
                .WithOptional(e => e.Clienti)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Produse>()
                .HasMany(e => e.ComenziClientis)
                .WithOptional(e => e.Produse)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Produse>()
                .HasMany(e => e.ComenziFurnizoris)
                .WithOptional(e => e.Produse)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Produse>()
                .HasMany(e => e.Furnizoris)
                .WithOptional(e => e.Produse)
                .WillCascadeOnDelete();
        }
    }
}
