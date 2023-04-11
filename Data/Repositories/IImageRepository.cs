

using Data.Interface.Models;

namespace Data.Interface.Repositories
{
    public interface IImageRepository : IBaseRepository<Image>
    {
        Image GetImageByName(string name);
        void RemoveByName(string name);
    }
}
