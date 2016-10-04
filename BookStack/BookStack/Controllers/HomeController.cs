using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using BookStack.Models;
using System.Web.Http.Cors;

namespace BookStack.Controllers
{
    [EnableCors("*", "*", "*")]
    public class HomeController : ApiController
    {
        [HttpPost]
        public JsonResult<string> AddBook(dynamic param)
        {
            string a = param.name, b = param.author;
            decimal c = Convert.ToDecimal(param.price);
            return Json(BookManager.AddBook(a,b,c));
        }
        public object getall()
        {
            return Json(BookManager.GetAllBooks());
        }
        [HttpGet]
        public object index()
        {
            return Json(new {
                Head = "WebApi app for Book Catalogue ",
                Body = "This is small documentation of aviable methods in this API",
                Methods = new {
                    GetAll = new
                    {
                        Description = "Method , thats return all books in database.",
                        ULR = "/home/getall",
                        Params = "none",
                        HTTPMethod = "GET"
                    },
                    AddBook = new
                    {
                        Description = "Method , thats create new book in database. Return \"success\" in case of ended operation or log of internal server error",
                        URL = " /home/addbook",
                        Params = "{name,author,price}",
                        HTTPMethod = "POST"
                    }
                }
            });
        }
    }
}
