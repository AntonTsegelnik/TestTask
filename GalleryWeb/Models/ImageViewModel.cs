using System.ComponentModel.DataAnnotations;

namespace GalleryWeb.Models
{
    public class ImageViewModel
    {
        public int Id { get; set; }
       
        [Required]
        public string? Url { get; set; }

        [Required]
        public string? Name { get; set; }
        public List<string> Comments { get; set; } = new List<string>();
    }
}
