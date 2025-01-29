using MediatR;
using Reports.Application.Dtos;

namespace Reports.Application.Querys.Common;

public record class GetAllValuesBySerialNumberQuery<Dto>(string SerialNumber ) : IRequest<IEnumerable<Dto>> where Dto : BaseDto;
