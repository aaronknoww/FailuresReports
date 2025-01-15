using MediatR;
using Reports.Application.Dtos;

namespace Reports.Application.Querys.ToMrbQueries;
//TODO: Check if this query gonna be necessary because exist GetAllValuesByDateQuery if is implement a validator
public record class GetAllMrbQuery(DateTime start, DateTime end, int maxRows = 50) : IRequest<IEnumerable<ToMrbDto>>;