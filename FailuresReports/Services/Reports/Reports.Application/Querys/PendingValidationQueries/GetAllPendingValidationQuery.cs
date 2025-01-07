using MediatR;
using Reports.Application.Dtos;

namespace Reports.Application.Querys.PendingValidationQueries;

public record GetAllPendingValidationQuery(DateTime start, DateTime end, int maxRows=50) : IRequest<IEnumerable<PendingValidationDto>>;
