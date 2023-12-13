using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SampleDBFirst.Models;

public partial class SampleEfdbContext : DbContext
{
    public SampleEfdbContext()
    {
    }

    public SampleEfdbContext(DbContextOptions<SampleEfdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasIndex(e => e.DepartmentId, "IX_Employees_DepartmentID");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);

            entity.HasOne(d => d.Department).WithMany(p => p.Employees).HasForeignKey(d => d.DepartmentId);

            entity.HasMany(d => d.ProjectsProjects).WithMany(p => p.EmployeesEmployees)
                .UsingEntity<Dictionary<string, object>>(
                    "EmployeeProject",
                    r => r.HasOne<Project>().WithMany().HasForeignKey("ProjectsProjectId"),
                    l => l.HasOne<Employee>().WithMany().HasForeignKey("EmployeesEmployeeId"),
                    j =>
                    {
                        j.HasKey("EmployeesEmployeeId", "ProjectsProjectId");
                        j.ToTable("EmployeeProject");
                        j.HasIndex(new[] { "ProjectsProjectId" }, "IX_EmployeeProject_ProjectsProjectID");
                        j.IndexerProperty<int>("EmployeesEmployeeId").HasColumnName("EmployeesEmployeeID");
                        j.IndexerProperty<int>("ProjectsProjectId").HasColumnName("ProjectsProjectID");
                    });
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.ToTable("Project");

            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
