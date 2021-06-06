using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodingTest.EF_Operation
{
    //Generic interface for all CRUD operations
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
        Task<int> SaveAsync();

    }
}
