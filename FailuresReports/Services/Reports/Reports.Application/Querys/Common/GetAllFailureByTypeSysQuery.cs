using MediatR;

namespace Reports.Application.Querys.Common;

public record GetAllFailureByTypeSysQuery<Dto>(string type, DateTime start, DateTime end, int maxRows=50) : IRequest<IEnumerable<Dto>> where Dto : class;


