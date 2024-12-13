using Reports.Core.Common;
using Reports.Core.Entities;

namespace Reports.Core.Repositories;

public interface ISYSVFFailureRepository : IFailureCommonRepository<FailureRegistrationSYSVF>
{
    Task<bool> InsertAllByFailure(IEnumerable<FailureRegistrationSYSVF> values, string failureType);

}
