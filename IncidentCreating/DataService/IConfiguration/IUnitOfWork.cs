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
        IAccountRepository Accounts { get; }
        IIncidentRepository Incidents { get; }

        Task CompleteAsync();
    }
}
