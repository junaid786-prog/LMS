using LMS.Models;
using LMS.BLL;
namespace LMS.UI
{
    class MenuManager
    {
        public void ShowMenu()
        {
            Console.WriteLine("\nWelcome to Library Management System\n");
            Console.WriteLine("0. Add Book");
            Console.WriteLine("1. Show All Books");
            Console.WriteLine("2. Search Book");
            Console.WriteLine("3. Borrow Book");
            Console.WriteLine("4. Return Book");
            Console.WriteLine("5. Exit\n");
        }

        public int GetChoice()
        {
            Console.WriteLine("\nEnter your choice:");
            string choice = Console.ReadLine() ?? throw new InvalidOperationException("choice can not be null here");
            Console.WriteLine("choice: " + choice);
            if (choice == null)
            {
                Console.WriteLine("Invalid choice");
                return -1;
            }
            try
            {
                int res = int.Parse(choice ?? throw new InvalidOperationException("choice can not be null here 2"));
                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return -1;
        }


        public Book ReadBook()
        {
            Book book = new Book(123, "title", "author", 2021, "genre", 1);
            try
            {
                int id = 123;
                Console.WriteLine("\n======BOOK DETAILS======= \n");
                Console.WriteLine("Enter book title: ");
                string title = Console.ReadLine() ?? throw new InvalidOperationException("title can not be null");
                Console.WriteLine("Enter book author: ");
                string author = Console.ReadLine() ?? throw new InvalidOperationException("author can not be null");
                Console.WriteLine("Enter book publication year: ");
                int publicationYear = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException("publication year can not be null"));
                Console.WriteLine("Enter book genre: ");
                string genre = Console.ReadLine() ?? throw new InvalidOperationException("genre can not be null");
                book = new Book(id, title, author, publicationYear, genre);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return book;
        }

        public void ShowAllBooks()
        {
            BookManager bookManager = new BookManager();
            List<Book> books = bookManager.GetAllBooks();
            Console.WriteLine("\n=========BOOKS RECORD========\n");
            Console.WriteLine("Id Title Author PublicationYear Genre Status");
            foreach (Book book in books)
            {
                Console.WriteLine(book.Id + " " + book.Title + " " + book.Author + " " + book.PublicationYear + " " + book.Genre + " " + book.Status);
            }
            Console.WriteLine("\n=========END========\n");
        }

        public void RunOperation(int option)
        {
            BookManager bookManager = new BookManager();
            if (option < 0 || option > 5)
            {
                Console.WriteLine("Invalid choice. Select from 0 to 5");
                return;
            }
            switch (option)
            {
                case 0:
                    Book book = ReadBook();
                    bookManager.AddBook(book);
                    break;
                case 1:
                    ShowAllBooks();
                    break;
                case 2:
                    Console.WriteLine("Enter book title: ");
                    string title = Console.ReadLine() ?? throw new InvalidOperationException("title can not be null");
                    Console.WriteLine("title: " + title);
                    Book targetBook = bookManager.SearchBookByTitle(title) ?? throw new InvalidOperationException("book not found with this title");
                    Console.WriteLine("Id Title Author PublicationYear Genre Status");
                    Console.WriteLine(targetBook.Id + " " + targetBook.Title + " " + targetBook.Author + " " + targetBook.PublicationYear + " " + targetBook.Genre + " " + targetBook.Status);
                    break;
                case 3:
                    Console.WriteLine("Borrow Book");
                    Console.WriteLine("Enter Book ID: ");
                    int bookId = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException("book id can not be null"));
                    bookManager.BorrowBook(bookId);
                    break;
                case 4:
                    Console.WriteLine("Return Book");
                    Console.WriteLine("Enter Book ID: ");
                    int bookId2 = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException("book id can not be null"));
                    bookManager.ReturnBook(bookId2);
                    break;
                case 5:
                    Console.WriteLine("Exiting...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Select from 0 to 4");
                    break;
            }
        }
    }
}