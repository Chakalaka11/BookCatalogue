using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStack.Models
{
    public static class BookManager
    {
        static bookstackdbEntities db = new bookstackdbEntities();
        /// <summary>
        /// Add new book to database
        /// </summary>
        /// <param name="Book">Book , thats need to be added</param>
        /// <returns>Message of succsess operation or error log</returns>
        public static string AddBook(book Book)
        {
            db.book.Add(Book);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return (ex.Message);
                throw;
            }
            return "Success";
        }
        /// <summary>
        /// Return list of all books in database
        /// </summary>
        /// <returns>List of books</returns>
        public static List<book> GetAllBooks()
        {
            List<book> all_books = new List<book>();
            all_books = db.book.Select(x => x).ToList();
            return all_books;
        }   
    }
}