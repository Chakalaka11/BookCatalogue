using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookStack.Models;
using System.Web.Http.Results;
using System.Web.Http.Cors;

namespace BookStack.Controllers
{
    [EnableCors("*", "*", "*")]
    public class HomeController : ApiController
    {
        
        [HttpGet]
        public JsonResult<List<book>> Index()
        {
            return Json(BookManager.GetAllBooks());
        }
        [HttpPost]
        public JsonResult<string> AddBook(string name, string author, double price)
        {
            book new_book = new book() {
                Name = name,
                Author = author,
                Price = Convert.ToDecimal(price) 
                };
            return Json(BookManager.AddBook(new_book));
        }
    }
}
