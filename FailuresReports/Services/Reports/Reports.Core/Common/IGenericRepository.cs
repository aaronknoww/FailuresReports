using System;

namespace Reports.Core.Common;

public interface IGenericRepository<T> where T : class
{
    // Metodos genericos para cualquier tabla de una base de datos para hacer el CRUD.
    Task<T> CreateAsync(T entity); // To insert register into DB
    Task<T> UpdateAsync(T entity); 
    Task<T> DeleteAsync(T entity);

    

    //Queries.
    Task<T> GetBySerialNumberAsync(string serialNumber);
    Task<IEnumerable<T>> GetValuesByDateAsync(DateTime start, DateTime end);
    Task<IEnumerable<T>> GetAllByUserIdAsync(int userId);

}
