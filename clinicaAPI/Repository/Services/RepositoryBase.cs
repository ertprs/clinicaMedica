using System.Threading.Tasks;
using ClinicaAPI.Data;
using ClinicaAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicaAPI.Repository.Services
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ClinicaContext Db;

        protected readonly DbSet<TEntity> DbSet;


        public RepositoryBase(ClinicaContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public void Dispose()
        {

        }

        public async Task Add(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            await SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            DbSet.Remove(entity);
            await SaveChangesAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await Db.SaveChangesAsync()) > 0;
        }
    }
}