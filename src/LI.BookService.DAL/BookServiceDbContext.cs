using Microsoft.EntityFrameworkCore;

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
        public BookServiceDbContext(DbContextOptions<BookServiceDbContext> options) : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}
