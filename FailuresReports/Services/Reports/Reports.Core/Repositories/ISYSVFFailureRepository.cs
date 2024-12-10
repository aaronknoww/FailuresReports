using Reports.Core.Common;
using Reports.Core.Entities;

namespace Reports.Core.Repositories;

public interface ISYSVFFailureRepository : IGenericRepository<FailureRegistrationSYSVF>
{
    Task<IEnumerable<FailureRegistrationSYSVF>> GetFailureByArea(string testArea);
    Task<IEnumerable<FailureRegistrationSYSVF>> GetFailureByType(string type);
    Task<IEnumerable<FailureRegistrationSYSVF>> GetFailureByTestStation(string testStation);
    Task<IEnumerable<FailureRegistrationSYSVF>> GetFailureByBu(string bu);

    Task<bool> InsertAllByFailure(IEnumerable<FailureRegistrationSYSVF> values, string failureType);

}
