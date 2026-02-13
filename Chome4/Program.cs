namespace Chome4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Створюємо список
            ReadingList myBooks = new ReadingList();

            Console.WriteLine("ДОДАЄМО КНИГИ");
            Book book1 = new Book("Майстер і Маргарита", "Булгаков", 1967);
            myBooks.AddBook(book1);
            myBooks.AddBook("1984", "Орвелл", 1949);
            myBooks.AddBook("Кобзар", "Шевченко", 1840);

            myBooks += new Book("Гаррі Поттер", "Роулінг", 1997);

            myBooks.ShowAll();

            Console.WriteLine($"ІНДЕКСАТОРИ");
            Console.WriteLine($"Перша книга: {myBooks[0]}");
            Console.WriteLine($"Книга '1984': {myBooks["1984"]}\n");

            Console.WriteLine($"ПЕРЕВІРКА");
            Console.WriteLine($"Є '1984'? {myBooks.ContainsBook("1984")}");
            Console.WriteLine($"Є 'Війна'? {myBooks.ContainsBook("Війна")}\n");

            Console.WriteLine($"ВИДАЛЯЄМО");
            myBooks.RemoveBook("1984");
            myBooks -= book1;
            myBooks -= 1;

            myBooks.ShowAll();

            myBooks.AddBook("Лісова пісня", "Українка", 1911);
            myBooks.AddBook("Тіні забутих предків", "Коцюбинський", 1911);

            myBooks.ShowAll();

            Console.WriteLine("ВСІ КНИГИ (FOREACH)");
            foreach (var book in myBooks)
            {
                Console.WriteLine($"  • {book}");
            }
            Console.WriteLine();
        }
    }
}
