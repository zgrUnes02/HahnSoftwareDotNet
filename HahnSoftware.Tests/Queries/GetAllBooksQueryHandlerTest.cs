using HahnSoftware.Application.Books.Queries;
using HahnSoftware.Application.Books.QueriesHandlers;
using HahnSoftware.Domain.Entities;
using HahnSoftware.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnSoftware.Tests.Queries
{
    public class GetAllBooksQueryHandlerTest
    {
        private readonly Mock<IBookRepository> _repositoryMock;
        private readonly GetAllBooksQueryHandler _handler;

        public GetAllBooksQueryHandlerTest()
        {
            _repositoryMock = new Mock<IBookRepository>();
            _handler = new GetAllBooksQueryHandler(_repositoryMock.Object);
        }

        [Fact]
        public async Task Should_Return_List_Of_Books()
        {
            IEnumerable<Book>? books = new List<Book>()
            {
                new Book { Id = 3, Name = "Book N2", Description = "Description Book N2", Isbn = "DGH27G" },
            };

            _repositoryMock
                .Setup(r => r.GetAllBooksAsync(CancellationToken.None))
                .ReturnsAsync(books);

            var result = await _handler.Handle(new GetAllBooksQuery(), CancellationToken.None);

            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("Book N2", result.First().Name);
        }
    }
}
