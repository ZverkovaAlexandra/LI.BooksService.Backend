using Microsoft.EntityFrameworkCore;

namespace LI.BookService.Model.Entities
{
    public class BookServiceContext : DbContext
    {
        public DbSet<Autor> Autors { get; set; }
        public DbSet<BookLiterary> BookLiteraries { get; set; }
        public DbSet<OfferList> OfferLists { get; set; }
        public DbSet<UserList> UserLists { get; set; }
        public DbSet<UserValueCategory> UserValueCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<List> Lists { get; set; }
        public DbSet<WishList> WishLists { get; set; }
        public BookServiceContext()
        {
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BookService;Trusted_Connection=True;");
        }
    }
}
