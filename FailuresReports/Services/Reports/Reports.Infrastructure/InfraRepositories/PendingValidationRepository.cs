using System;
using Reports.Core.Entities;
using Reports.Core.Repositories;
using Reports.Infrastructure.InfraRepositories.Common;

namespace Reports.Infrastructure.InfraRepositories;

public class PendingValidationRepository : GenericRepository<PendingValidationEntity>, IPendingValidationRepository
{
    public Task<IEnumerable<PendingValidationEntity>> GetAllPendingValidationAsync(DateTime start, DateTime end, int maxRows = 50)
    {
        throw new NotImplementedException();
    }
}
