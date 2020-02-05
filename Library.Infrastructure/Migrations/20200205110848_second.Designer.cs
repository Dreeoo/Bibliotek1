﻿// <auto-generated />
using System;
using Library.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Library.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200205110848_second")]
    partial class second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Library.Domain.Author", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(55)")
                        .HasMaxLength(55);

                    b.HasKey("ID");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "William Shakespeare"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Villiam Skakspjut"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Robert C. Martin"
                        });
                });

            modelBuilder.Entity("Library.Domain.BookCopy", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DetailsID")
                        .HasColumnType("int");

                    b.Property<int?>("LoanID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DetailsID");

                    b.HasIndex("LoanID");

                    b.ToTable("BookCopy");
                });

            modelBuilder.Entity("Library.Domain.BookDetails", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AuthorID");

                    b.ToTable("BookDetails");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            AuthorID = 1,
                            Description = "Arguably Shakespeare's greatest tragedy",
                            ISBN = "1472518381",
                            Title = "Hamlet"
                        },
                        new
                        {
                            ID = 2,
                            AuthorID = 1,
                            Description = "King Lear is a tragedy written by William Shakespeare. It depicts the gradual descent into madness of the title character, after he disposes of his kingdom by giving bequests to two of his three daughters egged on by their continual flattery, bringing tragic consequences for all.",
                            ISBN = "9780141012292",
                            Title = "King Lear"
                        },
                        new
                        {
                            ID = 3,
                            AuthorID = 2,
                            Description = "An intense drama of love, deception, jealousy and destruction.",
                            ISBN = "1853260185",
                            Title = "Othello"
                        });
                });

            modelBuilder.Entity("Library.Domain.Loan", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Delayed")
                        .HasColumnType("bit");

                    b.Property<int>("Fine")
                        .HasColumnType("int");

                    b.Property<string>("LoanTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MemberID")
                        .HasColumnType("int");

                    b.Property<string>("ReturnTime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("MemberID")
                        .IsUnique();

                    b.ToTable("Loan");
                });

            modelBuilder.Entity("Library.Domain.Member", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SSN")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Members");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Jonas Gren",
                            SSN = 897658
                        },
                        new
                        {
                            ID = 2,
                            Name = "Elin Skog",
                            SSN = 897328
                        },
                        new
                        {
                            ID = 3,
                            Name = "Hampus Log",
                            SSN = 862393
                        });
                });

            modelBuilder.Entity("Library.Domain.BookCopy", b =>
                {
                    b.HasOne("Library.Domain.BookDetails", "Details")
                        .WithMany("Copies")
                        .HasForeignKey("DetailsID");

                    b.HasOne("Library.Domain.Loan", null)
                        .WithMany("LoanedBooks")
                        .HasForeignKey("LoanID");
                });

            modelBuilder.Entity("Library.Domain.BookDetails", b =>
                {
                    b.HasOne("Library.Domain.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Library.Domain.Loan", b =>
                {
                    b.HasOne("Library.Domain.Member", null)
                        .WithOne("Loan")
                        .HasForeignKey("Library.Domain.Loan", "MemberID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
