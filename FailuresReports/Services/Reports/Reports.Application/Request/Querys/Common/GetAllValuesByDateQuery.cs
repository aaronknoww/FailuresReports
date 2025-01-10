using MediatR;

namespace Reports.Application.Querys.Common;

public record GetAllValuesByDateQuery<Dto>(DateTime start, DateTime end, int maxRows = 50) : IRequest<IEnumerable<Dto>> where Dto : class;
