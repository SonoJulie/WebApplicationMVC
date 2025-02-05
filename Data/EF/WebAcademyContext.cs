using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Data.EF;

public partial class WebAcademyContext : DbContext
{
    public WebAcademyContext()
    {
    }

    public WebAcademyContext(DbContextOptions<WebAcademyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Anagrafica> Anagrafica { get; set; }

    public virtual DbSet<DiarioAlimentare> DiarioAlimentare { get; set; }

    public virtual DbSet<SysGenere> SysGenere { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=;Initial Catalog=WebAcademy;User ID=;Password=;Persist Security Info=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Anagrafica>(entity =>
        {
            entity.Property(e => e.Altezza).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Cognome).HasMaxLength(50);
            entity.Property(e => e.Nome).HasMaxLength(50);
            entity.Property(e => e.Note).HasMaxLength(100);
            entity.Property(e => e.PesoAttuale).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.IdGenereNavigation).WithMany(p => p.Anagrafica)
                .HasForeignKey(d => d.IdGenere)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Anagrafica_SYS_Genere");
        });

        modelBuilder.Entity<DiarioAlimentare>(entity =>
        {
            entity.Property(e => e.Altezza).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.DataRegistrazione).HasColumnType("datetime");
            entity.Property(e => e.FAttivo)
                .HasDefaultValue(true)
                .HasColumnName("fAttivo");
            entity.Property(e => e.Peso).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.IdAnagraficaNavigation).WithMany(p => p.DiarioAlimentare)
                .HasForeignKey(d => d.IdAnagrafica)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DiarioAlimentare_Anagrafica");
        });

        modelBuilder.Entity<SysGenere>(entity =>
        {
            entity.ToTable("SYS_Genere");

            entity.Property(e => e.FAttivo)
                .HasDefaultValue(true)
                .HasColumnName("fAttivo");
            entity.Property(e => e.Genere).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
