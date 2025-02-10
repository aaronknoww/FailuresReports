using System;
using Reports.Core.Common;
using Reports.Core.Entities;

namespace Reports.Core.Repositories;

public interface ISYSFTFailureRepository : IFailureCommonRepository<FailureRegistrationSYSFTEntity>
{   
    Task<bool> InsertAllByFailure(IEnumerable<FailureRegistrationSYSFTEntity> values);
}
