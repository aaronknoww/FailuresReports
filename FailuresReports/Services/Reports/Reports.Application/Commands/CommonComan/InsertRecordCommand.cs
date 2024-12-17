using MediatR;

namespace Reports.Application.Commands.CommonComan;

public record class InsertRecordCommand<T>(T EntityDto) : IRequest<bool> where T : class
{

}
