using LibraryTask.Data;
using LibraryTask.Interfaces;
using LibraryTask.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryTask.Services
{
    public class GenreService : GenericInterface<Genre>
    {
        private readonly LibraryDbContext _libraryDbContext;
        public GenreService(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }

        public async Task<List<Genre>> GetAll()
        {
            var genres = _libraryDbContext.Genres.ToList();
            return genres;
        }

        public async Task<Genre> GetByID(int id)
        {
            if(_libraryDbContext.Genres == null)
            {
                Console.WriteLine();
            }
            var search = await _libraryDbContext.Genres.FindAsync(id);
            if(search == null)
            {
                Console.WriteLine("0");
            }
            return search;
        }

        public async Task<Genre> Add(Genre genre)
        {
            await _libraryDbContext.Genres.AddAsync(genre);
            await _libraryDbContext.SaveChangesAsync();
            return genre;
        }

        private bool GenreAvaliable(int id)
        {
            return (_libraryDbContext.Genres?.Any(x => x.Id == id)).GetValueOrDefault();
        }

        public async Task<Genre> Update(Genre genre, int id)
        {
            if(id != genre.Id)
            {
                Console.WriteLine("error");
            }
            _libraryDbContext.Entry(genre).State = EntityState.Modified;

            try
            {
                await _libraryDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (!GenreAvaliable(id))
                {
                    Console.WriteLine("error");
                }
            }
            return genre;
        }

        public async Task<Genre> Delete(int id, Genre genre)
        {
            if (_libraryDbContext == null)
            {
                Console.WriteLine("Error");
            }
            var gen = await _libraryDbContext.Genres.FindAsync(id);
            if (gen == null)
            {
                return genre;
            }
            //try catch 
            _libraryDbContext.Remove(gen);
            await _libraryDbContext.SaveChangesAsync();
            return gen;
        }
    }
}
