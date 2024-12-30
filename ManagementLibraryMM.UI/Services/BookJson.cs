using Newtonsoft.Json;
using ManagementLibraryMM.UI.Models;
using System.IO;

namespace ManagementLibraryMM.UI.Services
{
    public class BookJson
    {
        public void BookToJson()
        {
            BookDataBase bookDataBase = new BookDataBase();

            List<Book> bookList = bookDataBase.SearchData();

            string bookSerialized = JsonConvert.SerializeObject(bookList, Formatting.Indented);

            File.WriteAllText("wwwroot/Archive/BookList.json", bookSerialized);
        }

        public async void JsonToBook(IFormFile jsonFile)
        {
            using (var strem = new StreamReader(jsonFile.OpenReadStream()))
            {
                var jsonCotent = await strem.ReadToEndAsync();
                var books = JsonConvert.DeserializeObject<List<Book>>(jsonCotent);

                BookDataBase bookDataBase = new BookDataBase();

                foreach (var book in books)
                {
                    bookDataBase.RegisterData(book.Title, book.Author, book.DatePublication);
                }
            }
        }
    }
}
