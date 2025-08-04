using HahnSoftware.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnSoftware.Application.Books.Commands
{
    public class CreateBookCommand : IRequest<Book>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Isbn { get; set; }
    }
}
