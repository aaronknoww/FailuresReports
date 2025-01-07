using MediatR;

namespace Reports.Application.Querys.Common;

public record GetValuesByDateQuery<Dto>(DateTime Start, DateTime End, int maxRows = 50) : IRequest<IEnumerable<Dto>> where Dto : class;
