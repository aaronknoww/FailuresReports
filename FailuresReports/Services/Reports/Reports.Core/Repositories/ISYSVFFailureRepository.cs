using Reports.Core.Common;
using Reports.Core.Entities;

namespace Reports.Core.Repositories;

public interface ISYSVFFailureRepository : IFailureCommonRepository<FailureRegistrationSYSVFEntity>
{
    Task<bool> InsertAllByFailure(IEnumerable<FailureRegistrationSYSVFEntity> values, string failureType);
    Task<bool> InsertAllByFailure(IEnumerable<FailureRegistrationSYSVFEntity> sysVFFailures);
}
