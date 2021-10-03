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
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookLiterary> BookLiteraries { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<List> Lists { get; set; }
        public DbSet<WishList> WishLists { get; set; }
        public DbSet<UserList> UserLists { get; set; }
        public DbSet<UserValueCategory> UserValueCategories { get; set; }
        public DbSet<OfferList> OfferLists { get; set; }


        public BookServiceDbContext(DbContextOptions<BookServiceDbContext> options) : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ----- Author -----
            modelBuilder.Entity<Author>().Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Author>().Property(x => x.FirstName).HasMaxLength(50);

            // ----- BookLiterary -----
            modelBuilder.Entity<BookLiterary>().Property(x => x.BookName).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<BookLiterary>().Property(x => x.Note).HasMaxLength(50);

            // ----- OfferList -----
            modelBuilder.Entity<OfferList>().Property(x => x.ISBN).HasMaxLength(13);

            modelBuilder.Entity<OfferList>().Property(x => x.YearPublishing)
                .IsRequired()
                .HasMaxLength(4);

            modelBuilder.Entity<OfferList>().Property(x => x.CreateAt).IsRequired();

            modelBuilder.Entity<OfferList>().Property(x => x.UpdateAt)
                .IsRequired()
                .HasDefaultValue(modelBuilder.Entity<OfferList>().Property(x => x.CreateAt));

            modelBuilder.Entity<OfferList>().Property(x => x.IdStatus).HasDefaultValue("Cвободен");

            // ----- UserList -----

            // ----- Category -----

            // ----- List -----

            // ----- UserValueCategory -----

          




        }
    }
}
