using System;

namespace Reports.Core.Common;

public interface IFailureCommonRepository<T> : IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetFailureByArea(string testArea);
    Task<IEnumerable<T>> GetFailureByType(string type);
    Task<IEnumerable<T>> GetFailureByTestStation(string testStation);
    Task<IEnumerable<T>> GetFailureByBu(string bu);    

}
