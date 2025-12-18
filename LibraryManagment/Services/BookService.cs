using LibraryManagment.Data.Entities;
using LibraryManagment.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagment.Services
{
    public class BookService : IBookService
    {
        public readonly IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
            
        }
        public async Task<Book> AddAsync(Book book)
        {
            await bookRepository.AddAsync(book);
            return book;
        }

        public Task<Book> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Book>> GetAllAsync()
        {
            var bookList = await bookRepository.Table()
                .Where(b => b.IsDeleted == false)
                .ToListAsync();

            return bookList;
        }

        public Task<Book?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> SearchAsync(string keyword)
        {
            throw new NotImplementedException();
        }

        public Task<Book> UpdateAsync(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
