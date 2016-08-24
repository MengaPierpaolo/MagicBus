using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TDiary;

namespace TDiary.Api.Migrations
{
    [DbContext(typeof(MigrationsContext))]
    partial class MigrationsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("TDiary.Model.Experience", b =>
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

            modelBuilder.Entity("TDiary.Model.Journey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Journeys");
                });

            modelBuilder.Entity("TDiary.Model.Chow", b =>
                {
                    b.HasBaseType("TDiary.Model.Experience");

                    b.Property<string>("Description");

                    b.Property<string>("Location");

                    b.ToTable("Chow");

                    b.HasDiscriminator().HasValue("Chow");
                });

            modelBuilder.Entity("TDiary.Model.Nap", b =>
                {
                    b.HasBaseType("TDiary.Model.Experience");

                    b.Property<string>("Description");

                    b.Property<string>("Location");

                    b.ToTable("Nap");

                    b.HasDiscriminator().HasValue("Nap");
                });

            modelBuilder.Entity("TDiary.Model.Sight", b =>
                {
                    b.HasBaseType("TDiary.Model.Experience");

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.ToTable("Sight");

                    b.HasDiscriminator().HasValue("Sight");
                });

            modelBuilder.Entity("TDiary.Model.Trip", b =>
                {
                    b.HasBaseType("TDiary.Model.Experience");

                    b.Property<int>("By");

                    b.Property<string>("From");

                    b.Property<string>("To");

                    b.ToTable("Trip");

                    b.HasDiscriminator().HasValue("Trip");
                });

            modelBuilder.Entity("TDiary.Model.Experience", b =>
                {
                    b.HasOne("TDiary.Model.Journey", "Journey")
                        .WithMany("Experiences")
                        .HasForeignKey("JourneyId");
                });
        }
    }
}
