using DataService.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.IConfiguration
{
    public interface IUnitOfWork
    {
        IContactsRepository Contacts { get; }

        Task CompleteAsync();
    }
}
