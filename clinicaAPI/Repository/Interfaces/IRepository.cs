using System;
using System.Threading.Tasks;

namespace ClinicaAPI.Repository.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {

        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);

        Task<bool> SaveChangesAsync();

    }
}