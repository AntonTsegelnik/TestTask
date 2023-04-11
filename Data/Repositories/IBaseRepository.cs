using Data.Interface.Models;

namespace Data.Interface.Repositories
{
    public interface IBaseRepository<T> where T : BaseModel
    {
         T? Get(int id);
         List<T> GetAll();
         void Remove(int id);
         void Save(T model);

        //public DbModel Get(int id);

        //public List<DbModel> GetAll();

        //public void Save(DbModel model);


        //public void Remove(DbModel model);

        //public void Remove(int id);

    }
}