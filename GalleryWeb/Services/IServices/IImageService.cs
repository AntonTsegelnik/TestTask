using Data.Interface.Models;
using GalleryWeb.Models;

namespace GalleryWeb.Services.IImageServices
{
    public interface IImageService
    {
        void Save(ImageViewModel viewModel);
        List<Image> GetAllImages();
        void Remove(int id);
        Image Get(int id);
    }
}