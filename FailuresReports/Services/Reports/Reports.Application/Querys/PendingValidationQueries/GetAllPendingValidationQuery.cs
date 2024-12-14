using System;
using MediatR;
using Reports.Application.Dtos;

namespace Reports.Application.Querys.PendingValidationQueries;

public record GetAllPendingValidationQuery : IRequest<IEnumerable<PendingValidationDto>>;
