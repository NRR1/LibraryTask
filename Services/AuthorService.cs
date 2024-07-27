using Microsoft.EntityFrameworkCore;
using LibraryTask.Data;
using LibraryTask.Interfaces;
using LibraryTask.Models;

namespace LibraryTask.Services
{
    public class AuthorService : GenericInterface<Author>
    {
        private readonly LibraryDbContext _librarydbcontext;
        public AuthorService(LibraryDbContext libraryDbContext)
        {
            _librarydbcontext = libraryDbContext;
        }

        public async Task<List<Author>> GetAll()
        {
            var libraries = _librarydbcontext.Authors
                .Include(a => a.Books)
                .ToList();
            foreach (var library in libraries)
            {
                var cw = await _librarydbcontext.Authors.Include(a => a.Books).ToListAsync();
            }
            return libraries;
        }
        
        public async Task<Author> GetByID(int id)
        {
            if(_librarydbcontext.Authors == null)
            {
                Console.WriteLine();
            }
            var a = await _librarydbcontext.Authors.FindAsync(id);
            if(a == null)
            {
                Console.WriteLine("n");
            }
            return a;
        }

        public async Task<Author> Add(Author author)
        {
            await _librarydbcontext.Authors.AddAsync(author);
            await _librarydbcontext.SaveChangesAsync();
            return author;
        }

        public async Task<Author> Update(Author author, int id)
        {
            if(id != author.AutId)
            {
                Console.WriteLine("Error");
            }
            _librarydbcontext.Authors.Update(author);
            try
            {
                await _librarydbcontext.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!UpdateAvaliable(id))
                {
                    Console.WriteLine("Error");
                }
            }
            return author;
        }

        private bool UpdateAvaliable(int id)
        {
            return (_librarydbcontext.Authors?.Any(x => x.AutId == id)).GetValueOrDefault();
        }

        public async Task<Author> Delete(int id)
        {
            if(_librarydbcontext.Authors == null)
            {
                Console.WriteLine("Error");
            }
            var aut = await _librarydbcontext.Authors.FindAsync(id);
            if(aut == null)
            {
                Console.WriteLine("Error");
            }

            _librarydbcontext.Remove(aut);
            await _librarydbcontext.SaveChangesAsync();
            return aut;
        }
    }
}
