﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using loja1.Data;

#nullable disable

namespace loja1.Migrations
{
    [DbContext(typeof(lojaDbContext))]
    [Migration("20231011144951_bora")]
    partial class bora
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Produtocarrinho", b =>
                {
                    b.Property<int>("ProdutosProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("carrinhoId")
                        .HasColumnType("int");

                    b.HasKey("ProdutosProdutoId", "carrinhoId");

                    b.HasIndex("carrinhoId");

                    b.ToTable("Produtocarrinho");
                });

            modelBuilder.Entity("loja1.Models.Produto", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Preco")
                        .HasColumnType("double");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("ProdutoId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("loja1.Models.carrinho", b =>
                {
                    b.Property<int>("carrinhoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("loginId")
                        .HasColumnType("int");

                    b.Property<double>("precototal")
                        .HasColumnType("double");

                    b.HasKey("carrinhoId");

                    b.HasIndex("loginId");

                    b.ToTable("carrinhos");
                });

            modelBuilder.Entity("loja1.Models.login", b =>
                {
                    b.Property<int>("loginId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("Usarname")
                        .HasColumnType("longtext");

                    b.HasKey("loginId");

                    b.ToTable("logins");
                });

            modelBuilder.Entity("Produtocarrinho", b =>
                {
                    b.HasOne("loja1.Models.Produto", null)
                        .WithMany()
                        .HasForeignKey("ProdutosProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("loja1.Models.carrinho", null)
                        .WithMany()
                        .HasForeignKey("carrinhoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("loja1.Models.carrinho", b =>
                {
                    b.HasOne("loja1.Models.login", "login")
                        .WithMany()
                        .HasForeignKey("loginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("login");
                });
#pragma warning restore 612, 618
        }
    }
}
