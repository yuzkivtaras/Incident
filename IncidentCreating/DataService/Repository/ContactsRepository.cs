﻿using DataService.Data;
using DataService.IRepository;
using Entities.DbSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Repository
{
    public class ContactsRepository : GenericRepository<Contact>, IContactsRepository
    {
        public ContactsRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}
