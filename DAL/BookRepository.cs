using System.IO;
using LMS.Models;
using LMS.Utils;

namespace LMS.DAL
{
    class BookRepository
    {
        static string path = "myLibrarymanagementsystem.txt";


        // 1. create new book and save into db
        public void AddBook(Book book)
        {
            int id = IdGenerator.GenerateUniqueId();
            book.Id = id;
            try
            {
                string bookDetails = $"{book.Id},{book.Title},{book.Author},{book.PublicationYear},{book.Genre},{book.Status}";
                SaveBookToFile(bookDetails, true);
                Console.WriteLine("Book added successfully");
            }
            catch (IOException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        // 2. get all books from db
        public List<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();
            try
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    string[] bookDetails = line.Split(',');
                    Book book = new Book(int.Parse(bookDetails[0]), bookDetails[1], bookDetails[2], int.Parse(bookDetails[3]), bookDetails[4], int.Parse(bookDetails[5]));
                    books.Add(book);
                }
            }
            catch (IOException e)
            {
                System.Console.WriteLine(e.Message);
            }
            return books;
        }

        // 3. search book by title
        public Book? SearchBookByTitle(string title)
        {
            Book? book = null;
            try
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    string[] bookDetails = line.Split(',');
                    if (bookDetails[1].Equals(title))
                    {
                        book = new Book(int.Parse(bookDetails[0]), bookDetails[1], bookDetails[2], int.Parse(bookDetails[3]), bookDetails[4], int.Parse(bookDetails[5]));
                        break;
                    }
                }
            }
            catch (IOException e)
            {
                System.Console.WriteLine(e.Message);
            }
            return book;
        }

        // 4. search book by author
        public Book? SearchBookByAuthor(string author)
        {
            Book? book = null;
            try
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    string[] bookDetails = line.Split(',');
                    if (bookDetails[2] == author)
                    {
                        book = new Book(int.Parse(bookDetails[0]), bookDetails[1], bookDetails[2], int.Parse(bookDetails[3]), bookDetails[4], int.Parse(bookDetails[5]));
                        break;
                    }
                }
            }
            catch (IOException e)
            {
                System.Console.WriteLine(e.Message);
            }
            return book;
        }

        // 5.  Borrow book for a user
        public void BorrowBook(int id)
        {
            // get all books
            List<Book> books = GetAllBooks();
            // find book by id
            Book? book = books.Find(b => b.Id == id);
            // if book is not found, print book not found
            if (book == null)
            {
                System.Console.WriteLine("Book not found");
                return;
            }
            // if book is found, check if book is already borrowed
            if (book.Status == 1)
            {
                System.Console.WriteLine("Book is already borrowed");
                return;
            }
            // update book status to borrowed
            book.Status = 1;
            // save books to file
            SaveBooksToFile(books, false);
            Console.WriteLine("Book borrowed successfully");
        }

        // 6. Return book from a user
        public void ReturnBook(int id)
        {
            // get all books
            List<Book> books = GetAllBooks();
            // find book by id
            Book? book = books.Find(b => b.Id == id);
            // if book is not found, print book not found
            if (book == null)
            {
                System.Console.WriteLine("Book not found");
                return;
            }
            // if book is found, check if book is already returned or not borrowed
            if (book.Status == 0)
            {
                System.Console.WriteLine("Book is already returned or not borrowed");
                return;
            }
            // update book status to borrowed
            book.Status = 0;
            // save books to file
            SaveBooksToFile(books, false);

            Console.WriteLine("Book returned successfully");
        }

        // 7. Save book to file
        private void SaveBookToFile(string bookDetails, bool append)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path, append))
                {
                    sw.WriteLine(bookDetails);
                }
            }
            catch (IOException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        // 8. Save books to file
        private void SaveBooksToFile(List<Book> books, bool append)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path, append))
                {
                    foreach (Book book in books)
                    {
                        string bookDetails = $"{book.Id},{book.Title},{book.Author},{book.PublicationYear},{book.Genre},{book.Status}";
                        sw.WriteLine(bookDetails);
                    }
                }
            }
            catch (IOException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
    }
}