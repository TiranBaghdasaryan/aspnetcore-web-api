﻿using Microsoft.EntityFrameworkCore;
using my_books.Data.Model;

namespace my_books.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.Book)
                .WithMany(ba => ba.BookAuthor)
                .HasForeignKey(bi => bi.BookId);

            modelBuilder.Entity<Book_Author>()
                .HasOne(a => a.Author)
                .WithMany(ab => ab.BookAuthor)
                .HasForeignKey(ai => ai.AuthorId);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book_Author> BookAuthor { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        
    }
}