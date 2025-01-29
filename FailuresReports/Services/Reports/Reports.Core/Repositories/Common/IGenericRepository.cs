namespace Reports.Core.Common;

public interface IGenericRepository<T> where T : BaseEntity
{
    // Metodos genericos para cualquier tabla de una base de datos para hacer el CRUD.

    //Commands
    Task<bool> InsertRecordAsync(T entity); // To insert register into DB
    Task<bool> UpdateAsync(T entity); 
    Task<bool> DeleteBySerialnumberAsync(string serialNumber);

    

    //Queries.
    Task<IEnumerable<T>> GetAllValuesBySerialNumberAsync(string serialNumber);
    Task<IEnumerable<T>> GetAllValuesByDateAsync(DateTime start, DateTime end, int maxRows = 50);
    Task<IEnumerable<T>> GetAllValuesByUserIdAsync(int userId, DateTime start, DateTime end, int maxRows=50);

}
