using Reports.Core.Common;
using Reports.Core.Entities;

namespace Reports.Infrastructure.InfraRepositories.Common;

public class FailureCommonRepository<T> : IFailureCommonRepository<T> where T : FailureRegistrationGeneric
{
    public Task<bool> DeleteBySerialnumberAsync(string serialNumber)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> GetAllFailureByTestStationAsync(string testStation, DateTime start, DateTime end, int maxRows = 50)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> GetAllFailureByTypeAsync(string type, DateTime start, DateTime end, int maxRows = 50)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> GetAllFailuresByAreaAsync(string testArea, DateTime start, DateTime end, int maxRows = 50)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> GetAllFailuresByBuAsync(string bu, DateTime start, DateTime end, int maxRows = 50)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> GetAllFailuresFromTable(DateTime start, DateTime end, int maxRows = 100)
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
