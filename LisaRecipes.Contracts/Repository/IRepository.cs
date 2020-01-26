using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LisaRecipes.Contracts.Repository
{
    public interface IRepository<T>
    {
        public Task<T> Get(int id);
        public Task<IEnumerable<T>> GetAll();
        public Task<T> Update(T obj);
        public Task<T> Create(T obj);
        public Task Delete(int id);

    }
}
