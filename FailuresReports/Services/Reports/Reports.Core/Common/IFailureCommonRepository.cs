using System;

namespace Reports.Core.Common;

public interface IFailureCommonRepository<T> : IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllFailuresByAreaAsync(string testArea);
    Task<IEnumerable<T>> GetAllFailureByTypeAsync(string type); // return all register with that fail name.
    Task<IEnumerable<T>> GetAllFailureByTestStationAsync(string testStation);
    Task<IEnumerable<T>> GetAllFailuresByBuAsync(string bu);
    Task<IEnumerable<T>> GetAllFailuresFromTable(); // To get all values of Failure Table. 

}
