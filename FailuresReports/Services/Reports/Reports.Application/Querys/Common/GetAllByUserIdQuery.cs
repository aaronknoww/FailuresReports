using MediatR;

namespace Reports.Application.Querys.Common;

public record GetAllByUserIdQuery<Dto>(int userId) : IRequest<IEnumerable<Dto>> where Dto : class;
