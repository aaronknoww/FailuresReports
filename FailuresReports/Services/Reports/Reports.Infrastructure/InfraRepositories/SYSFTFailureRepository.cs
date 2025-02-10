using Reports.Core.Entities;
using Reports.Core.Repositories;
using Reports.Infrastructure.InfraRepositories.Common;

namespace Reports.Infrastructure.InfraRepositories;

public class SYSFTFailureRepository : FailureCommonRepository<FailureRegistrationSYSFTEntity>, ISYSFTFailureRepository
{
    public Task<bool> InsertAllByFailure(IEnumerable<FailureRegistrationSYSFTEntity> values)
    {
        throw new NotImplementedException();
    }
}
