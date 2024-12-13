using MediatR;

namespace Reports.Application.Querys.Common;

//This class is use by SysFT and SysVF 
public record GetFailureByAreaSysQuery<Dto>(string testArea) : IRequest<IEnumerable<Dto>> where Dto : class;


