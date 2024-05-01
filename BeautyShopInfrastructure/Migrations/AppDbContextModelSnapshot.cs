﻿// <auto-generated />
using System;
using BeautyShopInfrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BeautyShopInfrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BeautyShopDomain.Entities.ContactUs.ContactUs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSeen")
                        .HasColumnType("bit");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ContactUs");
                });

            modelBuilder.Entity("BeautyShopDomain.Entities.Order.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BeautyShopDomain.Entities.Order.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int>("OrderCount")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductItemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductItemId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("BeautyShopDomain.Entities.Product.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = -2,
                            CreateDate = new DateTime(2024, 5, 2, 0, 19, 56, 470, DateTimeKind.Local).AddTicks(6668),
                            IsDelete = false,
                            Name = "آرایشی"
                        },
                        new
                        {
                            Id = -1,
                            CreateDate = new DateTime(2024, 5, 2, 0, 19, 56, 470, DateTimeKind.Local).AddTicks(6674),
                            IsDelete = false,
                            Name = "بهداشتی"
                        },
                        new
                        {
                            Id = -4,
                            CreateDate = new DateTime(2024, 5, 2, 0, 19, 56, 470, DateTimeKind.Local).AddTicks(6677),
                            IsDelete = false,
                            Name = "زیردسته بندی آرایشی",
                            ParentId = -2
                        },
                        new
                        {
                            Id = -3,
                            CreateDate = new DateTime(2024, 5, 2, 0, 19, 56, 470, DateTimeKind.Local).AddTicks(6680),
                            IsDelete = false,
                            Name = "زیردسته بندی بهداشتی",
                            ParentId = -1
                        });
                });

            modelBuilder.Entity("BeautyShopDomain.Entities.Product.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DiscountPercentage")
                        .HasColumnType("int");

                    b.Property<string>("GeneralImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = -4,
                            CategoryId = -4,
                            CreateDate = new DateTime(2024, 5, 2, 0, 19, 56, 470, DateTimeKind.Local).AddTicks(7704),
                            Description = "",
                            DiscountPercentage = 10,
                            IsDelete = false,
                            Name = "Product4",
                            Price = 1000
                        },
                        new
                        {
                            Id = -3,
                            CategoryId = -3,
                            CreateDate = new DateTime(2024, 5, 2, 0, 19, 56, 470, DateTimeKind.Local).AddTicks(7716),
                            Description = "",
                            DiscountPercentage = 10,
                            IsDelete = false,
                            Name = "Product3",
                            Price = 1000
                        },
                        new
                        {
                            Id = -2,
                            CategoryId = -4,
                            CreateDate = new DateTime(2024, 5, 2, 0, 19, 56, 470, DateTimeKind.Local).AddTicks(7719),
                            Description = "",
                            DiscountPercentage = 10,
                            IsDelete = false,
                            Name = "Product2",
                            Price = 2000
                        },
                        new
                        {
                            Id = -1,
                            CategoryId = -3,
                            CreateDate = new DateTime(2024, 5, 2, 0, 19, 56, 470, DateTimeKind.Local).AddTicks(7722),
                            Description = "",
                            DiscountPercentage = 10,
                            IsDelete = false,
                            Name = "Product1",
                            Price = 2000
                        });
                });

            modelBuilder.Entity("BeautyShopDomain.Entities.Product.ProductFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductFeatures");
                });

            modelBuilder.Entity("BeautyShopDomain.Entities.Product.ProductItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductItems");
                });

            modelBuilder.Entity("BeautyShopDomain.Entities.User.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("UniqueName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            CreateDate = new DateTime(2024, 5, 2, 0, 19, 56, 470, DateTimeKind.Local).AddTicks(6450),
                            IsDelete = false,
                            UniqueName = "Admin"
                        });
                });

            modelBuilder.Entity("BeautyShopDomain.Entities.User.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            CreateDate = new DateTime(2024, 5, 2, 0, 19, 56, 470, DateTimeKind.Local).AddTicks(6746),
                            IsDelete = false,
                            MobileNumber = "09141001010",
                            Password = "20-08-20-E3-22-78-15-ED-17-56-A6-B5-31-E7-E0-D2",
                            Username = "Admin"
                        });
                });

            modelBuilder.Entity("BeautyShopDomain.Entities.User.UserSelectedRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserSelectedRoles");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            CreateDate = new DateTime(2024, 5, 2, 0, 19, 56, 470, DateTimeKind.Local).AddTicks(6715),
                            IsDelete = false,
                            RoleId = -1,
                            UserId = -1
                        });
                });

            modelBuilder.Entity("BeautyShopDomain.Entities.Order.Order", b =>
                {
                    b.HasOne("BeautyShopDomain.Entities.User.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BeautyShopDomain.Entities.Order.OrderItem", b =>
                {
                    b.HasOne("BeautyShopDomain.Entities.Order.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeautyShopDomain.Entities.Product.ProductItem", "ProductItem")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("ProductItem");
                });

            modelBuilder.Entity("BeautyShopDomain.Entities.Product.Product", b =>
                {
                    b.HasOne("BeautyShopDomain.Entities.Product.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BeautyShopDomain.Entities.Product.ProductFeature", b =>
                {
                    b.HasOne("BeautyShopDomain.Entities.Product.Product", "Product")
                        .WithMany("ProductFeatures")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("BeautyShopDomain.Entities.Product.ProductItem", b =>
                {
                    b.HasOne("BeautyShopDomain.Entities.Product.Product", "Product")
                        .WithMany("ProductItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("BeautyShopDomain.Entities.User.UserSelectedRole", b =>
                {
                    b.HasOne("BeautyShopDomain.Entities.User.Role", "Role")
                        .WithMany("UserSelectedRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeautyShopDomain.Entities.User.User", "User")
                        .WithMany("UserSelectedRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BeautyShopDomain.Entities.Order.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("BeautyShopDomain.Entities.Product.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("BeautyShopDomain.Entities.Product.Product", b =>
                {
                    b.Navigation("ProductFeatures");

                    b.Navigation("ProductItems");
                });

            modelBuilder.Entity("BeautyShopDomain.Entities.Product.ProductItem", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("BeautyShopDomain.Entities.User.Role", b =>
                {
                    b.Navigation("UserSelectedRoles");
                });

            modelBuilder.Entity("BeautyShopDomain.Entities.User.User", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("UserSelectedRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
