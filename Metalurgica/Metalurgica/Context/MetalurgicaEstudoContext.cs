using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Metalurgica.Models;

public partial class MetalurgicaEstudoContext : DbContext
{
    public MetalurgicaEstudoContext()
    {
    }

    public MetalurgicaEstudoContext(DbContextOptions<MetalurgicaEstudoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<LmElemento> LmElementos { get; set; }

    public virtual DbSet<LmEmbalagem> LmEmbalagems { get; set; }

    public virtual DbSet<LmEmpresa> LmEmpresas { get; set; }

    public virtual DbSet<LmLote> LmLotes { get; set; }

    public virtual DbSet<LmProduto> LmProdutos { get; set; }

    public virtual DbSet<LmTipoUsuario> LmTipoUsuarios { get; set; }

    public virtual DbSet<LmUsuario> LmUsuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=metalurgica_estudo;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LmElemento>(entity =>
        {
            entity.HasKey(e => e.IdElemento).HasName("PK__LM_Eleme__D20D2C660D103320");

            entity.ToTable("LM_Elemento");

            entity.Property(e => e.IdElemento).HasColumnName("Id_Elemento");
            entity.Property(e => e.DsAstm)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Ds_ASTM");
            entity.Property(e => e.DsEspecificacao)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Ds_Especificacao");
            entity.Property(e => e.DsUltAlteracao)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Ds_UltAlteracao");
            entity.Property(e => e.DtAlteracao)
                .HasColumnType("datetime")
                .HasColumnName("Dt_Alteracao");
            entity.Property(e => e.DtCadastro)
                .HasColumnType("datetime")
                .HasColumnName("Dt_Cadastro");
            entity.Property(e => e.FlAtivo).HasColumnName("Fl_Ativo");
            entity.Property(e => e.NmNome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nm_Nome");
        });

        modelBuilder.Entity<LmEmbalagem>(entity =>
        {
            entity.HasKey(e => e.IdEmbalagem).HasName("PK__LM_Embal__0931670CAAEB6E72");

            entity.ToTable("LM_Embalagem");

            entity.Property(e => e.IdEmbalagem).HasColumnName("Id_Embalagem");
            entity.Property(e => e.DsUltAlteracao)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Ds_UltAlteracao");
            entity.Property(e => e.DtAlteracao)
                .HasColumnType("datetime")
                .HasColumnName("Dt_Alteracao");
            entity.Property(e => e.DtCadastro)
                .HasColumnType("datetime")
                .HasColumnName("Dt_Cadastro");
            entity.Property(e => e.FlAtivo).HasColumnName("Fl_Ativo");
            entity.Property(e => e.NmNome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nm_Nome");
        });

        modelBuilder.Entity<LmEmpresa>(entity =>
        {
            entity.HasKey(e => e.IdEmpresa).HasName("PK__LM_Empre__443B3D9D2278254F");

            entity.ToTable("LM_Empresa");

            entity.Property(e => e.IdEmpresa).HasColumnName("Id_Empresa");
            entity.Property(e => e.DsSegmento)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Ds_Segmento");
            entity.Property(e => e.DsUltAlteracao)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Ds_UltAlteracao");
            entity.Property(e => e.DtAlteracao)
                .HasColumnType("datetime")
                .HasColumnName("Dt_Alteracao");
            entity.Property(e => e.DtCadastro)
                .HasColumnType("datetime")
                .HasColumnName("Dt_Cadastro");
            entity.Property(e => e.FlAtivo).HasColumnName("Fl_Ativo");
            entity.Property(e => e.IdLote).HasColumnName("Id_Lote");
            entity.Property(e => e.NmNome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nm_Nome");

            entity.HasOne(d => d.IdLoteNavigation).WithMany(p => p.LmEmpresas)
                .HasForeignKey(d => d.IdLote)
                .HasConstraintName("FK__LM_Empres__Id_Lo__34C8D9D1");
        });

        modelBuilder.Entity<LmLote>(entity =>
        {
            entity.HasKey(e => e.IdLote).HasName("PK__LM_Lote__134A915DD474A53B");

            entity.ToTable("LM_Lote");

            entity.Property(e => e.IdLote).HasColumnName("Id_Lote");
            entity.Property(e => e.DsUltAlteracao)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Ds_UltAlteracao");
            entity.Property(e => e.DtAlteracao)
                .HasColumnType("datetime")
                .HasColumnName("Dt_Alteracao");
            entity.Property(e => e.DtCadastro)
                .HasColumnType("datetime")
                .HasColumnName("Dt_Cadastro");
            entity.Property(e => e.FlAtivo).HasColumnName("Fl_Ativo");
            entity.Property(e => e.IdEmbalagem).HasColumnName("Id_Embalagem");
            entity.Property(e => e.IdProduto).HasColumnName("Id_Produto");

            entity.HasOne(d => d.IdEmbalagemNavigation).WithMany(p => p.LmLotes)
                .HasForeignKey(d => d.IdEmbalagem)
                .HasConstraintName("FK__LM_Lote__Id_Emba__31EC6D26");

            entity.HasOne(d => d.IdProdutoNavigation).WithMany(p => p.LmLotes)
                .HasForeignKey(d => d.IdProduto)
                .HasConstraintName("FK__LM_Lote__Id_Prod__30F848ED");
        });

        modelBuilder.Entity<LmProduto>(entity =>
        {
            entity.HasKey(e => e.IdProduto).HasName("PK__LM_Produ__94E704D8B6CDCEEE");

            entity.ToTable("LM_Produto");

            entity.Property(e => e.IdProduto).HasColumnName("Id_Produto");
            entity.Property(e => e.DsUltAlteracao)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Ds_UltAlteracao");
            entity.Property(e => e.DtAlteracao)
                .HasColumnType("datetime")
                .HasColumnName("Dt_Alteracao");
            entity.Property(e => e.DtCadastro)
                .HasColumnType("datetime")
                .HasColumnName("Dt_Cadastro");
            entity.Property(e => e.FlAtivo).HasColumnName("Fl_Ativo");
            entity.Property(e => e.IdElemento).HasColumnName("Id_Elemento");
            entity.Property(e => e.NmNome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nm_Nome");

            entity.HasOne(d => d.IdElementoNavigation).WithMany(p => p.LmProdutos)
                .HasForeignKey(d => d.IdElemento)
                .HasConstraintName("FK__LM_Produt__Id_El__2C3393D0");
        });

        modelBuilder.Entity<LmTipoUsuario>(entity =>
        {
            entity.HasKey(e => e.IdTipoUsuario).HasName("PK__LM_TipoU__622D85ABFF3981B7");

            entity.ToTable("LM_TipoUsuario");

            entity.Property(e => e.IdTipoUsuario).HasColumnName("Id_TipoUsuario");
            entity.Property(e => e.DsUltAlteracao)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Ds_UltAlteracao");
            entity.Property(e => e.DtAlteracao)
                .HasColumnType("datetime")
                .HasColumnName("Dt_Alteracao");
            entity.Property(e => e.DtCadastro)
                .HasColumnType("datetime")
                .HasColumnName("Dt_Cadastro");
            entity.Property(e => e.FlAtivo).HasColumnName("Fl_Ativo");
            entity.Property(e => e.NmTitulo)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("Nm_Titulo");
        });

        modelBuilder.Entity<LmUsuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__LM_Usuar__63C76BE247D7B4AA");

            entity.ToTable("LM_Usuario");

            entity.HasIndex(e => e.DsEmail, "UQ__LM_Usuar__7937E3FC0F88B834").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");
            entity.Property(e => e.DsEmail)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("Ds_Email");
            entity.Property(e => e.DsSenha)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Ds_Senha");
            entity.Property(e => e.DsUltAlteracao)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Ds_UltAlteracao");
            entity.Property(e => e.DtAlteracao)
                .HasColumnType("datetime")
                .HasColumnName("Dt_Alteracao");
            entity.Property(e => e.DtCadastro)
                .HasColumnType("datetime")
                .HasColumnName("Dt_Cadastro");
            entity.Property(e => e.FlAtivo).HasColumnName("Fl_Ativo");
            entity.Property(e => e.IdTipoUsuario).HasColumnName("Id_TipoUsuario");
            entity.Property(e => e.NmNome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nm_Nome");

            entity.HasOne(d => d.IdTipoUsuarioNavigation).WithMany(p => p.LmUsuarios)
                .HasForeignKey(d => d.IdTipoUsuario)
                .HasConstraintName("FK__LM_Usuari__Id_Ti__276EDEB3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
