﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.IRepository
{
    public interface IGenericContactRepository<T> where T : class
    {
        Task<IEnumerable<T>> All();

        Task<T> GetByEmail(string email);

        Task<bool> Add(T enity);
    }
}
