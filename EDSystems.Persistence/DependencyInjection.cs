using CleanArchitecture.Infrastructure.Persistence.Interceptors;
using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities.UserEntities;
using EDSystems.Persistence.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EDSystems.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<AuditableEntitySaveChangesInterceptor>();
        var connectionString = configuration["DbConnection"];
        services.AddDbContext<EDSystemsDbContext>(options =>
        {
            //options.UseSqlite(connectionString);
            options.UseNpgsql(connectionString);
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        });
        services.AddScoped<IEDSystemsDbContext>(provider => provider.GetService<EDSystemsDbContext>());
        services.AddTransient<IDateTimeService, DateTimeService>();
        services.AddTransient<IGetExchangeRateService, GetExchangeRateService>();
        //services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
        //    .AddDefaultUI()
        //    .AddEntityFrameworkStores<EDSystemsDbContext>();

        //services.AddIdentity<ApplicationUser, ApplicationUser>()
        //.AddEntityFrameworkStores<EDSystemsDbContext>()
        //.AddDefaultUI()
        //.AddDefaultTokenProviders();
        services.AddIdentity<User, Role>(options => options.SignIn.RequireConfirmedAccount = false)
            //.AddDefaultUI()
            .AddEntityFrameworkStores<EDSystemsDbContext>();
        services.AddAuthorization(opetions =>
        {
            opetions.AddPolicy("CanAddBranch",
                policy => policy.RequireClaim("CanAddBranch"));
        });

        services.AddScoped<RoleManager<Role>>();
        services.AddScoped<UserManager<User>>();

        return services;
    }
}