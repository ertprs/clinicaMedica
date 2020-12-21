using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicaAPI.Repository.Interfaces
{
     public interface IServiceBase<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity entity);
        Task<TEntity> GetById(int id);
        Task<List<TEntity>> GetAll();
        void Update(TEntity entity);
        void Remove(TEntity entity);
        Task<int> SaveChanges();


    }
}