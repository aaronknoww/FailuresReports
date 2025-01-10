using MediatR;

namespace Reports.Application.Querys.Common;

public record GetAllFailureByBuSysQuery<Dto>(string bu,  DateTime start, DateTime end, int maxRows=50) : IRequest<IEnumerable<Dto>> where Dto : class;


