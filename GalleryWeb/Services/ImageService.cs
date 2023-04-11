using Data.Interface.Models;
using Data.Interface.Repositories;
using GalleryWeb.Models;
using GalleryWeb.Services.IImageServices;

namespace GalleryWeb.Services
{
    public class ImageService : IImageService
    {
     
        private IImageRepository _imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public void Save(ImageViewModel viewModel)
        {
            var dbImageModel = new Image() 
            { 
                Id = viewModel.Id,
                Name = viewModel.Name,
                ImageUrl = viewModel.Url,
              
            };

            _imageRepository.Save(dbImageModel);
        }

        public Image Get(int id)
        {
            return _imageRepository.Get(id);
        }

        public List<Image> GetAllImages()
        {

            return _imageRepository.GetAll();


        }

     
        public void Remove(int id)
        {
            _imageRepository.Remove(id);
        }
    }
}
