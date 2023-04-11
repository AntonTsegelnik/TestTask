
using Data.Interface.Models;

namespace Data.Interface.Repositories
{
    public interface ICommentRepository : IBaseRepository<Comment>
    {
        List<Comment> GetAllWithImage();
    }
   
}
