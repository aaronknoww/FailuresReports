using MediatR;

namespace Reports.Application.Commands;

public record class UpdateCommonCommand<T>(T EntityDto) : IRequest<bool>;
