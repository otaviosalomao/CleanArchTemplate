﻿using Domain.Entities;

namespace Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);        
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<int> SaveChangesAsync();
    }
}
