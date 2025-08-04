using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnSoftware.Domain.Entities
{
    public class Book
    {
        /// <summary>
        /// Identifier of the book
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the book
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the book
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// ISBN of the book
        /// </summary>
        public string Isbn { get; set; }

        public Book()
        {
            
        }

        public Book(string name, string description, string isbn)
        {
            Name = name;
            Description = description;
            Isbn = isbn;
        }
    }
}
