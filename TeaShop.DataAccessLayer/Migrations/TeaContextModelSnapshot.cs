﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TeaShop.DataAccessLayer.Concrete;

#nullable disable

namespace TeaShop.DataAccessLayer.Migrations
{
    [DbContext(typeof(TeaContext))]
    partial class TeaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TeaShop.EntityLayer.Concrete.About", b =>
                {
                    b.Property<int>("AboutID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AboutID"));

                    b.Property<string>("AboutDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AboutImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AboutStatus")
                        .HasColumnType("bit");

                    b.Property<string>("AboutTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsFooter")
                        .HasColumnType("bit");

                    b.Property<bool>("IsHome")
                        .HasColumnType("bit");

                    b.HasKey("AboutID");

                    b.ToTable("Abouts");
                });

            modelBuilder.Entity("TeaShop.EntityLayer.Concrete.Banner", b =>
                {
                    b.Property<int>("BannerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BannerID"));

                    b.Property<string>("BannerImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("BannerStatus")
                        .HasColumnType("bit");

                    b.Property<string>("BannerSubTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BannerTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsHome")
                        .HasColumnType("bit");

                    b.HasKey("BannerID");

                    b.ToTable("Banners");
                });

            modelBuilder.Entity("TeaShop.EntityLayer.Concrete.Contact", b =>
                {
                    b.Property<int>("ContactID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ContactStatus")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactID");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("TeaShop.EntityLayer.Concrete.Drink", b =>
                {
                    b.Property<int>("DrinkID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DrinkID"));

                    b.Property<string>("DrinkImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DrinkName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("DrinkPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("DrinkStatus")
                        .HasColumnType("bit");

                    b.Property<bool>("IsHome")
                        .HasColumnType("bit");

                    b.HasKey("DrinkID");

                    b.ToTable("Drinks");
                });

            modelBuilder.Entity("TeaShop.EntityLayer.Concrete.Map", b =>
                {
                    b.Property<int>("MapID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MapID"));

                    b.Property<string>("LocationURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("MapStatus")
                        .HasColumnType("bit");

                    b.HasKey("MapID");

                    b.ToTable("Maps");
                });

            modelBuilder.Entity("TeaShop.EntityLayer.Concrete.Message", b =>
                {
                    b.Property<int>("MessageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageID"));

                    b.Property<string>("MessageDetail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MessageEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MessageSendDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MessageSenderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("MessageStatus")
                        .HasColumnType("bit");

                    b.Property<string>("MessageSubject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MessageID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("TeaShop.EntityLayer.Concrete.Question", b =>
                {
                    b.Property<int>("QuestionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuestionID"));

                    b.Property<string>("AnswerDetail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsHome")
                        .HasColumnType("bit");

                    b.Property<string>("QuestionDetail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("QuestionStatus")
                        .HasColumnType("bit");

                    b.HasKey("QuestionID");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("TeaShop.EntityLayer.Concrete.SocialMedia", b =>
                {
                    b.Property<int>("SocialMediaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SocialMediaID"));

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SocialMediaStatus")
                        .HasColumnType("bit");

                    b.Property<string>("URL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SocialMediaID");

                    b.ToTable("SocialMedias");
                });

            modelBuilder.Entity("TeaShop.EntityLayer.Concrete.Subscribe", b =>
                {
                    b.Property<int>("SubscribeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubscribeID"));

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SubscribeStatus")
                        .HasColumnType("bit");

                    b.HasKey("SubscribeID");

                    b.ToTable("Subscribes");
                });

            modelBuilder.Entity("TeaShop.EntityLayer.Concrete.Testimonial", b =>
                {
                    b.Property<int>("TestimonialID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TestimonialID"));

                    b.Property<bool>("IsHome")
                        .HasColumnType("bit");

                    b.Property<string>("TestimonialComment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TestimonialImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TestimonialName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TestimonialStatus")
                        .HasColumnType("bit");

                    b.Property<string>("TestimonialTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TestimonialID");

                    b.ToTable("Testimonials");
                });
#pragma warning restore 612, 618
        }
    }
}
