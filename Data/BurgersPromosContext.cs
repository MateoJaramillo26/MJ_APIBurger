using System;
using System.Collections.Generic;
using MJ_APIBurger.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MJ_APIBurger.Data;

public partial class BurgersPromosContext : DbContext
{
    public BurgersPromosContext()
    {
    }

    public BurgersPromosContext(DbContextOptions<BurgersPromosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MJBurger> Burgers { get; set; }

    public virtual DbSet<MJPromo> Promos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=mjburgerpersonalizado-f50cf28a-29e4-4457-af60-dd08cf680e73;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MJBurger>(entity =>
        {
            entity.ToTable("Burger");

            entity.Property(e => e.MJPrecio).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<MJPromo>(entity =>
        {
            entity.ToTable("Promo");

            entity.HasIndex(e => e.MJBurgerId, "IX_Promo_BurgerId");

            entity.HasOne(d => d.MJBurger).WithMany(p => p.MJPromos).HasForeignKey(d => d.MJBurgerId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
