using System;
using Reports.Core.Common;
using Reports.Core.Entities;

namespace Reports.Core.Repositories;

public interface ISYSFTFailureRepository : IGenericRepository<FailureRegistrationSYSFT>
{
    Task<IEnumerable<FailureRegistrationSYSFT>> GetFailureByArea(string testArea);
    Task<IEnumerable<FailureRegistrationSYSFT>> GetFailureByType(string type);
    Task<IEnumerable<FailureRegistrationSYSFT>> GetFailureByTestStation(string testStation);
    Task<IEnumerable<FailureRegistrationSYSFT>> GetFailureByBu(string bu);

    Task<bool> InsertAllByFailure(IEnumerable<FailureRegistrationSYSFT> values, string failureType);


}
