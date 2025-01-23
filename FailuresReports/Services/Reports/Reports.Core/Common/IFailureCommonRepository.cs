namespace Reports.Core.Common;

public interface IFailureCommonRepository<T> : IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllFailuresByAreaAsync(string testArea, DateTime start, DateTime end, int maxRows=50);
    Task<IEnumerable<T>> GetAllFailureByTypeAsync(string type, DateTime start, DateTime end, int maxRows=50); // return all register with that fail name.
    Task<IEnumerable<T>> GetAllFailureByTestStationAsync(string testStation, DateTime start, DateTime end, int maxRows=50);
    Task<IEnumerable<T>> GetAllFailuresByBuAsync(string bu, DateTime start, DateTime end, int maxRows=50);
    Task<IEnumerable<T>> GetAllFailuresFromTable(DateTime start, DateTime end, int maxRows=100); // To get all values of Failure Table. 

}
