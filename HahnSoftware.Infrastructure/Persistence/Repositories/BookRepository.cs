using Azure.Core;
using HahnSoftware.Application.Books.DTOs;
using HahnSoftware.Domain.Entities;
using HahnSoftware.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnSoftware.Infrastructure.Persistence.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;
        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Book> CreateBookAsync(Book book, CancellationToken cancellationToken)
        {
            Book newBook = new Book
            {
                Name = book.Name,
                Description = book.Description,
                Isbn = book.Isbn,
            };

            await _context.Book.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook;
        }

        public async Task<bool> DeleteBookAsync(int id, CancellationToken cancellationToken)
        {
            Book? bookToDelete = await _context.Book.FirstOrDefaultAsync(b => b.Id == id);

            if ( bookToDelete is null )
            {
                return false;
            }

            _context.Book.Remove(bookToDelete);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync(CancellationToken cancellationToken)
        {
            List<Book> books = await _context.Book.ToListAsync();
            return books;
        }

        /// <summary>
        /// Function to return only one book by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Book?> GetOneBookAsync(int id, CancellationToken cancellationToken)
        {
            Book? book = await _context.Book
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);

            return book;
        }


        public async Task<Book> UpdateBookAsync(int id, Book book, CancellationToken cancellationToken)
        {
            Book? bookToUpdate = await _context.Book.FirstOrDefaultAsync(b => b.Id == id);

            if ( bookToUpdate is null )
            {
                return null;
            }

            UpdateBookDto updateBookDto = new UpdateBookDto
            {
                Name = book.Name,
                Description = book.Description,
                Isbn = book.Isbn,
            };

            bookToUpdate.Name = updateBookDto.Name;
            bookToUpdate.Description = updateBookDto.Description;
            bookToUpdate.Isbn = updateBookDto.Isbn;
            await _context.SaveChangesAsync();

            return bookToUpdate;
        }
    }
}
