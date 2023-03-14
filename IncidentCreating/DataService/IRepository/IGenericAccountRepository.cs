using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.IRepository
{
    public interface IGenericAccountRepository<T> where T : class
    {
        Task<IEnumerable<T>> All();

        Task<T> GetByName(string name);

        Task<bool> Add(T enity);
    }
}
