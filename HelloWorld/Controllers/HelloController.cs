using HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class HelloController : Controller
    {
        // GET: Hello
        public ActionResult Index()
        {
            // cách sử dụng ViewBag
            ViewBag.MessageString = "Welcome to MVC";
            var message = new MessageModel();
            message.Welcome = "Hello Chuong";
            return View(message);
        }
    }
}