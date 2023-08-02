﻿// <auto-generated />
using System;
using CustomerBliss.Infrastructure.Repositories.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CustomerBliss.Infrastructure.Migrations
{
    [DbContext(typeof(CustomerBlissContext))]
    [Migration("20230801234533_UpdateCustomer")]
    partial class UpdateCustomer
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CustomerBliss.Domain.Entities.Customers.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyDocument")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InitialDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastReviewDate")
                        .HasColumnType("datetime2");

                    b.Property<double?>("LastReviewScore")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CompanyName" }, "IX_CUSTOMERS_NAME");

                    b.ToTable("Customers", (string)null);
                });

            modelBuilder.Entity("CustomerBliss.Domain.Entities.Surveys.Survey", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Period")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Period" }, "IX_SURVEYS_PERIOD");

                    b.ToTable("Surveys", (string)null);
                });

            modelBuilder.Entity("CustomerBliss.Domain.Entities.Surveys.SurveyCustomerReview", b =>
                {
                    b.Property<Guid>("SurveyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReviewScore")
                        .HasColumnType("int");

                    b.HasKey("SurveyId", "CustomerId");

                    b.HasIndex("CustomerId");

                    b.ToTable("SurveysCustomerReview", (string)null);
                });

            modelBuilder.Entity("CustomerBliss.Domain.Entities.Surveys.SurveyCustomerReview", b =>
                {
                    b.HasOne("CustomerBliss.Domain.Entities.Customers.Customer", "Customer")
                        .WithMany("Reviews")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CustomerBliss.Domain.Entities.Surveys.Survey", "Survey")
                        .WithMany("Reviews")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Survey");
                });

            modelBuilder.Entity("CustomerBliss.Domain.Entities.Customers.Customer", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("CustomerBliss.Domain.Entities.Surveys.Survey", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
