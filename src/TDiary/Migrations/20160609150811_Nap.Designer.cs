﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TDiary.Migrations
{
    [DbContext(typeof(MigrationsContext))]
    [Migration("20160609150811_Nap")]
    partial class Nap
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901");

            modelBuilder.Entity("TDiary.Model.DiaryItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("SavePosition");

                    b.HasKey("Id");

                    b.ToTable("Experiences");

                    b.HasDiscriminator<string>("Discriminator").HasValue("DiaryItem");
                });

            modelBuilder.Entity("TDiary.Model.Chow", b =>
                {
                    b.HasBaseType("TDiary.Model.DiaryItem");

                    b.Property<string>("Description");

                    b.Property<string>("Location");

                    b.ToTable("Chow");

                    b.HasDiscriminator().HasValue("Chow");
                });

            modelBuilder.Entity("TDiary.Model.Sight", b =>
                {
                    b.HasBaseType("TDiary.Model.DiaryItem");

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.ToTable("Sight");

                    b.HasDiscriminator().HasValue("Sight");
                });

            modelBuilder.Entity("TDiary.Model.Trip", b =>
                {
                    b.HasBaseType("TDiary.Model.DiaryItem");

                    b.Property<int>("By");

                    b.Property<string>("From");

                    b.Property<string>("To");

                    b.ToTable("Trip");

                    b.HasDiscriminator().HasValue("Trip");
                });
        }
    }
}
