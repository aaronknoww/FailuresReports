using Reports.Core.Common;

namespace Reports.Infrastructure.InfraRepositories.Common;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    public Task<bool> DeleteBySerialnumberAsync(string serialNumber)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> GetAllValuesByDateAsync(DateTime start, DateTime end, int maxRows = 50)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> GetAllValuesBySerialNumberAsync(string serialNumber)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> GetAllValuesByUserIdAsync(int userId, DateTime start, DateTime end, int maxRows = 50)
    {
        throw new NotImplementedException();
    }

    public Task<bool> InsertRecordAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }
}
