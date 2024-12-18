using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

using ManagementLibraryMM.UI.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ManagementLibraryMM.UI.Controllers
{
    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;
        private List<Book> _books;

        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            BookSearch bookSearch = new BookSearch();

            _books = bookSearch.SearchData();

            ViewBag.BookList = _books;
            return View();
        }

        public IActionResult Update(int id)
        {
            BookSearch bookSearch = new BookSearch();

            bookSearch.UpdateData(id, "Caneta Azul", "Manuel Gomes", DateTime.Now);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            BookSearch bookSearch = new BookSearch();

            bookSearch.DeleteData(id);

            return RedirectToAction("Index");
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
