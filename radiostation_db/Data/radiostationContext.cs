using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using radiostation_db.Models;

namespace radiostation_db.Data
{
    public partial class radiostationContext : DbContext
    {
        public radiostationContext()
        {
        }

        public radiostationContext(DbContextOptions<radiostationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ГрафикРаботы> ГрафикРаботы { get; set; }
        public virtual DbSet<Должности> Должности { get; set; }
        public virtual DbSet<Жанры> Жанры { get; set; }
        public virtual DbSet<Записи> Записи { get; set; }
        public virtual DbSet<Исполнители> Исполнители { get; set; }
        public virtual DbSet<Сотрудники> Сотрудники { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("Data Source=D:\\radiostation.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ГрафикРаботы>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("График_работы");

                entity.Property(e => e.Время)
                    .HasColumnName("время_")
                    .HasColumnType("INT");

                entity.Property(e => e.Дата)
                    .IsRequired()
                    .HasColumnName("дата")
                    .HasColumnType("DATE");

                entity.Property(e => e.КодЗаписи)
                    .IsRequired()
                    .HasColumnName("код_записи")
                    .HasColumnType("NODATATYPE");

                entity.Property(e => e.КодСотрудника)
                    .IsRequired()
                    .HasColumnName("код_сотрудника")
                    .HasColumnType("NODATATYPE");

                entity.HasOne(d => d.КодЗаписиNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.КодЗаписи)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.КодСотрудникаNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.КодСотрудника)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Должности>(entity =>
            {
                entity.HasKey(e => e.КодДолжности);

                entity.Property(e => e.КодДолжности)
                    .HasColumnName("код_должности")
                    .HasColumnType("NODATATYPE");

                entity.Property(e => e.НаименованиеДолжности)
                    .IsRequired()
                    .HasColumnName("наименование_должности")
                    .HasColumnType("CHAR(15)");

                entity.Property(e => e.Обязанности)
                    .IsRequired()
                    .HasColumnName("обязанности")
                    .HasColumnType("VARCHAR(500)");

                entity.Property(e => e.Оклад)
                    .HasColumnName("оклад")
                    .HasColumnType("INT");

                entity.Property(e => e.Требования)
                    .IsRequired()
                    .HasColumnName("требования")
                    .HasColumnType("VARCHAR(500)");
            });

            modelBuilder.Entity<Жанры>(entity =>
            {
                entity.HasKey(e => e.КодЖанра);

                entity.HasIndex(e => e.Описание)
                    .IsUnique();

                entity.Property(e => e.КодЖанра)
                    .HasColumnName("код_жанра")
                    .HasColumnType("NODATATYPE");

                entity.Property(e => e.Наименование)
                    .IsRequired()
                    .HasColumnName("наименование")
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.Описание)
                    .IsRequired()
                    .HasColumnName("описание")
                    .HasColumnType("VARCHAR(120)");
            });

            modelBuilder.Entity<Записи>(entity =>
            {
                entity.HasKey(e => e.КодЗаписи);

                entity.HasIndex(e => e.Наименование)
                    .IsUnique();

                entity.Property(e => e.КодЗаписи)
                    .HasColumnName("код_записи")
                    .HasColumnType("NODATATYPE");

                entity.Property(e => e.Альбом)
                    .IsRequired()
                    .HasColumnName("альбом")
                    .HasColumnType("CHAR(10)");

                entity.Property(e => e.Год)
                    .IsRequired()
                    .HasColumnName("год")
                    .HasColumnType("DATE");

                entity.Property(e => e.ДатаЗаписи)
                    .IsRequired()
                    .HasColumnName("дата_записи")
                    .HasColumnType("DATE");

                entity.Property(e => e.Длительность)
                    .IsRequired()
                    .HasColumnName("длительность")
                    .HasColumnType("CHAR(10)");

                entity.Property(e => e.КодЖанра)
                    .IsRequired()
                    .HasColumnName("код_жанра")
                    .HasColumnType("NODATATYPE");

                entity.Property(e => e.КодИсполнителя)
                    .IsRequired()
                    .HasColumnName("код_исполнителя")
                    .HasColumnType("NODATATYPE");

                entity.Property(e => e.Наименование)
                    .IsRequired()
                    .HasColumnName("наименование")
                    .HasColumnType("CHAR(10)");

                entity.Property(e => e.Рейтинг)
                    .HasColumnName("рейтинг")
                    .HasColumnType("INT");

                entity.HasOne(d => d.КодЖанраNavigation)
                    .WithMany(p => p.Записи)
                    .HasForeignKey(d => d.КодЖанра)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.КодИсполнителяNavigation)
                    .WithMany(p => p.Записи)
                    .HasForeignKey(d => d.КодИсполнителя)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Исполнители>(entity =>
            {
                entity.HasKey(e => e.КодИсполнителя);

                entity.HasIndex(e => e.Описание)
                    .IsUnique();

                entity.Property(e => e.КодИсполнителя)
                    .HasColumnName("код_исполнителя")
                    .HasColumnType("NODATATYPE");

                entity.Property(e => e.Наименование)
                    .IsRequired()
                    .HasColumnName("наименование")
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.Описание)
                    .IsRequired()
                    .HasColumnName("описание")
                    .HasColumnType("VARCHAR(120)");
            });

            modelBuilder.Entity<Сотрудники>(entity =>
            {
                entity.HasKey(e => e.КодСотрудника);

                entity.HasIndex(e => e.Адрес)
                    .IsUnique();

                entity.HasIndex(e => e.ПаспортныеДанны)
                    .IsUnique();

                entity.HasIndex(e => e.Телефон)
                    .IsUnique();

                entity.Property(e => e.КодСотрудника)
                    .HasColumnName("код_сотрудника")
                    .HasColumnType("NODATATYPE");

                entity.Property(e => e.Адрес)
                    .IsRequired()
                    .HasColumnName("адрес")
                    .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.Возраст).HasColumnType("INT");

                entity.Property(e => e.КодДолжности)
                    .IsRequired()
                    .HasColumnName("код_должности")
                    .HasColumnType("NODATATYPE");

                entity.Property(e => e.ПаспортныеДанны)
                    .IsRequired()
                    .HasColumnName("паспортные_данны")
                    .HasColumnType("VARCHAR(500)");

                entity.Property(e => e.Пол)
                    .IsRequired()
                    .HasColumnName("пол")
                    .HasColumnType("CHAR(10)");

                entity.Property(e => e.Телефон)
                    .HasColumnName("телефон")
                    .HasColumnType("INT");

                entity.Property(e => e.Фио)
                    .IsRequired()
                    .HasColumnName("ФИО")
                    .HasColumnType("VARCHAR(100)");

                entity.HasOne(d => d.КодДолжностиNavigation)
                    .WithMany(p => p.Сотрудники)
                    .HasForeignKey(d => d.КодДолжности)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
