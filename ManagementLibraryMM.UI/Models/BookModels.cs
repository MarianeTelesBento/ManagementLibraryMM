using Microsoft.AspNetCore.Mvc.Rendering;

namespace ManagementLibraryMM.UI.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime DatePublication { get; set; }

    }
}
