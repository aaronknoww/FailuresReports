using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using FluentValidation;
using Reports.Core.Common;
using Reports.Core.Repositories;
using Reports.Core.Entities;
using Reports.Application.Dtos;
using Reports.Application.Validators.DtoValidators;
using Reports.Application.Commands.CommonComan;
using Reports.Application.Validators.Common.Commands;
using Reports.Application.Querys.Common;
using MediatR;
using Reports.Application.Handlers.Common;
using FailuresReports.Services.Reports.Reports.Application.Handlers.Common.Queries;
using Reports.Application.Handlers.Common.Queries;
using Reports.Application.Handlers.Common.Commnad;
using Reports.Application.Commands;
using Reports.Application.Handlers.SysVFhandlers;
using Reports.Application.Handlers.SysFtHandlers;
using Reports.Application.Validators.Common;
using Reports.Application.Validators.Common.Queries;

namespace Reports.Application;

public static class ApplicationServicesRegistration
{
    // This class could be separete for registration type, like validartor registration and handlers reg
    public static IServiceCollection ServiceRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        // Register AutoMapper profiles
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        // Register MediatR
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        // Register Validators
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        // Generic Queries handlers registration
        services.AddScoped(
            typeof(IRequestHandler<GetAllByUserIdQuery<BaseDto>, IEnumerable<BaseDto>>), typeof(GetAllByUserIdGenericHandler<BaseEntity, BaseDto>));

        services.AddScoped(
            typeof(IRequestHandler<GetAllFailureByAreaSysQuery<BaseDto>, IEnumerable<BaseDto>>),
            typeof(GetAllFailureByAreaSysHandler<FailureRegistrationGeneric, FailiureDtoGeneric>));

        services.AddScoped(
            typeof(IRequestHandler<GetAllFailureByBuSysQuery<BaseDto>, IEnumerable<BaseDto>>),
            typeof(GetAllFailureByBuSysCommonHandler<FailureRegistrationGeneric, FailiureDtoGeneric>));

        services.AddScoped(
            typeof(IRequestHandler<GetAllFailureByTestStationSysQuery<BaseDto>, IEnumerable<BaseDto>>),
            typeof(GetAllFailureByTestStationSysCommonHandler<FailureRegistrationGeneric, FailiureDtoGeneric>));

        services.AddScoped(
            typeof(IRequestHandler<GetAllFailureByTypeSysQuery<BaseDto>, IEnumerable<BaseDto>>),
            typeof(GetAllFailureByTypeSysCommonHandler<FailureRegistrationGeneric, FailiureDtoGeneric>));

        services.AddScoped(
            typeof(IRequestHandler<GetAllFailureByBuSysQuery<BaseDto>, IEnumerable<BaseDto>>),
            typeof(GetAllFailureByBuSysCommonHandler<FailureRegistrationGeneric, FailiureDtoGeneric>));
        
        services.AddScoped(
            typeof(IRequestHandler<GetAllValuesByDateQuery<BaseDto>, IEnumerable<BaseDto>>),
            typeof(GetAllValuesByDateCommonHandler<BaseEntity, BaseDto>));

        // Concrete Queries Handlers Registration.


        // Generic Command Handlers Registration
        services.AddScoped(typeof(IRequestHandler<DeleteBySerialnumberCommonCommand<BaseDto>, bool>),typeof(GetAllValuesByDateCommonHandler<BaseEntity, BaseDto>));
        services.AddScoped(typeof(IRequestHandler<InsertRecordCommand<BaseDto>, bool>),typeof(InsertRecordCommonCommandHandler<BaseEntity, BaseDto>));
        services.AddScoped(typeof(IRequestHandler<UpdateCommonCommand<BaseDto>, bool>),typeof(UpdateCommonCommandHandler<BaseEntity, BaseDto>));
        
        // Concrete Command Handlers Registration
        services.AddScoped(typeof(IRequestHandler<InsertAllByFailiureCommonCommand<FailiureDtoGeneric>, bool>),typeof(InsertByFailureSysFTHandler));
        services.AddScoped(typeof(IRequestHandler<InsertAllByFailiureCommonCommand<FailiureDtoGeneric>, bool>),typeof(InsertAllByFailureSysVFHandler));


        // ****************************************************************** \\
        // ************************* VALIDATORS ***************************** \\ 
        // ****************************************************************** \\


        // Register Validators for DTOs
        services.AddScoped<IValidator<BaseDto>, BaseDtoValidator<BaseDto>>();
        services.AddScoped<IValidator<FailiureDtoGeneric>, FailureDtoGenericValidator<FailiureDtoGeneric>>();
        services.AddScoped<IValidator<FailureRegistrationSYSFTDto>, FailureRegistrationSYSFTDtoValidator>();
        services.AddScoped<IValidator<FailureRegistrationSYSVFDto>, FailureRegistrationSYSVFDtoValidator>();
        
        // Register Validators for Common Queries
        
        services.AddScoped<IValidator<GetAllByUserIdQuery<BaseDto>>, GetAllByUserIdValidator<BaseDto>>();
        services.AddScoped<IValidator<GetBySerialNumberQuery<BaseDto>>, GetBySerialNumberValidator<BaseDto>>();
        services.AddScoped<IValidator<GetAllFailureByAreaSysQuery<BaseDto>>, GetFailureByAreaSysValidator<BaseDto>>();
        services.AddScoped<IValidator<GetAllFailureByBuSysQuery<BaseDto>>, GetFailureByBuSysValidator<BaseDto>>();
        services.AddScoped<IValidator<GetAllFailureByTestStationSysQuery<BaseDto>>, GetFailureByTestStationSysValidator<BaseDto>>();
        services.AddScoped<IValidator<GetAllFailureByTypeSysQuery<BaseDto>>, GetFailureByTypeSysValidator<BaseDto>>();
        services.AddScoped<IValidator<GetAllValuesByDateQuery<BaseDto>>, GetValuesByDateValidator<BaseDto>>();


        // Register Validators for Common Commands

        services.AddScoped<IValidator<DeleteBySerialnumberCommonCommand<BaseDto>>, DeleteBySerialnumberCommonValidator<BaseDto>>();
        services.AddScoped<IValidator<InsertRecordCommand<BaseDto>>, InsertRecordCommandCommonValidator<BaseEntity, BaseDto>>();
        services.AddScoped<IValidator<InsertAllByFailiureCommonCommand<FailiureDtoGeneric>>, InsertAllByFailiureCommonCommandValidator<FailureRegistrationGeneric, FailiureDtoGeneric>>();
        services.AddScoped<IValidator<UpdateCommonCommand<BaseDto>>, UpdateCommonCommandValidator<BaseEntity, BaseDto>>();

        return services;
    }
}
