using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // relations
            modelBuilder.Entity<Book>()
                .HasOne(r => r.Author)
                .WithMany(r => r.Books)
                .HasForeignKey(x => x.AuthorId)
                .IsRequired();

            modelBuilder.Entity<Book>()
                .HasOne(r => r.Category)
                .WithMany(r => r.Books)
                .HasForeignKey(x => x.CategoryId)
                .IsRequired();


            // configurations

            modelBuilder.Entity<Book>().HasIndex(x => x.ISBN)
                .IsUnique();

            // seeding

            modelBuilder.Entity<Author>().HasData(
                new Author()
                {
                    AuthorId = 1,
                    AuthorName = "Meshaal Jamal",
                    Bio = "Meshaal jamal is a undergraduate student.",
                    Nationality = "South Yemen"
                });
            modelBuilder.Entity<Category>().HasData(
                new Category() {CategoryId = 1,Name = "Fantasy" },
                new Category() {CategoryId = 2, Name = "Sci-Fi" });

            modelBuilder.Entity<Book>().HasData(
                new Book()
                {
                    BookId = 1,
                    Title = "The Intruder",
                    ISBN = "1464228612",
                    Description = "Casey's cabin in the wilderness is not built for a hurricane. Her roof shakes, the lights flicker, and the tree outside her front door sways ominously in the wind. But she's a lot more worried about the girl she discovers lurking outside her kitchen window.\r\n",
                    InStock = true,
                    Price = 14.88m,
                    PageCount = 336,
                    PublishDate = new DateTime(2025, 10, 7),
                    CoverUrl = "https://m.media-amazon.com/images/I/91paJzeRbbL._SL1500_.jpg",
                    AuthorId = 1,
                    CategoryId = 1
                },
                new Book()
                {
                    BookId = 2,
                    Title = "Refactoring: Improving the Design of Existing Code",
                    ISBN = "0134757599",
                    Description = "Fully Revised and Updated—Includes New Refactoring's and Code Examples",
                    InStock = true,
                    Price = 31.50m,
                    PageCount = 448,
                    PublishDate = new DateTime(2018, 11, 30),
                    CoverUrl = "https://m.media-amazon.com/images/I/91paJzeRbbL._SL1500_.jpg",
                    AuthorId = 1,
                    CategoryId = 1
                },
                new Book()
                {
                    BookId = 3,
                    Title = "Theo of Golden: A Novel",
                    ISBN = "1668236516",
                    Description = "One spring morning, a stranger arrives in the small southern city of Golden. No one knows where he has come from…or why…\r\n",
                    InStock = true,
                    Price = 15.00m,
                    PageCount = 400,
                    PublishDate = new DateTime(2025, 10, 3),
                    CoverUrl = "https://m.media-amazon.com/images/I/719tyQROiWL._SL1500_.jpg",
                    AuthorId = 1,
                    CategoryId = 1
                });
        }
    }
}
