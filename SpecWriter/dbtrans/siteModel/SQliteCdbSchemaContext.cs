using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace dbtrans.siteModel;

public partial class SQliteCdbSchemaContext : DbContext
{
    public SQliteCdbSchemaContext()
    {
    }

    public SQliteCdbSchemaContext(DbContextOptions<SQliteCdbSchemaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CodelistTableInfoView> CodelistTableInfoViews { get; set; }

    public virtual DbSet<CodelistValueView> CodelistValueViews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlite("Data Source=CDB.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CodelistTableInfoView>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CodelistTableInfoView");

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
                .ToTable("CodelistValueView");

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
