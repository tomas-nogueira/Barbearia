﻿// <auto-generated />
using System;
using Barbearia.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Barbearia.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20231018142631_Criacao-Certa")]
    partial class CriacaoCerta
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Barbearia.Models.Agendamento", b =>
                {
                    b.Property<int>("AgendamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AgendamentoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AgendamentoId"));

                    b.Property<DateTime>("HorarioAgendamento")
                        .HasColumnType("datetime2")
                        .HasColumnName("HorarioAgendamento");

                    b.Property<int>("ServiceSalaoId")
                        .HasColumnType("int");

                    b.HasKey("AgendamentoId");

                    b.HasIndex("ServiceSalaoId");

                    b.ToTable("Agendamento");
                });

            modelBuilder.Entity("Barbearia.Models.Salao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SalaoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BairroSalao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("BairroSalao");

                    b.Property<string>("CepSalao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CepSalao");

                    b.Property<string>("CidadeSalao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CidadeSalao");

                    b.Property<string>("NameSalao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NameSalao");

                    b.Property<int>("NumeroSalao")
                        .HasColumnType("int")
                        .HasColumnName("NumeroSalao");

                    b.Property<string>("RuaSalao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("RuaSalao");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Salao");
                });

            modelBuilder.Entity("Barbearia.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ServiceId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NameService")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NameService");

                    b.Property<double>("TimeService")
                        .HasColumnType("float")
                        .HasColumnName("TimeService");

                    b.HasKey("Id");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("Barbearia.Models.ServiceSalao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ServiceSalaoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("SalaoId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SalaoId");

                    b.HasIndex("ServiceId");

                    b.ToTable("ServiceSalao");
                });

            modelBuilder.Entity("Barbearia.Models.TipoDocumento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TipoDocumentoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TipodeDocumento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TipodeDocumento");

                    b.HasKey("Id");

                    b.ToTable("TipoDocumento");
                });

            modelBuilder.Entity("Barbearia.Models.TypeUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TypeUserId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TypeNameUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TypeNameUser");

                    b.HasKey("Id");

                    b.ToTable("TypeUser");
                });

            modelBuilder.Entity("Barbearia.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DocumentoUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DocumentoUser");

                    b.Property<string>("EmailUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("EmailUser");

                    b.Property<string>("NameUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NameUser");

                    b.Property<string>("SenhaUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("SenhaUser");

                    b.Property<string>("TelUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TelUser");

                    b.Property<int>("TipoDocumentoId")
                        .HasColumnType("int");

                    b.Property<int>("TypeUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoDocumentoId");

                    b.HasIndex("TypeUserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Barbearia.Models.Agendamento", b =>
                {
                    b.HasOne("Barbearia.Models.ServiceSalao", "ServiceSalao")
                        .WithMany()
                        .HasForeignKey("ServiceSalaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ServiceSalao");
                });

            modelBuilder.Entity("Barbearia.Models.Salao", b =>
                {
                    b.HasOne("Barbearia.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Barbearia.Models.ServiceSalao", b =>
                {
                    b.HasOne("Barbearia.Models.Salao", "Salao")
                        .WithMany()
                        .HasForeignKey("SalaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Barbearia.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Salao");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Barbearia.Models.User", b =>
                {
                    b.HasOne("Barbearia.Models.TipoDocumento", "TipoDocumento")
                        .WithMany()
                        .HasForeignKey("TipoDocumentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Barbearia.Models.TypeUser", "TypeUser")
                        .WithMany()
                        .HasForeignKey("TypeUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoDocumento");

                    b.Navigation("TypeUser");
                });
#pragma warning restore 612, 618
        }
    }
}