using HahnSoftware.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnSoftware.Application.Books.Queries
{
    public class GetAllBooksQuery : IRequest<IEnumerable<Book>>
    {
    }
}
