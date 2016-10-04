using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookStack.Models;

namespace BookStack.Tests
{
    [TestClass]
    public class BookStackUnitTest
    {
        book test_book = new book()
        {
            Author = "Test",
            Name = "Test",
            Price = 10.00m
        };
        [TestMethod]
        public void AddBookTest()
        {
            if (BookManager.Find(test_book.Name, test_book.Author) != null)
            {
                book delete = BookManager.Find(test_book.Name, test_book.Author);
                BookManager.DeleteBook(delete);
            }
            BookManager.AddBook(test_book);
            book founded_book = BookManager.Find(test_book.ID);
            Assert.AreEqual<book>(test_book, founded_book);
        }
        [TestMethod]
        public void GetAllBooksTest()
        {
            book from_all = BookManager.GetAllBooks().Find(x => (x.Name == test_book.Name && x.Author == test_book.Name));
            Assert.AreEqual<book>(test_book, from_all);
        }
    }
}
