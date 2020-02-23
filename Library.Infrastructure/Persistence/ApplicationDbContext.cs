using Library.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BookDetails> BookDetails { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<BookCopy> BookCopies { get; set; }
        public object Author { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureBookDetails(modelBuilder);
            ConfigureAuthor(modelBuilder);

            SeedDatabase(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author { ID = 1, Name = "William Shakespeare" },
                new Author { ID = 2, Name = "Villiam Skakspjut" },
                new Author { ID = 3, Name = "Robert C. Martin" }
            );
            modelBuilder.Entity<Member>().HasData(
                new Member { ID = 1, SSN = "897658", Name = "Jonas Gren" },
                new Member { ID = 2, SSN = "897328", Name = "Elin Skog" },
                new Member { ID = 3, SSN = "862393", Name = "Hampus Log" }
            );
        }

        private static void ConfigureAuthor(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().Property(x => x.Name).HasMaxLength(55);
        }

        private static void ConfigureBookDetails(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookDetails>().HasKey(x => x.ID);
            modelBuilder.Entity<BookDetails>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorID);
        }
    }
}
