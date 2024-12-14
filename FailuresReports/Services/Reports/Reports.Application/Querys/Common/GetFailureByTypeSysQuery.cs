using MediatR;

namespace Reports.Application.Querys.Common;

public record GetFailureByTypeSysQuery<Dto>(string type) : IRequest<IEnumerable<Dto>> where Dto : class;


