using MediatR;

namespace Reports.Application.Commands.CommonComan;

public record DeleteBySerialnumberCommonCommand<Dto>(string SerialNumber) : IRequest<bool> where Dto : class;
