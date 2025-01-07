using MediatR;

namespace Reports.Application.Querys.Common;

public record GetAllByUserIdQuery<Dto>(int userId, DateTime start, DateTime end, int maxRows) : IRequest<IEnumerable<Dto>> where Dto : class;
