using System;
using System.Collections.Generic;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Context;

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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=metalurgica_estudo;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LmElemento>(entity =>
        {
            entity.HasKey(e => e.IdElemento).HasName("PK__LM_Eleme__D20D2C66DDF6FD71");

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
            entity.HasKey(e => e.IdEmbalagem).HasName("PK__LM_Embal__0931670CFDD3FE02");

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
            entity.HasKey(e => e.IdEmpresa).HasName("PK__LM_Empre__443B3D9D092C23A8");

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
            entity.Property(e => e.NmNome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nm_Nome");
        });

        modelBuilder.Entity<LmLote>(entity =>
        {
            entity.HasKey(e => e.IdLote).HasName("PK__LM_Lote__134A915DC54EDBB7");

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
            entity.HasKey(e => e.IdProduto).HasName("PK__LM_Produ__94E704D8CA8D7AD8");

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
            entity.HasKey(e => e.IdTipoUsuario).HasName("PK__LM_TipoU__622D85AB53DF8EF0");

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
            entity.HasKey(e => e.IdUsuario).HasName("PK__LM_Usuar__63C76BE22B396751");

            entity.ToTable("LM_Usuario");

            entity.HasIndex(e => e.DsEmail, "UQ__LM_Usuar__7937E3FC592FA800").IsUnique();

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
