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
    }
}
