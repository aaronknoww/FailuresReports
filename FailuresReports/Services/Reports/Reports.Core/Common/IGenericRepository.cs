using System;

namespace Reports.Core.Common;

public interface IGenericRepository<T> where T : class
{
    // Metodos genericos para cualquier tabla de una base de datos para hacer el CRUD.

    //Commands
    Task<bool> InsertRecordAsync(T entity); // To insert register into DB
    Task<bool> UpdateAsync(T entity); 
    Task<bool> DeleteAsync(T entity);

    

    //Queries.
    Task<T> GetBySerialNumberAsync(string serialNumber);
    Task<IEnumerable<T>> GetValuesByDateAsync(DateTime start, DateTime end);
    Task<IEnumerable<T>> GetAllByUserIdAsync(int userId);

}
