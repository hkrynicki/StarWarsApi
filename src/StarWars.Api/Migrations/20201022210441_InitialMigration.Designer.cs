﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StarWars.Characters.Infrastructure;

namespace StarWars.Api.Migrations
{
    [DbContext(typeof(CharactersContext))]
    [Migration("20201022210441_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("Relational:Sequence:Characters.charactersseq", "'charactersseq', 'Characters', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StarWars.Characters.Domain.Character", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "charactersseq")
                        .HasAnnotation("SqlServer:HiLoSequenceSchema", "Characters")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Episodes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Characters","Characters");
                });

            modelBuilder.Entity("StarWars.Characters.Domain.Friendship", b =>
                {
                    b.Property<long>("Friend1Id")
                        .HasColumnType("bigint");

                    b.Property<long>("Friend2Id")
                        .HasColumnType("bigint");

                    b.HasKey("Friend1Id", "Friend2Id");

                    b.HasIndex("Friend2Id");

                    b.ToTable("Friendships","Characters");
                });

            modelBuilder.Entity("StarWars.Characters.Domain.Friendship", b =>
                {
                    b.HasOne("StarWars.Characters.Domain.Character", "Friend1")
                        .WithMany("Friendships")
                        .HasForeignKey("Friend1Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("StarWars.Characters.Domain.Character", "Friend2")
                        .WithMany("FriendshipsOf")
                        .HasForeignKey("Friend2Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
