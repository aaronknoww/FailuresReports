using System;

namespace Reports.Core.Common;

public interface IGenericRepository<T> where T : class
{
    // Metodos genericos para cualquier tabla de una base de datos para hacer el CRUD.
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
    Task<List<T>> GetAsync();
    Task<T> GetByIdAsync(int id);

}
