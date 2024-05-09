﻿// <auto-generated />
using System;
using AppGroup.Financing.Infraesture.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppGroup.Financing.Infraesture.Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AppGroup.Financing.Domain.Entities.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Celular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("CriadoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ExcluidoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExcluidoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModificadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModificadoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Uf")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Cpf")
                        .IsUnique()
                        .HasFilter("[Cpf] IS NOT NULL");

                    b.ToTable("tb_clientes", (string)null);
                });

            modelBuilder.Entity("AppGroup.Financing.Domain.Entities.Emprestimo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("CriadoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ExcluidoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExcluidoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModificadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModificadoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PropostaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PropostaId");

                    b.ToTable("tb_emprestimos", (string)null);
                });

            modelBuilder.Entity("AppGroup.Financing.Domain.Entities.Parcela", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("CriadoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DataPagamento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EmprestimoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ExcluidoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExcluidoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModificadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModificadoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroParcela")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorParcela")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)");

                    b.HasKey("Id");

                    b.HasIndex("EmprestimoId");

                    b.ToTable("tb_parcelas", (string)null);
                });

            modelBuilder.Entity("AppGroup.Financing.Domain.Entities.Proposta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("CriadoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ExcluidoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExcluidoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModificadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModificadoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroParcelas")
                        .HasColumnType("int");

                    b.Property<DateTime>("PrimeiroVencimento")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("TipoCreditoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UltimoVencimento")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ValorEmprestimo")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)");

                    b.Property<decimal>("ValorParcela")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)");

                    b.Property<decimal>("ValorTotal")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("TipoCreditoId");

                    b.ToTable("tb_propostas", (string)null);
                });

            modelBuilder.Entity("AppGroup.Financing.Domain.Entities.TipoCredito", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("CriadoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ExcluidoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExcluidoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModificadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModificadoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Taxa")
                        .HasColumnType("float");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("tb_tipos_creditos", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("727f4ac0-6fb8-4087-86a6-1ae85cae4024"),
                            CriadoEm = new DateTime(2024, 5, 8, 23, 12, 12, 515, DateTimeKind.Utc).AddTicks(6339),
                            Taxa = 2.0,
                            Tipo = 1
                        },
                        new
                        {
                            Id = new Guid("92318cf3-daf6-4ffc-a513-c38fae46b19d"),
                            CriadoEm = new DateTime(2024, 5, 8, 23, 12, 12, 515, DateTimeKind.Utc).AddTicks(6360),
                            Taxa = 1.0,
                            Tipo = 2
                        },
                        new
                        {
                            Id = new Guid("3c040bfd-8b07-4d5b-9b9e-c5b43e7e22a4"),
                            CriadoEm = new DateTime(2024, 5, 8, 23, 12, 12, 515, DateTimeKind.Utc).AddTicks(6386),
                            Taxa = 5.0,
                            Tipo = 3
                        },
                        new
                        {
                            Id = new Guid("d54b44aa-f77a-48fd-ab6c-e98925767a81"),
                            CriadoEm = new DateTime(2024, 5, 8, 23, 12, 12, 515, DateTimeKind.Utc).AddTicks(6395),
                            Taxa = 3.0,
                            Tipo = 4
                        },
                        new
                        {
                            Id = new Guid("5bf61441-e127-493a-9aa7-d59303545597"),
                            CriadoEm = new DateTime(2024, 5, 8, 23, 12, 12, 515, DateTimeKind.Utc).AddTicks(6404),
                            Taxa = 9.0,
                            Tipo = 5
                        });
                });

            modelBuilder.Entity("AppGroup.Financing.Domain.Entities.Emprestimo", b =>
                {
                    b.HasOne("AppGroup.Financing.Domain.Entities.Proposta", "Proposta")
                        .WithMany()
                        .HasForeignKey("PropostaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proposta");
                });

            modelBuilder.Entity("AppGroup.Financing.Domain.Entities.Parcela", b =>
                {
                    b.HasOne("AppGroup.Financing.Domain.Entities.Emprestimo", "Emprestimo")
                        .WithMany("Parcelas")
                        .HasForeignKey("EmprestimoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Financiamento_Parcelas");

                    b.Navigation("Emprestimo");
                });

            modelBuilder.Entity("AppGroup.Financing.Domain.Entities.Proposta", b =>
                {
                    b.HasOne("AppGroup.Financing.Domain.Entities.Cliente", "Cliente")
                        .WithMany("Propostas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Cliente_Propostas");

                    b.HasOne("AppGroup.Financing.Domain.Entities.TipoCredito", "TipoCredito")
                        .WithMany("Propostas")
                        .HasForeignKey("TipoCreditoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_TipoCredito_Propostas");

                    b.Navigation("Cliente");

                    b.Navigation("TipoCredito");
                });

            modelBuilder.Entity("AppGroup.Financing.Domain.Entities.Cliente", b =>
                {
                    b.Navigation("Propostas");
                });

            modelBuilder.Entity("AppGroup.Financing.Domain.Entities.Emprestimo", b =>
                {
                    b.Navigation("Parcelas");
                });

            modelBuilder.Entity("AppGroup.Financing.Domain.Entities.TipoCredito", b =>
                {
                    b.Navigation("Propostas");
                });
#pragma warning restore 612, 618
        }
    }
}