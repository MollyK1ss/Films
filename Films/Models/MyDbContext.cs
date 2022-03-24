using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Films.Models
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Creator> Creators { get; set; } = null!;
        public virtual DbSet<Film> Films { get; set; } = null!;
        public virtual DbSet<Poster> Posters { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost; Port=5432; User Id=postgres; Password=sa; Database=films");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Creator>(entity =>
            {
                entity.Property(e => e.Fio)
                    .HasColumnType("character varying")
                    .HasColumnName("FIO");
            });

            modelBuilder.Entity<Film>(entity =>
            {
                entity.Property(e => e.Description).HasColumnType("character varying");

                entity.Property(e => e.IdCreator).HasColumnName("Id_Creator");

                entity.Property(e => e.IdPoster).HasColumnName("Id_Poster");

                entity.Property(e => e.IdUser).HasColumnName("Id_User");

                entity.Property(e => e.Title).HasColumnType("character varying");

                entity.HasOne(d => d.IdCreatorNavigation)
                    .WithMany(p => p.Films)
                    .HasForeignKey(d => d.IdCreator)
                    .HasConstraintName("fk_films_creators_id");

                entity.HasOne(d => d.IdPosterNavigation)
                    .WithMany(p => p.Films)
                    .HasForeignKey(d => d.IdPoster)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_films_posters_id");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Films)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("fk_films_users_id");
            });

            modelBuilder.Entity<Poster>(entity =>
            {
                entity.Property(e => e.Path).HasColumnType("character varying");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Login).HasColumnType("character varying");

                entity.Property(e => e.Pass).HasColumnType("character varying");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
