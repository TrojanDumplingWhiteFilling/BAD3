﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBGList_Chap6.Data;

#nullable disable

namespace MyBGList_Chap7.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240402204427_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyBGList.Models.BakingGood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateProduced")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("BakingGood");
                });

            modelBuilder.Entity("MyBGList.Models.BakingGoodBatch", b =>
                {
                    b.Property<int>("BatchId")
                        .HasColumnType("int");

                    b.Property<int>("BakingGoodId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("BatchId", "BakingGoodId");

                    b.HasIndex("BakingGoodId");

                    b.ToTable("BakingGoodBatch");
                });

            modelBuilder.Entity("MyBGList.Models.Batch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ActualEndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Batch");
                });

            modelBuilder.Entity("MyBGList.Models.BatchStock", b =>
                {
                    b.Property<int>("BatchId")
                        .HasColumnType("int");

                    b.Property<int>("StockId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("BatchId", "StockId");

                    b.HasIndex("StockId");

                    b.ToTable("BatchStock");
                });

            modelBuilder.Entity("MyBGList.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeliveryPlace")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("MyBGList.Models.OrderBakingGood", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("BakingGoodId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "BakingGoodId");

                    b.HasIndex("BakingGoodId");

                    b.ToTable("OrderBakingGood");
                });

            modelBuilder.Entity("MyBGList.Models.Packet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("TrackId")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Packet");
                });

            modelBuilder.Entity("MyBGList.Models.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("MyBGList.Models.BakingGoodBatch", b =>
                {
                    b.HasOne("MyBGList.Models.BakingGood", "BakingGood")
                        .WithMany("BakingGoodBatches")
                        .HasForeignKey("BakingGoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBGList.Models.Batch", "Batch")
                        .WithMany("BakingGoodBatches")
                        .HasForeignKey("BatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BakingGood");

                    b.Navigation("Batch");
                });

            modelBuilder.Entity("MyBGList.Models.BatchStock", b =>
                {
                    b.HasOne("MyBGList.Models.Batch", "Batch")
                        .WithMany("BatchStocks")
                        .HasForeignKey("BatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBGList.Models.Stock", "Stock")
                        .WithMany("BatchStocks")
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Batch");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("MyBGList.Models.OrderBakingGood", b =>
                {
                    b.HasOne("MyBGList.Models.BakingGood", "BakingGood")
                        .WithMany("OrderBakingGoods")
                        .HasForeignKey("BakingGoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBGList.Models.Order", "Order")
                        .WithMany("OrderBakingGoods")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BakingGood");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("MyBGList.Models.Packet", b =>
                {
                    b.HasOne("MyBGList.Models.Order", "Order")
                        .WithMany("Packets")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("MyBGList.Models.BakingGood", b =>
                {
                    b.Navigation("BakingGoodBatches");

                    b.Navigation("OrderBakingGoods");
                });

            modelBuilder.Entity("MyBGList.Models.Batch", b =>
                {
                    b.Navigation("BakingGoodBatches");

                    b.Navigation("BatchStocks");
                });

            modelBuilder.Entity("MyBGList.Models.Order", b =>
                {
                    b.Navigation("OrderBakingGoods");

                    b.Navigation("Packets");
                });

            modelBuilder.Entity("MyBGList.Models.Stock", b =>
                {
                    b.Navigation("BatchStocks");
                });
#pragma warning restore 612, 618
        }
    }
}