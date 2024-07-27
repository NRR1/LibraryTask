using LibraryTask.Data;
using LibraryTask.Interfaces;
using LibraryTask.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryTask.Services
{
    public class BookService : GenericInterface<Book>
    {
        private readonly LibraryDbContext dbContext;
        public BookService(LibraryDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<List<Book>> GetAll()
        {
            var books = await dbContext.Books.Include(b => b.Genre).Include(b => b.Author).ToListAsync();
            return books;
        }
        public Task<Book> GetByID(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Book> Add(Book item)
        {
            throw new NotImplementedException();
        }
        public Task<Book> Update(Book item, int id)
        {
            throw new NotImplementedException();
        }
        public Task<Book> Delete(int id, Book item)
        {
            throw new NotImplementedException();
        }
    }
}
