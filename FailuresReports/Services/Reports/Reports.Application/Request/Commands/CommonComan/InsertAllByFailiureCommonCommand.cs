using MediatR;
using Reports.Application.Dtos;

namespace Reports.Application.Commands.CommonComan;

public record class InsertAllByFailiureCommonCommand<Dto>(IEnumerable<Dto> FailuresDto) : IRequest<bool> where Dto : FailiureDtoGeneric;
