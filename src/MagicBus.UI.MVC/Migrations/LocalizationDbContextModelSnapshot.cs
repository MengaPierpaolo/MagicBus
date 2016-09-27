using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MagicBus.Migrations;

namespace MagicBus.UI.MVC.Migrations
{
    [DbContext(typeof(LocalizationDbContext))]
    partial class LocalizationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("MagicBus.MyStringData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CultureName");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("LocalizedStrings");
                });
        }
    }
}
