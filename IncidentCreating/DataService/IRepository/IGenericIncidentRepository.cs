using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.IRepository
{
    public interface IGenericIncidentRepository<T> where T : class
    {
        Task<IEnumerable<T>> All();

        Task<T> GetById(Guid id);

        Task<bool> Add(T enity);
    }
}
