using LMS.DAL;
using LMS.Models;

namespace LMS.BLL{
    class BookManager {
        public void AddBook(Book book){
            BookRepository bookRepository = new BookRepository();
            bookRepository.AddBook(book);
        }
        public List<Book> GetAllBooks(){
            BookRepository bookRepository = new BookRepository();
            return bookRepository.GetAllBooks();
        }

        public Book? SearchBookByTitle(string title){
            BookRepository bookRepository = new BookRepository();
            return bookRepository.SearchBookByTitle(title);
        }

        public void BorrowBook(int id){
            BookRepository bookRepository = new BookRepository();
            bookRepository.BorrowBook(id);
        }

        public void ReturnBook(int id){
            BookRepository bookRepository = new BookRepository();
            bookRepository.ReturnBook(id);
        }
    }
}