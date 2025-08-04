using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnSoftware.Application.Books.DTOs
{
    public class CreateBookDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Isbn { get; set; }
    }
}
