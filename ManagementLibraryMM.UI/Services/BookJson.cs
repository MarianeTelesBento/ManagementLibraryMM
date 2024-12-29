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
    }
}
