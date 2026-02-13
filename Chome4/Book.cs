using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chome4
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public Book(string title, string author, int year)
        {
            Title = title;
            Author = author;
            Year = year;
        }

        public static bool operator ==(Book b1, Book b2)
        {
            if (ReferenceEquals(b1, b2)) return true;
            if (b1 is null || b2 is null) return false;
            return b1.Title == b2.Title && b1.Author == b2.Author && b1.Year == b2.Year;
        }

        public static bool operator !=(Book b1, Book b2)
        {
            return !(b1 == b2);
        }

        public override string ToString()
        {
            return $"{Title} - {Author} ({Year})";
        }

        public override bool Equals(object obj)
        {
            return obj is Book book && this == book;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Title, Author, Year);
        }
    }
}
