using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace from_27._11._17
{
    public class Book
    {
        public int Year;
        public int PageCount;
        public Author Author;
        public string Name;
        public string Publisher;
        public string Style;
    }

    public class Author
    {
        public string FirstName;
        public string SecondName;
        public int Age;
    }

    public class Program
    {
        static Book[] Books;

        static Book WriteBook()
        {
            Book book = new Book
            {
                Year = Convert.ToInt32(Console.ReadLine()),
                PageCount = Convert.ToInt32(Console.ReadLine()),
                Author = new Author
                {
                    Age = Convert.ToInt32(Console.ReadLine()),
                    FirstName = Convert.ToString(Console.ReadLine()),
                    SecondName = Convert.ToString(Console.ReadLine())
                },
                Name = Convert.ToString(Console.ReadLine()),
                Publisher = Convert.ToString(Console.ReadLine()),
                Style = Convert.ToString(Console.ReadLine())
            };

            Console.Clear();

            return book;
        }

        static void BurnBook()
        {
            Books[Convert.ToInt32(Console.ReadLine())] = null;
        }

        static void Main()
        {
            Books = new Book[3];
            for (int i = 0; i < 10; i++)
                Books[i] = WriteBook();
            BurnBook();
            Console.ReadKey();
        }

    }
}

