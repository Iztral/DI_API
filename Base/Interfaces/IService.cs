using System.Collections.Generic;

namespace Base.Interfaces
{
    public interface IService<TEntity> where TEntity : class
    {
        TEntity GetByID(int ID);

        List<TEntity> GetAll();

        bool Add(TEntity newRecord);

        bool Update(TEntity record);

        bool Delete(int ID);
    }
}
