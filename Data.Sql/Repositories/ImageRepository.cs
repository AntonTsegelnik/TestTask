using Data.Interface.Repositories;
using Data.Interface.Models;

namespace Data.Sql.Repositories
{
    public class ImageRepository : BaseRepository<Image>,IImageRepository
    {
        public ImageRepository(WebContext webContext) : base(webContext)
        {
        }

        public Image? GetImageByName(string name)
        {
            return _dbSet.FirstOrDefault(x => x.Name == name);
        }

        public void RemoveByName(string name)
        {
            var user = GetImageByName(name); 
            _dbSet.Remove(user);
            _webContext.SaveChanges();
        }

    }
}
