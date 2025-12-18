using LibraryManagment.Data.Entities;

namespace LibraryManagment.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task<Book> AddAsync(Book book);
        Task<Book> UpdateAsync(Book book);
        Task<Book> DeleteAsync(int id);
        Task<IEnumerable<Book>> SearchAsync(string keyword);
    }
}
