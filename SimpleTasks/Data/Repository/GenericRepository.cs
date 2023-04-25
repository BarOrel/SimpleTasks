using Microsoft.EntityFrameworkCore;

namespace SimpleTasks.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly SimpleTask_DbContext context;

        public GenericRepository(SimpleTask_DbContext context) 
        {
            this.context = context;
        }
        
        public async Task<IEnumerable<T>> GetAll() => await context.Set<T>().ToListAsync();

        public async Task<T> GetById(object id)
        {
            var result = await context.Set<T>().FindAsync(id);
            return result;
        }

        public async Task Insert(T obj)
        {
            await context.Set<T>().AddAsync(obj);
            await Save();
        }

        public async Task<T> Find(T obj)
        {
            var res = await context.Set<T>().ToListAsync();
            return res.FirstOrDefault(n => n == obj);
        }

        public async Task Update(T obj)
        {
            context.Set<T>().Update(obj);
            await Save();
        }

        public async Task Delete(T obj)
        {
            T result = await Find(obj);
            context.Set<T>().Remove(result);
            await Save();
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

    }
}
