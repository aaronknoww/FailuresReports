using MediatR;
using Reports.Application.Dtos;

namespace Reports.Application.Querys.Common;

//This class is use by SysFT and SysVF 
public record GetAllFailureByAreaSysQuery<Dto>(string testArea, DateTime start, DateTime end, int maxRows) : IRequest<IEnumerable<Dto>> where Dto : FailiureDtoGeneric;


