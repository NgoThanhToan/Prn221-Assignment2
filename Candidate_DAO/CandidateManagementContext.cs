﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Candidate_BussinessObjects;

namespace Candidate_DAO;

public partial class CandidateManagementContext : DbContext
{
    public CandidateManagementContext()
    {
    }

    public CandidateManagementContext(DbContextOptions<CandidateManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CandidateProfile> CandidateProfiles { get; set; }

    public virtual DbSet<Hraccount> Hraccounts { get; set; }

    public virtual DbSet<JobPosting> JobPostings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-905695AJ\\SQLEXPRESS;Uid=sa;Pwd=12345;Database=CandidateManagement;TrustServerCertificate=True");
        }


    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    if (!optionsBuilder.IsConfigured)
    //    {
    //        optionsBuilder.UseSqlServer

    //               ("Server=LAPTOP-905695AJ\\SQLEXPRESS;Uid=sa;Pwd=12345;Database=CandidateManagement;TrustServerCertificate=True");
    //    }


    //}




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CandidateProfile>(entity =>
        {
            entity.HasKey(e => e.CandidateId).HasName("PK__Candidat__DF539BFCF954A00A");

            entity.ToTable("CandidateProfile");

            entity.Property(e => e.CandidateId)
                .HasMaxLength(20)
                .HasColumnName("CandidateID");
            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.Fullname).HasMaxLength(100);

            entity.Property(e => e.PostingId)
                .HasMaxLength(20)
                .HasColumnName("PostingID");
            entity.Property(e => e.ProfileShortDescription).HasMaxLength(250);
            entity.Property(e => e.ProfileUrl)
                .HasMaxLength(150)
                .HasColumnName("ProfileURL");

            entity.HasOne(d => d.Posting).WithMany(p => p.CandidateProfiles)
                .HasForeignKey(d => d.PostingId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Candidate__Posti__267ABA7A");
        });

        modelBuilder.Entity<Hraccount>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("PK__HRAccoun__A9D105355798B4DC");

            entity.ToTable("HRAccount");

            entity.Property(e => e.Email).HasMaxLength(20);
            entity.Property(e => e.FullName).HasMaxLength(30);
            entity.Property(e => e.Password).HasMaxLength(40);
        });

        modelBuilder.Entity<JobPosting>(entity =>
        {
            entity.HasKey(e => e.PostingId).HasName("PK__JobPosti__C31796A5645ED6E7");

            entity.ToTable("JobPosting");

            entity.Property(e => e.PostingId)
                .HasMaxLength(20)
                .HasColumnName("PostingID");
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.JobPostingTitle).HasMaxLength(100);
            entity.Property(e => e.PostedDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
