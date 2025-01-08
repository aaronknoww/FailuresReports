using MediatR;

namespace Reports.Application.Querys.Common;

public record GetFailureByTestStationSysQuery<Dto>(string testStation, DateTime start, DateTime end, int maxRows) : IRequest<IEnumerable<Dto>> where Dto : class;


