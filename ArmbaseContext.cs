using System;
using System.Collections.Generic;
using ARM_App.Model;
using Microsoft.EntityFrameworkCore;

namespace ARM_App.Helper;

public partial class ArmbaseContext : DbContext
{
    public ArmbaseContext()
    {
    }

    public ArmbaseContext(DbContextOptions<ArmbaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<RawMaterial> RawMaterials { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=ARMBase;Trusted_Connection=True;Trust Server Certificate=Yes;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.productId).HasColumnName("productId");
            entity.Property(e => e.CountProduct).HasColumnName("countProduct");
            entity.Property(e => e.ExpirationDate).HasColumnName("expirationDate");
            entity.Property(e => e.ProductCategory)
                .HasMaxLength(75)
                .HasColumnName("productCategory");
            entity.Property(e => e.ProductName)
                .HasMaxLength(75)
                .HasColumnName("productName");
            entity.Property(e => e.ProductSalary)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("productSalary");
        });

        modelBuilder.Entity<RawMaterial>(entity =>
        {
            entity.Property(e => e.rawMaterialId).HasColumnName("rawMaterialId");
            entity.Property(e => e.CountRawMaterial).HasColumnName("countRawMaterial");
            entity.Property(e => e.NameRawMaterial)
                .HasMaxLength(75)
                .HasColumnName("nameRawMaterial");
            entity.Property(e => e.TypeRawMaterial)
                .HasMaxLength(80)
                .HasColumnName("typeRawMaterial");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
