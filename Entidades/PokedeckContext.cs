using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Backend_PokeDeck.Entidades;

public partial class PokedeckContext : DbContext
{
    public PokedeckContext()
    {
    }

    public PokedeckContext(DbContextOptions<PokedeckContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Baraja> Barajas { get; set; }

    public virtual DbSet<Carta> Cartas { get; set; }

    public virtual DbSet<Favorito> Favoritos { get; set; }

    public virtual DbSet<Idioma> Idiomas { get; set; }

    public virtual DbSet<ImagenPerfil> ImagenPerfils { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Baraja>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("barajas");

            entity.HasIndex(e => e.IdUser, "ID_User");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.FechaCreacion).HasColumnName("fecha_Creacion");
            entity.Property(e => e.IdUser)
                .HasColumnType("int(11)")
                .HasColumnName("ID_User");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Barajas)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("barajas_ibfk_1");
        });

        modelBuilder.Entity<Carta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cartas");

            entity.HasIndex(e => e.IdBaraja, "ID_Baraja");

            entity.Property(e => e.Id)
                .HasMaxLength(11)
                .HasColumnName("ID");
            entity.Property(e => e.IdBaraja)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Baraja");

            //entity.HasOne(d => d.IdBarajaNavigation).WithMany(p => p.Carta)
            //    .HasForeignKey(d => d.IdBaraja)
            //    .HasConstraintName("cartas_ibfk_1");
        });

        modelBuilder.Entity<Favorito>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("favoritos");

            entity.HasIndex(e => e.IdUser, "ID_User");

            entity.Property(e => e.Id)
                .HasMaxLength(11)
                .HasColumnName("ID");
            entity.Property(e => e.IdUser)
                .HasColumnType("int(11)")
                .HasColumnName("ID_User");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Favoritos)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("favoritos_ibfk_1");
        });

        modelBuilder.Entity<Idioma>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("idiomas");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.NomIdioma)
                .HasMaxLength(50)
                .HasColumnName("nom_Idioma");
        });

        modelBuilder.Entity<ImagenPerfil>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("imagen_perfil");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Imagen).HasColumnName("imagen");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.IdIdioma, "ID_Idioma");

            entity.HasIndex(e => e.IdImagen, "ID_Imagen");

            entity.HasIndex(e => e.Usuario1, "Usuario").IsUnique();

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Apellido)
                .HasMaxLength(30)
                .HasColumnName("apellido");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(50)
                .HasColumnName("contrasena");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.IdIdioma)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Idioma");
            entity.Property(e => e.IdImagen)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Imagen");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .HasColumnName("nombre");
            entity.Property(e => e.Usuario1)
                .HasMaxLength(50)
                .HasColumnName("Usuario");

            entity.HasOne(d => d.IdIdiomaNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdIdioma)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("usuarios_ibfk_1");

            entity.HasOne(d => d.IdImagenNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdImagen)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("usuarios_ibfk_2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
