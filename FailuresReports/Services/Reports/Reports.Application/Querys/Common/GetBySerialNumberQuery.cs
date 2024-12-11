using MediatR;

namespace Reports.Application.Querys.Common;

public record class GetBySerialNumberQuery<Dto>(string SerialNumber ) : IRequest<Dto> where Dto : class;
