using Data.Interface.Models;
using System.ComponentModel.DataAnnotations;

namespace GalleryWeb.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime Date { get; set; }
        
        public int ImageId { get; set; }
    }
}
