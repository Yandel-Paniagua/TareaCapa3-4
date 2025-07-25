using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UnaApi2.Domain.Entities;
//using UnaApi2.Infrastructure.Models;


namespace UnaApi2.Infrastructure.Context;

public partial class UnaApiDbContext : DbContext
{
    public UnaApiDbContext()
    {
    }

    public UnaApiDbContext(DbContextOptions<UnaApiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<Municipality> Municipalities { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<District>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__District__3214EC076D677523");

            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Condition)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Municipality).WithMany(p => p.Districts)
                .HasForeignKey(d => d.MunicipalityId)
                .HasConstraintName("FK_Districts_Municipalities");
        });

        modelBuilder.Entity<Municipality>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Municioa__3214EC078E845646");

            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Condition)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
