using System.Web.Mvc;

namespace GalleryWeb.Models
{
    public class ContentViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [AllowHtml]
        public string Contents { get; set; }
        public byte[] Image { get; set; }
    }
}
