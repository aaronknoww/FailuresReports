using MediatR;
using Reports.Application.Dtos;

namespace Reports.Application.Commands;

public record class UpdateCommonCommand<Dto>(Dto EntityDto) : IRequest<bool> where Dto : BaseDto;
