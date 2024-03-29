﻿using Entities.DbSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.IRepository
{
    public interface IContactsRepository : IGenericContactRepository<Contact>
    {
        Task<bool> UpdateContact(Contact contact);
    }
}
