using Reports.Core.Entities;
using Reports.Core.Repositories;

namespace Reports.Infrastructure.InfraRepositories.Common;

public class SYSVFFailureRepository : FailureCommonRepository<FailureRegistrationSYSVFEntity>, ISYSVFFailureRepository
{
    public Task<bool> InsertAllByFailure(IEnumerable<FailureRegistrationSYSVFEntity> values, string failureType)
    {
        throw new NotImplementedException();
    }

    public Task<bool> InsertAllByFailure(IEnumerable<FailureRegistrationSYSVFEntity> sysVFFailures)
    {
        throw new NotImplementedException();
    }
}
