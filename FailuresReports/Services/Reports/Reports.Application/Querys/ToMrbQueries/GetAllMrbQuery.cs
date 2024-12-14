using MediatR;
using Reports.Application.Dtos;

namespace Reports.Application.Querys.ToMrbQueries;

public record class GetAllMrbQuery : IRequest<IEnumerable<ToMrbDto>>;