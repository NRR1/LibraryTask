﻿using System;
using System.Collections.Generic;
using LibraryTask.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryTask.Data;

public partial class LibraryDbContext : DbContext
{
    public LibraryDbContext()
    {
    }

    public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LibraryDB;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.AutId).HasName("PK__Authors__D6A9C1EA45907E6D");

            entity.Property(e => e.AutId).HasColumnName("AutID");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__Book__3DE0C22783741A0F");

            entity.ToTable("Book");

            entity.Property(e => e.BookId).HasColumnName("BookID");

            entity.HasOne(d => d.BookAuthorNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.BookAuthor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Book__BookAuthor__29572725");

            entity.HasOne(d => d.BookGenreNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.BookGenre)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Book__BookGenre__286302EC");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("PK__Genre__0385055EEAFF5034");

            entity.ToTable("Genre");

            entity.Property(e => e.GenreId).HasColumnName("GenreID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}