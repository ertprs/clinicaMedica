using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicaAPI.Repository.Interfaces;

namespace ClinicaAPI.Repository.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
         protected readonly IRepository<TEntity> _Repository;

        public ServiceBase(IRepository<TEntity> repository)
        {
            this._Repository = repository;
        }

        public void Add(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            _Repository.Dispose();
        }

        public Task<List<TEntity>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<TEntity> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new System.NotImplementedException();
        }
        
    }
}