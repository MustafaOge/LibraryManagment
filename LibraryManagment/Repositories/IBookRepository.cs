using LibraryManagment.Data.Entities;

namespace LibraryManagment.Repositories
{
    public interface IBookRepository
    {
        Task<Book> AddAsync(Book book);
        Task<Book> UpdateAsync(Book book);
        IQueryable<Book> Table();
    }
}
