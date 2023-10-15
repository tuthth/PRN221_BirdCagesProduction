using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Models.Models;

public partial class BirdCageManagementsContext : DbContext
{
    public BirdCageManagementsContext()
    {
    }

    public BirdCageManagementsContext(DbContextOptions<BirdCageManagementsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Expense> Expenses { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductionStep> ProductionSteps { get; set; }

    public virtual DbSet<Staff> Staffs { get; set; }

    public virtual DbSet<WorkOn> WorkOns { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(GetConnectionString());
    private static string GetConnectionString()
    {
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();
        var strConn = config["ConnectionStrings:BirdCageManagements"];
        return strConn;
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B8CF49FB74");

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("CustomerID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Expense>(entity =>
        {
            entity.HasKey(e => e.ExpenseId).HasName("PK__Expenses__1445CFF3426628EE");

            entity.Property(e => e.ExpenseId)
                .ValueGeneratedNever()
                .HasColumnName("ExpenseID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.DateIncurred).HasColumnType("date");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.InventoryId).HasName("PK__Inventor__F5FDE6D3E1CAF41A");

            entity.ToTable("Inventory");

            entity.Property(e => e.InventoryId)
                .ValueGeneratedNever()
                .HasColumnName("InventoryID");
            entity.Property(e => e.MaterialId).HasColumnName("MaterialID");

            entity.HasOne(d => d.Material).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.MaterialId)
                .HasConstraintName("FK__Inventory__Mater__36B12243");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.MaterialId).HasName("PK__Material__C506131797DE1575");

            entity.ToTable("Material");

            entity.Property(e => e.MaterialId)
                .ValueGeneratedNever()
                .HasColumnName("MaterialID");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAF1FC73A3F");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("OrderID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DatePlaced).HasColumnType("date");
            entity.Property(e => e.ExpenseId).HasColumnName("ExpenseID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Orders__Customer__2A4B4B5E");

            entity.HasOne(d => d.Expense).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ExpenseId)
                .HasConstraintName("FK__Orders__ExpenseI__2B3F6F97");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PK__OrderIte__57ED06A1F5960ECE");

            entity.ToTable("OrderItem");

            entity.Property(e => e.OrderItemId)
                .ValueGeneratedNever()
                .HasColumnName("OrderItemID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderItem__Order__30F848ED");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__OrderItem__Produ__31EC6D26");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6ED554F022D");

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("ProductID");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.InventoryId).HasColumnName("InventoryID");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.StepId).HasColumnName("StepID");

            entity.HasOne(d => d.Inventory).WithMany(p => p.Products)
                .HasForeignKey(d => d.InventoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products__Invent__5AEE82B9");

            entity.HasOne(d => d.Step).WithMany(p => p.Products)
                .HasForeignKey(d => d.StepId)
                .HasConstraintName("FK__Products__StepID__2E1BDC42");
        });

        modelBuilder.Entity<ProductionStep>(entity =>
        {
            entity.HasKey(e => e.StepId).HasName("PK__Producti__24343337BC3FC727");

            entity.Property(e => e.StepId)
                .ValueGeneratedNever()
                .HasColumnName("StepID");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staffs__96D4AAF7003D3131");

            entity.Property(e => e.StaffId)
                .ValueGeneratedNever()
                .HasColumnName("StaffID");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WorkOn>(entity =>
        {
            entity.HasKey(e => e.WorkOnId).HasName("PK__WorkOn__B9F6C9D9CD9CB2A9");

            entity.ToTable("WorkOn");

            entity.Property(e => e.WorkOnId)
                .ValueGeneratedNever()
                .HasColumnName("WorkOnID");
            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.StepId).HasColumnName("StepID");

            entity.HasOne(d => d.Staff).WithMany(p => p.WorkOns)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("FK__WorkOn__StaffID__3C69FB99");

            entity.HasOne(d => d.Step).WithMany(p => p.WorkOns)
                .HasForeignKey(d => d.StepId)
                .HasConstraintName("FK__WorkOn__StepID__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
