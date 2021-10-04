using Microsoft.EntityFrameworkCore;
using LI.BookService.Model.Entities;
using System;

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

        public DbSet<User> User { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public BookServiceDbContext(DbContextOptions<BookServiceDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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

            modelBuilder.Entity<OfferList>()
                .HasOne(x => x.User)
                .WithMany(x => x.OfferLists)
                .HasForeignKey(x=> x.UserId);
            // modelBuilder.Entity<OfferList>().Property(x => x.IdStatus).HasDefaultValue("Cвободен");

            // ----- UserList -----

            // ----- Category -----

            // ----- List -----

            // ----- UserValueCategory -----

            // ----- User -----
            modelBuilder.Entity<User>().Property(x => x.FirstName)
                 .IsRequired()
                 .HasMaxLength(25);

            modelBuilder.Entity<User>().Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<User>().Property(x => x.SecondName)
               .HasMaxLength(25);

            modelBuilder.Entity<User>().Property(x => x.Email)
               .IsRequired()
               .HasMaxLength(15);

            modelBuilder.Entity<User>().Property(x => x.UserName)
              .IsRequired()
              .HasMaxLength(20);

            modelBuilder.Entity<User>().Property(x => x.Password)
              .IsRequired()
              .HasMaxLength(15);

            modelBuilder.Entity<User>().Property(x => x.Rating)
             .IsRequired()
             .HasDefaultValue(0);

            modelBuilder.Entity<User>().Property(x => x.CreatedAt)
              .IsRequired();

            modelBuilder.Entity<User>().Property(x => x.Enabled)
             .IsRequired()
             .HasDefaultValue(true);

            modelBuilder.Entity<User>().Property(x => x.IsStaff)
             .IsRequired()
             .HasDefaultValue(false);

            modelBuilder.Entity<User>().Property(x => x.IsSuperAdmin)
             .IsRequired()
             .HasDefaultValue(false);

            // ----- UserAddress -----
            modelBuilder.Entity<UserAddress>()
               .HasOne(p => p.User)
               .WithMany(b => b.UserAddresses)
               .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<UserAddress>().Property(x => x.AddrIndex)
                 .IsRequired()
                 .HasMaxLength(6);

            modelBuilder.Entity<UserAddress>().Property(x => x.AddrCity)
                .IsRequired()
                .HasMaxLength(16);

            modelBuilder.Entity<UserAddress>().Property(x => x.AddrSreet)
               .IsRequired()
               .HasMaxLength(25);

            modelBuilder.Entity<UserAddress>().Property(x => x.AddrHouse)
             .IsRequired()
             .HasMaxLength(5);

            modelBuilder.Entity<UserAddress>().Property(x => x.AddrStructure)
            .HasMaxLength(10);

            modelBuilder.Entity<UserAddress>().Property(x => x.AddrApart)
            .HasMaxLength(3);

            modelBuilder.Entity<UserAddress>().Property(x => x.IsDefault)
            .IsRequired()
            .HasDefaultValue(false);
        }
    }
}
