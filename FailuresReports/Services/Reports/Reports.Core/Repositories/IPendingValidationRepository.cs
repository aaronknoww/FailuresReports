using Reports.Core.Common;
using Reports.Core.Entities;

namespace Reports.Core.Repositories;

public interface IPendingValidationRepository : IGenericRepository<PendingValidation>
{
    Task<IEnumerable<PendingValidation>> GetAllPendingValidationAsync();

}
