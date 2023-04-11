namespace Data.Interface.Models
{
    public class Image : BaseModel 
    { 

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public virtual List<Comment> Comments { get; set; } 

    }
}
