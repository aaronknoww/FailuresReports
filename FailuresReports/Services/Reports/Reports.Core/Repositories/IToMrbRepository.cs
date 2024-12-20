using Reports.Core.Common;
using Reports.Core.Entities;

namespace Reports.Core.Repositories;

public interface IToMrbRepository : IGenericRepository<ToMrb>
{
    Task<IEnumerable<ToMrb>> GetAllMrbAsync();

}
