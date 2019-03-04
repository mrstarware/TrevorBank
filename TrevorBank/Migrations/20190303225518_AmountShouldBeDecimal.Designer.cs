﻿// <auto-generated />
using System;
using CoreContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace TrevorBank.Migrations
{
    [DbContext(typeof(BankContext))]
    [Migration("20190303225518_AmountShouldBeDecimal")]
    partial class AmountShouldBeDecimal
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreContext.BankContext+Address", b =>
                {
                    b.Property<int>("IdAddress")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<string>("Number");

                    b.Property<string>("State");

                    b.Property<string>("Street");

                    b.Property<string>("Zipcode");

                    b.HasKey("IdAddress");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("CoreContext.BankContext+BankClient", b =>
                {
                    b.Property<int>("IdCustomer")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("MiddleName");

                    b.Property<int?>("PrimaryAddressIdAddress");

                    b.HasKey("IdCustomer");

                    b.HasIndex("PrimaryAddressIdAddress");

                    b.ToTable("BankingClients");
                });

            modelBuilder.Entity("CoreContext.BankContext+Check", b =>
                {
                    b.Property<int>("IdCheck")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CheckDate");

                    b.Property<int>("CheckNumber");

                    b.Property<decimal>("DollarAmount");

                    b.Property<int>("IdCustomer");

                    b.Property<string>("Memo");

                    b.Property<string>("PayTo");

                    b.HasKey("IdCheck");

                    b.HasIndex("IdCustomer");

                    b.ToTable("Checks");
                });

            modelBuilder.Entity("CoreContext.BankContext+BankClient", b =>
                {
                    b.HasOne("CoreContext.BankContext+Address", "PrimaryAddress")
                        .WithMany()
                        .HasForeignKey("PrimaryAddressIdAddress");
                });

            modelBuilder.Entity("CoreContext.BankContext+Check", b =>
                {
                    b.HasOne("CoreContext.BankContext+BankClient")
                        .WithMany("Checks")
                        .HasForeignKey("IdCustomer")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
