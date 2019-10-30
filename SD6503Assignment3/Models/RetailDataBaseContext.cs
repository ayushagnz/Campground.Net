using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SD6503Assignment3.Models
{
    public partial class RetailDataBaseContext : DbContext
    {
        public RetailDataBaseContext()
        {
        }

        public RetailDataBaseContext(DbContextOptions<RetailDataBaseContext> options) : base(options)
        { }


        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PK_dbo.Customer");

                entity.Property(e => e.Cid).HasColumnName("CId");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.Phone).HasMaxLength(30);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("PK_dbo.Order");

                entity.Property(e => e.Oid).HasColumnName("OId");

                entity.Property(e => e.Cid).HasColumnName("CId");

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.C)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.Cid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustOrder");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProdOrder");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasMaxLength(20);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.HasKey(e => e.Sid)
                    .HasName("PK__Staff__CA195950E7C843F4");

                entity.Property(e => e.Sid).HasColumnName("SId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
