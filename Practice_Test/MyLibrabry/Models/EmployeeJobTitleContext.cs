using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MyLibrabry.Models
{
    public partial class EmployeeJobTitleContext : DbContext
    {
        public EmployeeJobTitleContext()
        {
        }

        public EmployeeJobTitleContext(DbContextOptions<EmployeeJobTitleContext> options)
            : base(options)
        {
        }

        public EmployeeJobTitleContext(string connectionStrings)
        {
            this.Database.SetConnectionString(connectionStrings);
        }

        public virtual DbSet<Dbaccount> Dbaccounts { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<JobTitle> JobTitles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local);Uid=sa;Pwd=12345;Database=EmployeeJobTitle");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Dbaccount>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PK__DBAccoun__349DA5869004CFE2");

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

                entity.HasOne(d => d.JobTitle)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.JobTitleId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Employee__JobTit__276EDEB3");
            });

            modelBuilder.Entity<JobTitle>(entity =>
            {
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
}
