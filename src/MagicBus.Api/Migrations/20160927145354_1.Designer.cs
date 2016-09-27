using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MagicBus.Api;

namespace MagicBus.Api.Migrations
{
    [DbContext(typeof(MigrationsContext))]
    [Migration("20160927145354_1")]
    partial class _1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("MagicBus.Model.Experience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int?>("JourneyId");

                    b.Property<int>("Rating");

                    b.Property<int>("SavePosition");

                    b.HasKey("Id");

                    b.HasIndex("JourneyId");

                    b.ToTable("Experiences");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Experience");
                });

            modelBuilder.Entity("MagicBus.Model.Journey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Journeys");
                });

            modelBuilder.Entity("MagicBus.Model.Chow", b =>
                {
                    b.HasBaseType("MagicBus.Model.Experience");

                    b.Property<string>("Description");

                    b.Property<string>("Location");

                    b.ToTable("Chow");

                    b.HasDiscriminator().HasValue("Chow");
                });

            modelBuilder.Entity("MagicBus.Model.Nap", b =>
                {
                    b.HasBaseType("MagicBus.Model.Experience");

                    b.Property<string>("Description");

                    b.Property<string>("Location");

                    b.ToTable("Nap");

                    b.HasDiscriminator().HasValue("Nap");
                });

            modelBuilder.Entity("MagicBus.Model.Sight", b =>
                {
                    b.HasBaseType("MagicBus.Model.Experience");

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.ToTable("Sight");

                    b.HasDiscriminator().HasValue("Sight");
                });

            modelBuilder.Entity("MagicBus.Model.Trip", b =>
                {
                    b.HasBaseType("MagicBus.Model.Experience");

                    b.Property<int>("By");

                    b.Property<string>("From");

                    b.Property<string>("To");

                    b.ToTable("Trip");

                    b.HasDiscriminator().HasValue("Trip");
                });

            modelBuilder.Entity("MagicBus.Model.Experience", b =>
                {
                    b.HasOne("MagicBus.Model.Journey", "Journey")
                        .WithMany("Experiences")
                        .HasForeignKey("JourneyId");
                });
        }
    }
}
