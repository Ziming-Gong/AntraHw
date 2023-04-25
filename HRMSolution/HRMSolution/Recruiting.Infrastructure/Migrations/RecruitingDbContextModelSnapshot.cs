﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Recruiting.Infrastructure.Data;

#nullable disable

namespace Recruiting.Infrastructure.Migrations
{
    [DbContext(typeof(RecruitingDbContext))]
    partial class RecruitingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Recruiting.ApplicationCore.Entity.Candidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("ResumeURL")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.HasKey("Id");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("Recruiting.ApplicationCore.Entity.EmployeeRequirementType", b =>
                {
                    b.Property<int>("EmployeeTypeId")
                        .HasColumnType("int");

                    b.Property<int>("JobRequirementId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeTypeId", "JobRequirementId");

                    b.HasIndex("JobRequirementId");

                    b.ToTable("EmployeeRequirementType", (string)null);
                });

            modelBuilder.Entity("Recruiting.ApplicationCore.Entity.EmployeeType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EmployeeType");
                });

            modelBuilder.Entity("Recruiting.ApplicationCore.Entity.JobCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.ToTable("JobCategory");
                });

            modelBuilder.Entity("Recruiting.ApplicationCore.Entity.JobRequirement", b =>
                {
                    b.Property<int>("JobRequirementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobRequirementId"), 1L, 1);

                    b.Property<DateTime>("ClosedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ClosedReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(512)");

                    b.Property<int>("HiringManagerId")
                        .HasColumnType("int");

                    b.Property<string>("HiringManagerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("JobCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfPositions")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(512)");

                    b.HasKey("JobRequirementId");

                    b.HasIndex("JobCategoryId");

                    b.ToTable("JobRequirements");
                });

            modelBuilder.Entity("Recruiting.ApplicationCore.Entity.Submission", b =>
                {
                    b.Property<int>("SubmissionId")
                        .HasColumnType("int");

                    b.Property<int>("CandidateId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ConfirmedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("JobRequirementId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RejectedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("SubmissionStatusCode")
                        .HasColumnType("int");

                    b.Property<DateTime>("SubmittedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("SubmissionId");

                    b.HasIndex("CandidateId");

                    b.ToTable("Submission", (string)null);
                });

            modelBuilder.Entity("Recruiting.ApplicationCore.Entity.SubmissionStatus", b =>
                {
                    b.Property<int>("LookUpCode")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(512)");

                    b.HasKey("LookUpCode");

                    b.ToTable("SubmissionStatus");
                });

            modelBuilder.Entity("Recruiting.ApplicationCore.Entity.EmployeeRequirementType", b =>
                {
                    b.HasOne("Recruiting.ApplicationCore.Entity.EmployeeType", "EmployeeType")
                        .WithMany("EmployeeRequirementTypes")
                        .HasForeignKey("EmployeeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Recruiting.ApplicationCore.Entity.JobRequirement", "JobRequirement")
                        .WithMany("EmployeeRequirementTypes")
                        .HasForeignKey("JobRequirementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmployeeType");

                    b.Navigation("JobRequirement");
                });

            modelBuilder.Entity("Recruiting.ApplicationCore.Entity.JobRequirement", b =>
                {
                    b.HasOne("Recruiting.ApplicationCore.Entity.JobCategory", "JobCategory")
                        .WithMany("JobRequirements")
                        .HasForeignKey("JobCategoryId");

                    b.Navigation("JobCategory");
                });

            modelBuilder.Entity("Recruiting.ApplicationCore.Entity.Submission", b =>
                {
                    b.HasOne("Recruiting.ApplicationCore.Entity.Candidate", "Candidate")
                        .WithMany("Submissions")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Recruiting.ApplicationCore.Entity.JobRequirement", "JobRequirement")
                        .WithMany("Submissions")
                        .HasForeignKey("SubmissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("JobRequirement");
                });

            modelBuilder.Entity("Recruiting.ApplicationCore.Entity.SubmissionStatus", b =>
                {
                    b.HasOne("Recruiting.ApplicationCore.Entity.Submission", "Submission")
                        .WithMany("SubmissionStatusList")
                        .HasForeignKey("LookUpCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Submission");
                });

            modelBuilder.Entity("Recruiting.ApplicationCore.Entity.Candidate", b =>
                {
                    b.Navigation("Submissions");
                });

            modelBuilder.Entity("Recruiting.ApplicationCore.Entity.EmployeeType", b =>
                {
                    b.Navigation("EmployeeRequirementTypes");
                });

            modelBuilder.Entity("Recruiting.ApplicationCore.Entity.JobCategory", b =>
                {
                    b.Navigation("JobRequirements");
                });

            modelBuilder.Entity("Recruiting.ApplicationCore.Entity.JobRequirement", b =>
                {
                    b.Navigation("EmployeeRequirementTypes");

                    b.Navigation("Submissions");
                });

            modelBuilder.Entity("Recruiting.ApplicationCore.Entity.Submission", b =>
                {
                    b.Navigation("SubmissionStatusList");
                });
#pragma warning restore 612, 618
        }
    }
}
