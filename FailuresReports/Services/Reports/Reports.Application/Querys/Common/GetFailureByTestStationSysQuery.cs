namespace Reports.Application.Querys.Common;

public record GetFailureByTestStationSysQuery<Dto>(string testStation) : IRequest<IEnumerable<Dto>> where Dto : class;


