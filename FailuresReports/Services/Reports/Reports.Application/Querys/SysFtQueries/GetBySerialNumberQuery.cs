using System;
using MediatR;
using Reports.Application.Dtos;

namespace Reports.Application.Querys.SysFtQueries;

public record GetBySerialNumberQuery(string SerialNumber) : IRequest<FailureRegistrationSYSFTDto>;
