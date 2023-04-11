using Data.Interface.Models;
using Data.Interface.Repositories;
using Data.Sql.Repositories;
using GalleryWeb.Models;
using GalleryWeb.Services.IImageServices;

namespace GalleryWeb.Services
{
    public class CommentService : ICommentService
    {
        private ICommentRepository _commentRepository;
        private IImageRepository _imageRepository;



        public CommentService(IImageRepository imageRepository,ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
            _imageRepository = imageRepository;
        }


        public void Save(CommentViewModel viewModel)
        {
            viewModel.Id = 0;
            viewModel.Date = DateTime.Now;

            var commentModel =  Content(viewModel);
            _commentRepository.Save(commentModel);
        }
        public void Update(CommentViewModel viewModel)
        {

            viewModel.Date = DateTime.Now;

            var commentModel = Content(viewModel);
            _commentRepository.Save(commentModel);
        }

        public Comment Get(int id)
        {
            return _commentRepository.Get(id);
        }

        public List<Comment> GetAllComments()
        {
            return _commentRepository.GetAllWithImage();
        }

        public void Remove(int id)
        {
            _commentRepository.Remove(id);
                
        }

        private Comment Content(CommentViewModel viewModel) {
            var image = _imageRepository.Get(viewModel.ImageId);
            var CommentModel = new Comment()
            {
                Id = viewModel.Id,
                Content = viewModel.Content,
                Image = image,
                Date = viewModel.Date


            };

            return CommentModel;
        }
    }
}
