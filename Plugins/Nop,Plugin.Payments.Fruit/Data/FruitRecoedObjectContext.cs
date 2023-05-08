using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Nop.Plugin.Payments.Fruit.Domain;

namespace Nop.Plugin.Payments.Fruit.Data
{
    public class FruitRecoedObjectContext : DbContext
    {
        public DbSet<Frruit> Fruits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-5HU625C7;Initial Catalog=NopCommerce;Integrated Security=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Frruit>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.FruitName);
                entity.Property(e => e.FruitColor);
            });

          

            base.OnModelCreating(modelBuilder);
        }

        
    }
}
