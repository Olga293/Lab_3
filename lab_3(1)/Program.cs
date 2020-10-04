using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3_1_
{
    //Создать класс Book: id, Название, Автор (ы), Издательство, Год издания, Количество страниц, Цена, Тип переплета.
    //Свойства и конструкторы должны обеспечивать проверку корректности.
    //Создать массив объектов.Вывести:
    //a) список книг заданного автора;
    //b) список книг, выпущенных после заданного года.
    public class Book
    {
        private string title;
        private string name;
        private string publishing;
        private int year;
        private int pages;
        private double price;
        private string cover;
        readonly int id;
        public static int number;
        public const int books = 10;

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
            }
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public string Publishing
        {
            get
            {
                return this.publishing;
            }
            set
            {
                this.publishing = value;
            }
        }
        public int Year
        {
            get
            {
                return this.year;
            }
            set
            {
                this.year = value;
            }
        }
        public int Pages
        {
            get
            {
                return this.pages;
            }
            set
            {
                this.pages = value;
            }
        }
        public double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
            }
        }
        public string Cover
        {
            get
            {
                return this.cover;
            }
            set
            {
                this.cover = value;
            }
        }
        static Book() // статический конструктор
        {
            number = 0;
        }
        public Book()// конструктор без параметров
        {
            number++;
            title = "\"Good book\"";
            name = "Human";
            publishing = "World";
            year = 2000;
            pages = 100;
            price = 10;
            cover = "soft";
            this.id = GetHash(out int id, title, name);
        }
        public Book(string title, string name, string publishing, int year, int pages, double price, string cover)// конструктор с параметрами
        {
            number++;
            this.title = title;
            this.name = name;
            this.publishing = publishing;
            this.year = year;
            this.pages = pages;
            this.price = price;
            this.cover = cover;
            this.id = GetHash(out int id, title, name);
        }
        public Book(string title, string name, string publishing = "House for publishing") // конструктор с параметрами по умолчанию
        {
            number++;
            this.title = title;
            this.name = name;
            this.id = GetHash(out int id, title, name);
        }
        public void GetInfo()
        {
            Console.WriteLine($" ID: {id} \n Book: {title} \n Author: {name} \n Published by {publishing} in {year} \n Pages: {pages} \n Price: {price}$ \n Cover type: {cover} \n\n");
        }
        public int GetHash(out int id, string title, string name) //хэш-код
        {
            id = title.GetHashCode() + name.GetHashCode();
            return id;
        }
        //закрытый конструктор?
        //private Book()
        //{ }
    }
        
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Total number of books: " + Book.books);
            Book b1 = new Book();
            b1.GetInfo();
            Book b2 = new Book();
            b2.GetInfo();
            Book b3 = new Book("War and Peace", "Leo Tolstoy", "Russia", 1869, 1225, 30, "hurd");
            b3.GetInfo();
            Book b4 = new Book("The Master and Margarita", "Mikhail Bulgakov", "Russia", 1966, 384, 25, "soft");
            b4.GetInfo();
            Book b5 = new Book("The adventures of Sherlock Holmes", "Arthur Conan Doyle", "England", 1892, 307, 50, "hurd" );
            b5.GetInfo();
            Book b6 = new Book("Faust", "Johann Wolfgang von Goethe");
            b6.GetInfo();
            Book b7 = new Book("One Hundred Years of Solitude", "Gabriel Garcia Marquez", publishing: "Colombia");
            b7.GetInfo();
            Book b8 = new Book("CLR via C #. Microsoft .NET Framework 4.5 Programming in C #", "Jeffrey Richter");
            b8.GetInfo();
            Console.WriteLine("Books on sale: " + Book.number);
            object[] list = new object[8];
            list[0] = b1;
            list[1] = b2;
            list[2] = b3;
            list[3] = b4;
            list[4] = b5;
            list[5] = b6;
            list[6] = b7;
            list[7] = b8;
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("The list of books by a given author");
            string author = Console.ReadLine();
            int count1 = 0;
            foreach (Book auth in list)
            {
                count1++;
                if (auth.Name==author) Console.WriteLine("\n" + auth.Title + " by " + auth.Name);
            }
            Console.WriteLine("\n\n");
            Console.WriteLine("The list of books published after a given year");
            int year = Convert.ToInt32(Console.ReadLine());
            int count2 = 0;
            foreach (Book y in list)
            {
                count2++;
                if (y.Year > year) Console.WriteLine("\n" + y.Title + " in " + y.Year);
            }
            Console.WriteLine("Object comparison:");
            Console.WriteLine(b1.Equals(b2));
            Console.WriteLine(b1.Cover.Equals(b4.Cover));
            Console.WriteLine(b3.Year.ToString());
            Console.WriteLine(b4.Year.ToString());
            var b0 = new { Title = "Anonymous book", Name = "Stranger"};
            Console.WriteLine(b0.Title.GetType());
            Console.WriteLine(b0.GetType());
        }
    }
}
