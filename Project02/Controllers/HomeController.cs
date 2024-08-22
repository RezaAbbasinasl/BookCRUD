using Microsoft.AspNetCore.Mvc;
using Project02.DAL;
using Project02.Models;
using System.Diagnostics;

namespace Project02.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        BookDAL bookDAL = new BookDAL();
        public IActionResult Index()
        {
            var book = bookDAL.GetAllBook();
            return View(book);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Book book)
        {
            if(ModelState.IsValid)
            {
                bookDAL.AddBook(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = bookDAL.GetById(id);

            if (book == null)
            {
                return RedirectToAction("Index");
            }
            return View(book);
        }
        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if(ModelState.IsValid)
            {
                
                bookDAL.EditBook(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
