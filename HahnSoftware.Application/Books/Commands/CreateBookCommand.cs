using HahnSoftware.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnSoftware.Application.Books.Commands
{
    public class CreateBookCommand : IRequest<Book>
    {
        [Required(ErrorMessage = "The name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The ISBN is required")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "ISBN must be between 5 and 10 characters")]
        public string Isbn { get; set; }
    }
}
