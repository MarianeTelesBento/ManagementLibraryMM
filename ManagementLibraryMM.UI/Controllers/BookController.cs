using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

using ManagementLibraryMM.UI.Models;

namespace ManagementLibraryMM.UI.Controllers
{
    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;
        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            BookRegister bookRegister = new BookRegister();

            bookRegister.RegisterData(book.Title, book.Author, book.DatePublication);

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}
