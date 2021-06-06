﻿// <auto-generated />
using System;
using CodingTest.EF_Operation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CodingTest.Migrations
{
    [DbContext(typeof(CodingTestDbContext))]
    partial class CodingTestDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CodingTest.Models.EmployeeAssignedReview", b =>
                {
                    b.Property<Guid>("ReviewerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ToBeReviewedId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AssignedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AssignedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ReviewerId", "ToBeReviewedId", "AssignedById");

                    b.HasIndex("AssignedById");

                    b.HasIndex("ToBeReviewedId");

                    b.ToTable("EmployeeAssignedReviews");
                });

            modelBuilder.Entity("CodingTest.Models.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FeedBack")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("GotReviewedId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Point")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReviewedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ReviewerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GotReviewedId");

                    b.HasIndex("ReviewerId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("CodingTest.Models.Users", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AddedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Sex")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CodingTest.Models.EmployeeAssignedReview", b =>
                {
                    b.HasOne("CodingTest.Models.Users", "AssignedBy")
                        .WithMany()
                        .HasForeignKey("AssignedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodingTest.Models.Users", "Reviewer")
                        .WithMany("ReviewerEmployee")
                        .HasForeignKey("ReviewerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CodingTest.Models.Users", "ToBeReviewed")
                        .WithMany("EmployeeToBeReviewed")
                        .HasForeignKey("ToBeReviewedId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AssignedBy");

                    b.Navigation("Reviewer");

                    b.Navigation("ToBeReviewed");
                });

            modelBuilder.Entity("CodingTest.Models.Review", b =>
                {
                    b.HasOne("CodingTest.Models.Users", "GotReviewed")
                        .WithMany("ListOFReviewed")
                        .HasForeignKey("GotReviewedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodingTest.Models.Users", "Reviewer")
                        .WithMany("ListOfReviewer")
                        .HasForeignKey("ReviewerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("GotReviewed");

                    b.Navigation("Reviewer");
                });

            modelBuilder.Entity("CodingTest.Models.Users", b =>
                {
                    b.Navigation("EmployeeToBeReviewed");

                    b.Navigation("ListOFReviewed");

                    b.Navigation("ListOfReviewer");

                    b.Navigation("ReviewerEmployee");
                });
#pragma warning restore 612, 618
        }
    }
}
