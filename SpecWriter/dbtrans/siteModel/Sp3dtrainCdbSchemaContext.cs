using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace dbtrans.siteModel;

public partial class Sp3dtrainCdbSchemaContext : DbContext
{
    public Sp3dtrainCdbSchemaContext()
    {
    }

    public Sp3dtrainCdbSchemaContext(DbContextOptions<Sp3dtrainCdbSchemaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CodelistTableInfoView> CodelistTableInfoViews { get; set; }

    public virtual DbSet<CodelistValueView> CodelistValueViews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=JIE-PC\\SQLEXPRESS;Database=SP3DTrain_CDB_SCHEMA;User Id=sa;Password=sa;Integrated Security=False;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CodelistTableInfoView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("CodelistTableInfoView");

            entity.Property(e => e.Author).HasMaxLength(255);
            entity.Property(e => e.ChildTableId).HasColumnName("ChildTableID");
            entity.Property(e => e.ChildTableName).HasMaxLength(255);
            entity.Property(e => e.ChildTableUsername).HasMaxLength(255);
            entity.Property(e => e.DateCreated).HasMaxLength(255);
            entity.Property(e => e.DateModified).HasMaxLength(255);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Namespace).HasMaxLength(64);
            entity.Property(e => e.Oid).HasColumnName("oid");
            entity.Property(e => e.ParentTableId).HasColumnName("ParentTableID");
            entity.Property(e => e.ParentTableName).HasMaxLength(255);
            entity.Property(e => e.ParentTableUserName).HasMaxLength(255);
            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.UserName).HasMaxLength(255);
        });

        modelBuilder.Entity<CodelistValueView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("CodelistValueView");

            entity.Property(e => e.Author).HasMaxLength(255);
            entity.Property(e => e.DateCreated).HasMaxLength(255);
            entity.Property(e => e.DateModified).HasMaxLength(255);
            entity.Property(e => e.LongStringValue).HasMaxLength(255);
            entity.Property(e => e.Namespace).HasMaxLength(64);
            entity.Property(e => e.Oid).HasColumnName("oid");
            entity.Property(e => e.ParentTableId).HasColumnName("ParentTableID");
            entity.Property(e => e.ParentTableName).HasMaxLength(255);
            entity.Property(e => e.ParentTableUserName).HasMaxLength(255);
            entity.Property(e => e.ParentValueId).HasColumnName("ParentValueID");
            entity.Property(e => e.ShortStringValue).HasMaxLength(255);
            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.TableName).HasMaxLength(255);
            entity.Property(e => e.TableUserName).HasMaxLength(255);
            entity.Property(e => e.ValueId).HasColumnName("ValueID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
