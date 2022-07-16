﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace N_TierArchitectureToDoApp.DataDomain.EfCoreRepository
{
    public interface IRepositoryBase<T> where T : class, new()
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteAll(IEnumerable<T> entities);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> FindAsync(Expression<Func<T, bool>> expression);
    }
}
