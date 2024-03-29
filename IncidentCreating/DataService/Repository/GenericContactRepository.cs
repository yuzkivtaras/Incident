﻿using DataService.Data;
using DataService.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Repository
{
    public class GenericContactRepository<T> : IGenericContactRepository<T> where T : class
    {
        protected AppDbContext _context;
        internal DbSet<T> dbSet;

        public GenericContactRepository(AppDbContext context)
        {
            _context = context;
            dbSet = context.Set<T>();
        }

        public virtual async Task<bool> Add(T enity)
        {
            await dbSet.AddAsync(enity);
            return true;
        }

        public virtual async Task<IEnumerable<T>> All()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T> GetByEmail(string email)
        {
            return await dbSet.FindAsync(email);
        }
    }
}
