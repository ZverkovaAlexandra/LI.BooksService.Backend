using Microsoft.EntityFrameworkCore;
using LI.BookService.Model.Entities;
namespace LI.BookService.DAL
{
    public class BookServiceDbContext : DbContext
    {

        /// <summary>
        /// а тут должны быть списки DbSet<Сущность>
        /// создам,когда будут определены и готовы сущности
        /// </summary>
        /// <param name="options"></param>
        /// 
        public DbSet<UserList> UserLists { get; set; }
        public DbSet<UserValueCategory> UserValueCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public BookServiceDbContext(DbContextOptions<BookServiceDbContext> options) : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}
