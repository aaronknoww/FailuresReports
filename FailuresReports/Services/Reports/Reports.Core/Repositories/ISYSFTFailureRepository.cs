using System;
using Reports.Core.Common;
using Reports.Core.Entities;

namespace Reports.Core.Repositories;

public interface ISYSFTFailureRepository : IFailureCommonRepository<FailureRegistrationSYSFT>
{   
    Task<bool> InsertAllByFailure(IEnumerable<FailureRegistrationSYSFT> values, string failureType);
}
