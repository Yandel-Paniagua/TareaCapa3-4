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

    public virtual DbSet<AlertasMeteorologica> AlertasMeteorologicas { get; set; }

    public virtual DbSet<ConsejosClimatico> ConsejosClimaticos { get; set; }

    public virtual DbSet<LecturasClimatica> LecturasClimaticas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=lapYandel;Database=UnaApiDB;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AlertasMeteorologica>(entity =>
        {
            entity.HasKey(e => e.AlertaId).HasName("PK__AlertasM__D9EF47E56DDC4A5E");

            entity.Property(e => e.AlertaId).HasColumnName("AlertaID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FechaFin).HasColumnType("datetime");
            entity.Property(e => e.FechaInicio).HasColumnType("datetime");
            entity.Property(e => e.LecturaId).HasColumnName("LecturaID");
            entity.Property(e => e.Nivel)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Lectura).WithMany(p => p.AlertasMeteorologicas)
                .HasForeignKey(d => d.LecturaId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Alertas_Lecturas");
        });

        modelBuilder.Entity<ConsejosClimatico>(entity =>
        {
            entity.HasKey(e => e.ConsejoId).HasName("PK__Consejos__A9C2CA36BC3C6509");

            entity.Property(e => e.ConsejoId).HasColumnName("ConsejoID");
            entity.Property(e => e.Condicion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LecturaId).HasColumnName("LecturaID");
            entity.Property(e => e.Mensaje)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nivel)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Lectura).WithMany(p => p.ConsejosClimaticos)
                .HasForeignKey(d => d.LecturaId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Consejos_Lecturas");
        });

        modelBuilder.Entity<LecturasClimatica>(entity =>
        {
            entity.HasKey(e => e.LecturaId).HasName("PK__Lecturas__B421D4DC45FD9E13");

            entity.Property(e => e.LecturaId).HasColumnName("LecturaID");
            entity.Property(e => e.DireccionViento)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FechaHora).HasColumnType("datetime");
            entity.Property(e => e.Humedad).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Precipitacion).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Presion).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.Temperatura).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.VelocidadViento).HasColumnType("decimal(5, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
