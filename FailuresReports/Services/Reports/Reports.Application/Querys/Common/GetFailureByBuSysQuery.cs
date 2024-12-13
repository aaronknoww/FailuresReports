namespace Reports.Application.Querys.Common;

public record GetFailureByBuSysQuery<Dto>(string bu) : IRequest<IEnumerable<Dto>> where Dto : class;


