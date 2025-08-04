using HahnSoftware.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnSoftware.Domain.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsync(CancellationToken cancellationToken);
        Task<Book> GetOneBookAsync(int id, CancellationToken cancellationToken);
        Task<Book> CreateBookAsync (Book book, CancellationToken cancellationToken);
        Task<Book> UpdateBookAsync (int id, Book book, CancellationToken cancellationToken);
        Task<bool> DeleteBookAsync (int id, CancellationToken cancellationToken);
    }
}
