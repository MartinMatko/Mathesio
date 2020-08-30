﻿// <auto-generated />
using System;
using InternetDiscussion.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InternetDiscussion.Migrations
{
    [DbContext(typeof(InternetDiscussionContext))]
    partial class InternetDiscussionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InternetDiscussion.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Ned",
                            LastName = "First"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Kiefer",
                            LastName = "Second"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Stan",
                            LastName = "Third"
                        });
                });

            modelBuilder.Entity("InternetDiscussion.Entities.Reply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(5000);

                    b.Property<int>("TopicId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("TopicId");

                    b.ToTable("Reply");
                });

            modelBuilder.Entity("InternetDiscussion.Entities.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(5000);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Topics");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            Description = "Of course, no other world was carried through the starry infinity on the backs of four giant elephants, who were themselves perched on the shell of a giant turtle. His name - or her name, according to another school of thought - was Great A'Tuin; he - or, as it might be she - will not take a central role in what follows but it is vital to an understanding of the Disc that he - or she - is there, down below the mines and sea ooze and fake fossil bones put there by a Creator with nothing better to do than upset archaeologists and give them silly ideas.",
                            Title = "Is Earth flat?"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 1,
                            Description = "Mine is Jurassic Park.",
                            Title = "Your favorite movie?"
                        });
                });

            modelBuilder.Entity("InternetDiscussion.Entities.Reply", b =>
                {
                    b.HasOne("InternetDiscussion.Entities.Author", null)
                        .WithMany("Replies")
                        .HasForeignKey("AuthorId");

                    b.HasOne("InternetDiscussion.Entities.Topic", "Topic")
                        .WithMany("Replies")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InternetDiscussion.Entities.Topic", b =>
                {
                    b.HasOne("InternetDiscussion.Entities.Author", "Author")
                        .WithMany("Topics")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
