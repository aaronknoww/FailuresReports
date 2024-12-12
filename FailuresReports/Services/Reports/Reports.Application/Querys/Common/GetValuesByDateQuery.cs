using MediatR;

namespace Reports.Application.Querys.Common;

public record GetValuesByDateQuery<Dto>(DateTime Start, DateTime End) : IRequest<IEnumerable<Dto>> where Dto : class;
