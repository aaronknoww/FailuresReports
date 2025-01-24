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
using Reports.Application.Validators.Common;
using Reports.Application.Validators.Common.Queries;

namespace Reports.Application;

public static class ApplicationServicesRegistration
{
    // Main entry point for service registration
    public static IServiceCollection ServiceRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        // Add Handlers and Validators
        services.AddApplicationHandlers();
        services.AddApplicationValidators();

        return services;
    }

    // Handlers Registration
    public static IServiceCollection AddApplicationHandlers(this IServiceCollection services)
    {
        // Generic Query Handlers
        services.AddScopedHandler<GetAllByUserIdQuery<BaseDto>, GetAllByUserIdGenericHandler<BaseEntity, BaseDto>, IEnumerable<BaseDto>>();
        services.AddScopedHandler<GetAllFailureByAreaSysQuery<BaseDto>, GetAllFailureByAreaSysHandler<FailureRegistrationGeneric, FailiureDtoGeneric>, IEnumerable<BaseDto>>();
        services.AddScopedHandler<GetAllFailureByBuSysQuery<BaseDto>, GetAllFailureByBuSysCommonHandler<FailureRegistrationGeneric, FailiureDtoGeneric>, IEnumerable<BaseDto>>();
        services.AddScopedHandler<GetAllValuesByDateQuery<BaseDto>, GetAllValuesByDateCommonHandler<BaseEntity, BaseDto>, IEnumerable<BaseDto>>();

        // Generic Command Handlers
        services.AddScopedHandler<DeleteBySerialnumberCommonCommand<BaseDto>, DeleteBySerialnumberCommonCommandHandler<BaseEntity, BaseDto>, bool>();
        services.AddScopedHandler<InsertRecordCommand<BaseDto>, InsertRecordCommonCommandHandler<BaseEntity, BaseDto>, bool>();
        services.AddScopedHandler<UpdateCommonCommand<BaseDto>, UpdateCommonCommandHandler<BaseEntity, BaseDto>, bool>();

        // Concrete Command Handlers
        services.AddScopedHandler<InsertAllByFailiureCommonCommand<FailiureDtoGeneric>, InsertByFailureSysFTHandler, bool>();
        services.AddScopedHandler<InsertAllByFailiureCommonCommand<FailiureDtoGeneric>, InsertAllByFailureSysVFHandler, bool>();

        return services;
    }

    // Validators Registration
    public static IServiceCollection AddApplicationValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        // Additional scoped validators for specific scenarios
        services.AddScoped<IValidator<BaseDto>, BaseDtoValidator<BaseDto>>();
        services.AddScoped<IValidator<FailiureDtoGeneric>, FailureDtoGenericValidator<FailiureDtoGeneric>>();
        services.AddScoped<IValidator<FailureRegistrationSYSFTDto>, FailureRegistrationSYSFTDtoValidator>();
        services.AddScoped<IValidator<FailureRegistrationSYSVFDto>, FailureRegistrationSYSVFDtoValidator>();

        // Validators for Queries
        services.AddScoped<IValidator<GetAllByUserIdQuery<BaseDto>>, GetAllByUserIdValidator<BaseDto>>();
        services.AddScoped<IValidator<GetBySerialNumberQuery<BaseDto>>, GetBySerialNumberValidator<BaseDto>>();
        services.AddScoped<IValidator<GetAllFailureByAreaSysQuery<BaseDto>>, GetFailureByAreaSysValidator<BaseDto>>();

        // Validators for Commands
        services.AddScoped<IValidator<DeleteBySerialnumberCommonCommand<BaseDto>>, DeleteBySerialnumberCommonValidator<BaseDto>>();
        services.AddScoped<IValidator<InsertRecordCommand<BaseDto>>, InsertRecordCommandCommonValidator<BaseEntity, BaseDto>>();
        services.AddScoped<IValidator<InsertAllByFailiureCommonCommand<FailiureDtoGeneric>>, InsertAllByFailiureCommonCommandValidator<FailureRegistrationGeneric, FailiureDtoGeneric>>();
        services.AddScoped<IValidator<UpdateCommonCommand<BaseDto>>, UpdateCommonCommandValidator<BaseEntity, BaseDto>>();

        return services;
    }

    // Extension method for simplifying handler registrations to avoid typing typeof like services.AddScoped(typeof(IRequestHandler<TRequest, TResponse>), typeof(THandler))
    private static IServiceCollection AddScopedHandler<TRequest, THandler, TResponse>(
        this IServiceCollection services)
        where TRequest : IRequest<TResponse>
        where THandler : class, IRequestHandler<TRequest, TResponse>
    {
        return services.AddScoped(typeof(IRequestHandler<TRequest, TResponse>), typeof(THandler));
    }
}
