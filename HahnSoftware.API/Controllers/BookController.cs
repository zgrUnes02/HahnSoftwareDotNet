using HahnSoftware.Application.Books.Commands;
using HahnSoftware.Application.Books.DTOs;
using HahnSoftware.Application.Books.Queries;
using HahnSoftware.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HahnSoftware.API.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _merdiator;
        public BookController(IMediator mediator) 
        { 
            _merdiator = mediator;
        }

        /// <summary>
        /// API to get all books
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                GetAllBooksQuery getAllBooksQuery = new GetAllBooksQuery();
                var books = await _merdiator.Send(getAllBooksQuery);
                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong: {ex.Message}");
            }
        }

        /// <summary>
        /// API to create new book
        /// </summary>
        /// <param name="createBookCommand"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateNewBook([FromBody] CreateBookDto createBookDto)
        {
            try
            {
                CreateBookCommand createBookCommand = new CreateBookCommand
                {
                    Name = createBookDto.Name,
                    Description = createBookDto.Description,
                    Isbn = createBookDto.Isbn,
                };

                Book book = await _merdiator.Send(createBookCommand);
                return Ok(book);
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong: {ex.Message}");
            }
        }

        /// <summary>
        /// API to get one book by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("{id}")]
        public async Task<IActionResult> GetOneBook(int id)
        {
            try
            {
                GetBookByIdQuery getBookByIdQuery = new GetBookByIdQuery { Id = id };
                Book book = await _merdiator.Send(getBookByIdQuery);
                return Ok(book);
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong: {ex.Message}");
            }
        }

        /// <summary>
        /// API to get one book by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                DeleteBookCommand deleteBookCommand = new DeleteBookCommand { Id = id };
                bool result = await _merdiator.Send(deleteBookCommand);
                
                if ( result ) 
                {
                    return Ok(new
                    {
                        message = "Book has been deleted with succes"
                    });
                }
                else
                {
                    return BadRequest("Something went wrong will deleting the book");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong: {ex.Message}");
            }
        }

        /// <summary>
        /// API to update book
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateBookDto"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] UpdateBookDto updateBookDto)
        {
            UpdateBookCommand updateBookCommand = new UpdateBookCommand
            {
                Id = id,
                Name = updateBookDto.Name,
                Description = updateBookDto.Description,
                Isbn = updateBookDto.Isbn,
            };

            Book book = await _merdiator.Send(updateBookCommand);
            return Ok(book);
        }
    }
}
