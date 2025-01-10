using MediatR;
using Reports.Application.Dtos;

namespace Reports.Application.Querys.PendingValidationQueries;
//TODO: Check if this query gonna be necessary because exist GetAllValuesByDateQuery if is implement a validator
public record GetAllPendingValidationQuery(DateTime start, DateTime end, int maxRows=50) : IRequest<IEnumerable<PendingValidationDto>>;
