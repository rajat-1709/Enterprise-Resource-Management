using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace demoerpnxt.Models
{
    public partial class demoerpContext : DbContext
    {
        public demoerpContext()
        {
        }

        public demoerpContext(DbContextOptions<demoerpContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Buyer> Buyers { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocaldb;Database=demoerp;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.HasKey(e => e.Billno)
                    .HasName("PK__bill__6D9AEEA1AAC5DA87");

                entity.ToTable("bill");

                entity.Property(e => e.Billno).HasColumnName("billno");

                entity.Property(e => e.Buydate)
                    .HasColumnType("datetime")
                    .HasColumnName("buydate");

                entity.Property(e => e.Buyersid).HasColumnName("buyersid");

                entity.Property(e => e.Buyersname)
                    .IsUnicode(false)
                    .HasColumnName("buyersname");

                entity.Property(e => e.Itemsid).HasColumnName("itemsid");

                entity.Property(e => e.Itemsname)
                    .IsUnicode(false)
                    .HasColumnName("itemsname");

                entity.Property(e => e.Itemsquant).HasColumnName("itemsquant");

                entity.Property(e => e.Paidamount).HasColumnName("paidamount");

                entity.Property(e => e.Remainingamount).HasColumnName("remainingamount");

                entity.Property(e => e.Sellersid).HasColumnName("sellersid");

                entity.Property(e => e.Sellersname)
                    .IsUnicode(false)
                    .HasColumnName("sellersname");

                entity.Property(e => e.Totalamount).HasColumnName("totalamount");

                entity.HasOne(d => d.Buyers)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.Buyersid)
                    .HasConstraintName("FK__bill__buyersid__37A5467C");

                entity.HasOne(d => d.Items)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.Itemsid)
                    .HasConstraintName("FK__bill__itemsid__38996AB5");

                entity.HasOne(d => d.Sellers)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.Sellersid)
                    .HasConstraintName("FK__bill__sellersid__398D8EEE");
            });

            modelBuilder.Entity<Buyer>(entity =>
            {
                entity.ToTable("buyer");

                entity.Property(e => e.Buyerid).HasColumnName("buyerid");

                entity.Property(e => e.Buyername)
                    .IsUnicode(false)
                    .HasColumnName("buyername");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("items");

                entity.Property(e => e.Itemid).HasColumnName("itemid");

                entity.Property(e => e.Itemlastupdate)
                    .HasColumnType("datetime")
                    .HasColumnName("itemlastupdate");

                entity.Property(e => e.Itemname)
                    .IsUnicode(false)
                    .HasColumnName("itemname");

                entity.Property(e => e.Itemprice).HasColumnName("itemprice");

                entity.Property(e => e.Itemquant).HasColumnName("itemquant");
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.ToTable("seller");

                entity.Property(e => e.Sellerid).HasColumnName("sellerid");

                entity.Property(e => e.Sellername)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sellername");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
