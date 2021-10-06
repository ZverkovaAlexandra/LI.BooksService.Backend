using LI.BookService.Core.Interfaces;
using LI.BookService.Model.DTO;
using LI.BookService.Model.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LI.BookService.DAL.Repositories
{
    public class BookLiteraryRepository : GenericRepository<BookLiterary>, IBookLiteraryRepository
    {
        private readonly BookServiceDbContext _context;

        public BookLiteraryRepository(BookServiceDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<BookLiterary> GetBookLiterary(DtoRequestBook requestBook, Author author)
        {
            var selectBookLiterary = await _context.BookLiteraries.SingleOrDefaultAsync(x => x.BookName == requestBook.BookName && x.AuthorId == author.AuthorId);
            return selectBookLiterary;
        }

    }
}
