using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ManagementLibraryMM.UI.Models;
using ManagementLibraryMM.UI.Services;
using Microsoft.Extensions.Logging;
using System.IO;

namespace ManagementLibraryMM.UI.Controllers
{
    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;
        private readonly IWebHostEnvironment _environment;

        public BookController(ILogger<BookController> logger, IWebHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }

        public IActionResult Index()
        {
            BookDataBase bookDataBase = new BookDataBase();
            var books = bookDataBase.SearchData();
            ViewBag.BookList = books;
            return View();
        }

        [HttpPost]
        public IActionResult Save(Book book)
        {
            BookDataBase bookDataBase = new BookDataBase();
            bookDataBase.UpdateData(book.Id, book.Title, book.Author, book.DatePublication);
            return Json(new { success = true });
        }

        public IActionResult Delete(int id)
        {
            BookDataBase bookDataBase = new BookDataBase();
            bookDataBase.DeleteData(id);
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            BookDataBase bookDataBase = new BookDataBase();
            bookDataBase.RegisterData(book.Title, book.Author, book.DatePublication);
            return View();
        }

        public IActionResult LoadFromJson()
        {
            return View();
        }

        public IActionResult SaveToJson()
        {
            return View();
        }

        public IActionResult Convert()
        {
            BookJson bookJson = new BookJson();
            bookJson.BookToJson();
            return RedirectToAction("SaveToJson");
        }

        public IActionResult Download()
        {
            string filePath = Path.Combine(_environment.WebRootPath, "Archive", "BookList.json");
            string fileType = "application/json";
            string fileName = "BookList.json";

            return PhysicalFile(filePath, fileType, fileName);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
