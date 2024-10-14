using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyLibrabry.Models;

public partial class EmployeeJobTitleContext : DbContext
{
    public EmployeeJobTitleContext()
    {
    }

    public EmployeeJobTitleContext(DbContextOptions<EmployeeJobTitleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Dbaccount> Dbaccounts { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<JobTitle> JobTitles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=(local);database=EmployeeJobTitle;uid=sa;pwd=123456;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dbaccount>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__DBAccoun__349DA586C9C985DC");

            entity.ToTable("DBAccount");

            entity.Property(e => e.AccountId)
                .HasMaxLength(20)
                .HasColumnName("AccountID");
            entity.Property(e => e.AccountPassword)
                .IsRequired()
                .HasMaxLength(80);
            entity.Property(e => e.FullName).HasMaxLength(100);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04FF1FA3E5A23");

            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId)
                .HasMaxLength(20)
                .HasColumnName("EmployeeID");
            entity.Property(e => e.DepartmentName).HasMaxLength(50);
            entity.Property(e => e.EmployeeName)
                .IsRequired()
                .HasMaxLength(120);
            entity.Property(e => e.JobTitleId)
                .HasMaxLength(20)
                .HasColumnName("JobTitleID");

            entity.HasOne(d => d.JobTitle).WithMany(p => p.Employees)
                .HasForeignKey(d => d.JobTitleId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Employee__JobTit__3B75D760");
        });

        modelBuilder.Entity<JobTitle>(entity =>
        {
            entity.HasKey(e => e.JobTitleId).HasName("PK__JobTitle__35382FC9020D686A");

            entity.ToTable("JobTitle");

            entity.Property(e => e.JobTitleId)
                .HasMaxLength(20)
                .HasColumnName("JobTitleID");
            entity.Property(e => e.JobTitleDescription).HasMaxLength(250);
            entity.Property(e => e.JobTitleName)
                .IsRequired()
                .HasMaxLength(80);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
