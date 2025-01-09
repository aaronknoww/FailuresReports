using MediatR;
using Reports.Application.Dtos;

namespace Reports.Application.Commands.CommonComan;

public record class InsertRecordCommand<Dto>(Dto EntityDto) : IRequest<bool> where Dto : BaseDto;