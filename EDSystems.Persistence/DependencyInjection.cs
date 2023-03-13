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
             options.UseSqlite(connectionString);
            //options.UseNpgsql(connectionString);
            //AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        });
        services.AddScoped<IEDSystemsDbContext>(provider => provider.GetService<EDSystemsDbContext>());
        services.AddTransient<IDateTimeService, DateTimeService>();
        services.AddTransient<IGetExchangeRateService, GetExchangeRateService>();
        services.AddScoped<ICacheService, CacheService>();
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
            //For Branch Controller
            opetions.AddPolicy("CanGetAllBranches", policy => policy.RequireClaim("CanGetAllBranches"));
            opetions.AddPolicy("CanGetAllBranchesWithPagination", policy => policy.RequireClaim("CanGetAllBranchesWithPagination"));
            opetions.AddPolicy("CanGetBranchDetails", policy => policy.RequireClaim("CanGetBranchDetails"));
            opetions.AddPolicy("CanCreateBranch", policy => policy.RequireClaim("CanCreateBranch"));
            opetions.AddPolicy("CanUpdateBranch", policy => policy.RequireClaim("CanUpdateBranch"));
            opetions.AddPolicy("CanDeleteBranch", policy => policy.RequireClaim("CanDeleteBranch"));
            opetions.AddPolicy("CanDeleteBranches", policy => policy.RequireClaim("CanDeleteBranches"));

            //For Plan Controller
            opetions.AddPolicy("CanGetAllPlans", policy => policy.RequireClaim("CanGetAllPlans"));
            opetions.AddPolicy("CanGetAllPlansWithPagination", policy => policy.RequireClaim("CanGetAllPlansWithPagination"));
            opetions.AddPolicy("CanGetPlanDetails", policy => policy.RequireClaim("CanGetPlanDetails"));
            opetions.AddPolicy("CanCreatePlan", policy => policy.RequireClaim("CanCreatePlan"));
            opetions.AddPolicy("CanUpdatePlan", policy => policy.RequireClaim("CanUpdatePlan"));
            opetions.AddPolicy("CanDeletePlan", policy => policy.RequireClaim("CanDeletePlan"));
            opetions.AddPolicy("CanDeletePlans", policy => policy.RequireClaim("CanDeletePlans"));

            //For Status Controller
            opetions.AddPolicy("CanGetAllStatuses", policy => policy.RequireClaim("CanGetAllStatuses"));
            opetions.AddPolicy("CanGetAllStatusesWithPagination", policy => policy.RequireClaim("CanGetAllStatusesWithPagination"));
            opetions.AddPolicy("CanGetStatusDetails", policy => policy.RequireClaim("CanGetStatusDetails"));
            opetions.AddPolicy("CanCreateStatus", policy => policy.RequireClaim("CanCreateStatus"));
            opetions.AddPolicy("CanUpdateStatus", policy => policy.RequireClaim("CanUpdateStatus"));
            opetions.AddPolicy("CanDeleteStatus", policy => policy.RequireClaim("CanDeleteStatus"));
            opetions.AddPolicy("CanDeleteStatuses", policy => policy.RequireClaim("CanDeleteStatuses"));

            //For Parcel Controller
            opetions.AddPolicy("CanGetAllParcels", policy => policy.RequireClaim("CanGetAllParcels"));
            opetions.AddPolicy("CanGetAllParcelsWithPagination", policy => policy.RequireClaim("CanGetAllParcelsWithPagination"));
            opetions.AddPolicy("CanGetParcelDetails", policy => policy.RequireClaim("CanGetParcelDetails"));
            opetions.AddPolicy("CanCreateParcel", policy => policy.RequireClaim("CanCreateParcel"));
            opetions.AddPolicy("CanUpdateParcel", policy => policy.RequireClaim("CanUpdateParcel"));
            opetions.AddPolicy("CanDeleteParcel", policy => policy.RequireClaim("CanDeleteParcel"));
            opetions.AddPolicy("CanDeleteParcels", policy => policy.RequireClaim("CanDeleteParcels"));

            //For UserManager Controller
            opetions.AddPolicy("CanGetAllUsers", policy => policy.RequireClaim("CanGetAllUsers"));
            opetions.AddPolicy("CanGetAllUsersWithPagination", policy => policy.RequireClaim("CanGetAllUsersWithPagination"));
            opetions.AddPolicy("CanGetUserDetails", policy => policy.RequireClaim("CanGetUserDetails"));
            opetions.AddPolicy("CanCreateUser", policy => policy.RequireClaim("CanCreateUser"));
            opetions.AddPolicy("CanUpdateUser", policy => policy.RequireClaim("CanUpdateUser"));
            opetions.AddPolicy("CanDeleteUser", policy => policy.RequireClaim("CanDeleteUser"));
            opetions.AddPolicy("CanDeleteUsers", policy => policy.RequireClaim("CanDeleteUsers"));


        });

        services.AddScoped<RoleManager<Role>>();
        services.AddScoped<UserManager<User>>();

        return services;
    }
}