using Reports.Core.Common;
using Reports.Core.Entities;

namespace Reports.Core.Repositories;

public interface IToMrbRepository : IGenericRepository<ToMrbEntity>
{
    Task<IEnumerable<ToMrbEntity>> GetAllMrbAsync(DateTime start, DateTime end, int maxRows = 50);

}
