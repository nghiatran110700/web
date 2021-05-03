using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Web.Models.Entity
{
    public partial class ShopModel : DbContext
    {
        public ShopModel()
            : base("name=ShopModel1")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<category>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.photo)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.description)
                .IsUnicode(false);
        }

        public System.Data.Entity.DbSet<Web.Models.DTO.ProductDTO> ProductDTOes { get; set; }
    }
}
