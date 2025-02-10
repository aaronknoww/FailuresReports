using Reports.Core.Common;
using Reports.Core.Entities;

namespace Reports.Core.Repositories;

public interface IPendingValidationRepository : IGenericRepository<PendingValidationEntity>
{
    Task<IEnumerable<PendingValidationEntity>> GetAllPendingValidationAsync(DateTime start, DateTime end, int maxRows = 50);

}
