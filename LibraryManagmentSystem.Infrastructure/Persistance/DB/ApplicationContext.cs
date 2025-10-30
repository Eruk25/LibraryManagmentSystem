using LibraryManagmentSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagmentSystem.Infrastructure.Persistance.DB;

public class LibraryContext : DbContext
{
    public DbSet<Author> Authors { get; set; } 

    public DbSet<Book> Books { get; set; }

    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>()
            .HasData(
                new
                {
                    Id = 1,
                    Name = "Федор Достоевский",
                    DateOfBirth = new DateOnly(1821, 11, 11)
                },
                new
                {
                    Id = 2,
                    Name = "Лев Толстой",
                    DateOfBirth = new DateOnly(1828, 09, 09)
                });
        modelBuilder.Entity<Book>()
            .HasData(
                new
                {
                    Id = 1,
                    Title = "Бедные люди",
                    PublishedYear = 1846,
                    AuthorId = 1
                },
                new
                {
                    Id = 2,
                    Title = "Юность",
                    PublishedYear = 1856,
                    AuthorId = 2
                });
        modelBuilder.Entity<Author>()
            .HasKey(au => au.Id);
        modelBuilder.Entity<Author>()
            .Property(au => au.Name)
            .HasMaxLength(50)
            .IsRequired();
        modelBuilder.Entity<Author>()
            .Property(au => au.DateOfBirth)
            .IsRequired();
        
        modelBuilder.Entity<Book>()
            .HasKey(b => b.Id);
        modelBuilder.Entity<Book>()
            .Property(b => b.Title)
            .HasMaxLength(30)
            .IsRequired();
        modelBuilder.Entity<Book>()
            .Property(b => b.PublishedYear)
            .IsRequired();
        modelBuilder.Entity<Book>()
            .Property(b => b.AuthorId)
            .IsRequired();
        modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany(au => au.Books)
            .HasForeignKey(b => b.AuthorId);
    }
}