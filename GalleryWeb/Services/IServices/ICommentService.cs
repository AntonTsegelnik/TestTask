using Data.Interface.Models;
using GalleryWeb.Models;

namespace GalleryWeb.Services.IImageServices
{
    public interface ICommentService
    {
        void Save(CommentViewModel viewModel);
        void Update(CommentViewModel viewModel);
        List<Comment> GetAllComments();
        void Remove(int id);
        Comment Get(int id);


    }
}
