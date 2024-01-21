﻿// <auto-generated />
using Grace_Project.Infastructure.Persitance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Grace_Project.Infastructure.Migrations
{
    [DbContext(typeof(GraceProjectDbContext))]
    partial class GraceProjectDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Grace_Project.Domain.Entities.Bepul_kurs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QushilganlarSoni")
                        .HasColumnType("int");

                    b.Property<int>("VideoSoni")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BepulKurs");
                });

            modelBuilder.Entity("Grace_Project.Domain.Entities.Ochniy_kurs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Narxi")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("QushilganlarSoni")
                        .HasColumnType("int");

                    b.Property<int>("VideoSoni")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("OchniyKurs");
                });

            modelBuilder.Entity("Grace_Project.Domain.Entities.Onlayn_kurs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Narxi")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("QushilganlarSoni")
                        .HasColumnType("int");

                    b.Property<int>("VideoSoni")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("OnlaynKurs");
                });

            modelBuilder.Entity("Grace_Project.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("BepulKurs")
                        .HasColumnType("bit");

                    b.Property<string>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("OchniyKurs")
                        .HasColumnType("bit");

                    b.Property<bool>("OnlaynKurs")
                        .HasColumnType("bit");

                    b.Property<int>("OnlaynKursId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
