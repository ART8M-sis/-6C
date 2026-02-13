using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chome4
{
    public class ReadingList : IEnumerable<Book>
    {
        private List<Book> books = new List<Book>();

        public int Count => books.Count;

        public bool IsEmpty => books.Count == 0;

        public Book this[int index]
        {
            get => books[index];
            set => books[index] = value;
        }

        public Book this[string title]
        {
            get => books.FirstOrDefault(b => b.Title == title);
        }

        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine($"Додано: {book}");
        }

        public void AddBook(string title, string author, int year)
        {
            AddBook(new Book(title, author, year));
        }

        public bool RemoveBook(Book book)
        {
            bool result = books.Remove(book);
            if (result) Console.WriteLine($"Видалено: {book}");
            return result;
        }

        public bool RemoveBook(string title)
        {
            var book = books.FirstOrDefault(b => b.Title == title);
            return book != null ? RemoveBook(book) : false;
        }

        public bool ContainsBook(string title)
        {
            return books.Any(b => b.Title == title);
        }

        public bool ContainsBook(Book book)
        {
            return books.Contains(book);
        }

        public void ShowAll()
        {
            if (IsEmpty)
            {
                Console.WriteLine("Список порожній");
                return;
            }

            Console.WriteLine("\nМОЇ КНИГИ");
            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {books[i]}");
            }
            Console.WriteLine($"Всього: {Count}\n");
        }

        public static ReadingList operator +(ReadingList list, Book book)
        {
            list.AddBook(book);
            return list;
        }

        public static ReadingList operator -(ReadingList list, Book book)
        {
            list.RemoveBook(book);
            return list;
        }

        public static ReadingList operator -(ReadingList list, int index)
        {
            if (index >= 0 && index < list.books.Count)
                list.RemoveBook(list.books[index]);
            return list;
        }

        public IEnumerator GetEnumerator()
        {
            return books.GetEnumerator();
        }

        IEnumerator<Book> IEnumerable<Book>.GetEnumerator()
        {
            return ((IEnumerable<Book>)books).GetEnumerator();
        }
    }
}
