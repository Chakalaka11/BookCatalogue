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
        /// Add new book to database; book created with this parameters
        /// </summary>
        /// <param name="name">Name of the book</param>
        /// <param name="author">Author of the book</param>
        /// <param name="price">It's price</param>
        /// <param name="image">Image of the book (can be null)</param>
        /// <returns></returns>
        public static string AddBook(string name, string author, decimal price)
        {
            book Book = new book()
            {
                Name = name,
                Author = author,
                Price = price
            };
            try
            {
                db.book.Add(Book);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return (ex.Message);
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
        /// <summary>
        /// Find book by ID. Return null if there is no book with this ID.
        /// </summary>
        /// <param name="ID">ID of the book</param>
        /// <returns></returns>
        public static book Find(int ID)
        {
            try
            {
                return db.book.First(x=>x.ID == ID);
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        ///  Find book by its name and author. Return null if there is no book with this params.
        /// </summary>
        /// <param name="Name">Name od the book</param>
        /// <param name="Author">Author of the book</param>
        /// <returns></returns>
        public static book Find(string Name,string Author)
        {
            try
            {
                return db.book.First(x => (x.Name == Name && x.Author == Author));
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static void DeleteBook(book b)
        {
            db.book.Remove(b);
            db.SaveChanges();
        }
    }
}