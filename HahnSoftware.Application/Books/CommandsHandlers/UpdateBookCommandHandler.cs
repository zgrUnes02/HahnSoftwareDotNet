using HahnSoftware.Application.Books.Commands;
using HahnSoftware.Domain.Entities;
using HahnSoftware.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnSoftware.Application.Books.CommandsHandlers
{

    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Book>
    {
        private readonly IBookRepository _bookRepository;
        public UpdateBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            Book book = new Book
            {
                Name = request.Name,
                Description = request.Description,
                Isbn = request.Isbn,
            };

            return await _bookRepository.UpdateBookAsync(request.Id, book, cancellationToken);
        }
    }
}
