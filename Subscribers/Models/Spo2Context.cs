using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Subscribers.Models;

public partial class Spo2Context : DbContext
{
    public Spo2Context()
    {
    }

    public Spo2Context(DbContextOptions<Spo2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Analy> Analys { get; set; }

    public virtual DbSet<Expense> Expenses { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Subcrib> Subcribs { get; set; }

    public virtual DbSet<Subuser> Subusers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=SPO2;Username=postgres;Password=Misha1029!");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Analy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("analys_pk");

            entity.ToTable("analys");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Idexp).HasColumnName("idexp");

            entity.HasOne(d => d.IdexpNavigation).WithMany(p => p.Analies)
                .HasForeignKey(d => d.Idexp)
                .HasConstraintName("analys_expenses_fk");
        });

        modelBuilder.Entity<Expense>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("expenses_pk");

            entity.ToTable("expenses");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Idsub).HasColumnName("idsub");
            entity.Property(e => e.Iduser).HasColumnName("iduser");
            entity.Property(e => e.TotalCost).HasColumnName("total_cost");

            entity.HasOne(d => d.IdsubNavigation).WithMany(p => p.Expenses)
                .HasForeignKey(d => d.Idsub)
                .HasConstraintName("expenses_subcrib_fk");

            entity.HasOne(d => d.IduserNavigation).WithMany(p => p.Expenses)
                .HasForeignKey(d => d.Iduser)
                .HasConstraintName("expenses_user_fk");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("notification_pk");

            entity.ToTable("notification");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Idsub).HasColumnName("idsub");
            entity.Property(e => e.Iduser).HasColumnName("iduser");
            entity.Property(e => e.Messegetext)
                .HasColumnType("character varying")
                .HasColumnName("messegetext");

            entity.HasOne(d => d.IdsubNavigation).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.Idsub)
                .HasConstraintName("notification_subcrib_fk");

            entity.HasOne(d => d.IduserNavigation).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.Iduser)
                .HasConstraintName("notification_user_fk");
        });

        modelBuilder.Entity<Subcrib>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("newtable_pk");

            entity.ToTable("subcrib");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Discription)
                .HasColumnType("character varying")
                .HasColumnName("discription");
            entity.Property(e => e.Endtime).HasColumnName("endtime");
            entity.Property(e => e.Iduser).HasColumnName("iduser");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Type)
                .HasColumnType("character varying")
                .HasColumnName("type");

            entity.HasOne(d => d.IduserNavigation).WithMany(p => p.Subcribs)
                .HasForeignKey(d => d.Iduser)
                .HasConstraintName("subcrib_user_fk");
        });

        modelBuilder.Entity<Subuser>(entity =>
        {
            entity.HasKey(e => new { e.Iduser, e.Idsub }).HasName("subuser_pk");

            entity.ToTable("subuser");

            entity.Property(e => e.Iduser).HasColumnName("iduser");
            entity.Property(e => e.Idsub).HasColumnName("idsub");
            entity.Property(e => e.Endtime).HasColumnName("endtime");
            entity.Property(e => e.Starttime).HasColumnName("starttime");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_pk");

            entity.ToTable("user");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasColumnType("character varying")
                .HasColumnName("firstname");
            entity.Property(e => e.Password)
                .HasColumnType("character varying")
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasColumnType("character varying")
                .HasColumnName("phone_number");
            entity.Property(e => e.Secondname)
                .HasColumnType("character varying")
                .HasColumnName("secondname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
