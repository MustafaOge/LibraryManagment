using LibraryManagment.Data;
using LibraryManagment.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagment.Repositories
{
    public class BookRepository : IBookRepository
    {
        protected readonly DbSet<Book> dbSet;

        private AppDbContext dbContext { get; set; }

        public BookRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Book> AddAsync(Book book)
        {
            await dbContext.AddAsync(book);
            return book;
        }

        public async Task<Book> UpdateAsync(Book book)
        {
            dbContext.Books.Update(book); 
            await dbContext.SaveChangesAsync(); 
            return book;
        }


        public IQueryable<Book> Table()
        {
            return dbContext.Books;

        }

    }
}
