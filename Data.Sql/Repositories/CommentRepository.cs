using Data.Interface.Models;
using Data.Interface.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Sql.Repositories
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(WebContext webContext) : base(webContext)
        {
        }

        public List<Comment> GetAllWithImage()
        {
          return _dbSet.ToList();
        }
    }
}
