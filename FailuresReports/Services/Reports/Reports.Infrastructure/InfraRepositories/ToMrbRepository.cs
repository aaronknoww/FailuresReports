using Reports.Core.Entities;
using Reports.Core.Repositories;
using Reports.Infrastructure.InfraRepositories.Common;

namespace Reports.Infrastructure.InfraRepositories;

public class ToMrbRepository : GenericRepository<ToMrbEntity>, IToMrbRepository
{
    public Task<IEnumerable<ToMrbEntity>> GetAllMrbAsync(DateTime start, DateTime end, int maxRows = 50)
    {
        throw new NotImplementedException();
    }
}
