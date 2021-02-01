using System.Collections.Generic;
using System.Threading.Tasks;

namespace Base.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByID(int ID);

        Task<List<TEntity>> GetAll();

        Task<bool> Add(TEntity newRecord);

        Task<bool> Update(TEntity record);

        Task<bool> Delete(int ID);
    }
}
