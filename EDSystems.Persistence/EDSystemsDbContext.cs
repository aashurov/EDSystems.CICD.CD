using CleanArchitecture.Infrastructure.Persistence.Interceptors;
using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities;
using EDSystems.Domain.Entities.UserEntities;
using EDSystems.Domain.IdentityUserEntities;
using EDSystems.Persistence.EntityTypeConfigurations;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Persistence;

public class EDSystemsDbContext : IdentityDbContext<User, Role, int,
    UserClaim, UserRole, UserLogin,
    IdentityRoleClaim<int>, IdentityUserToken<int>>, IEDSystemsDbContext
{
    public DbSet<Branch> Branch { get; set; }
    public DbSet<ParcelBranch> ParcelBranch { get; set; }
    public DbSet<ParcelCost> ParcelCost { get; set; }
    public DbSet<ParcelDescription> ParcelDescription { get; set; }
    public DbSet<ParcelImage> ParcelImage { get; set; }
    public DbSet<ParcelSound> ParcelSound { get; set; }
    public DbSet<Parcel> Parcel { get; set; }
    public DbSet<ParcelOwners> ParcelOwners { get; set; }
    public DbSet<ParcelPlan> ParcelPlan { get; set; }
    public DbSet<ParcelSize> ParcelSize { get; set; }
    public DbSet<ParcelStatus> ParcelStatus { get; set; }
    public DbSet<ParcelJob> ParcelJob { get; set; }
    public DbSet<Expenses> Expenses { get; set; }
    public DbSet<ExpenseType> ExpenseType { get; set; }
    public DbSet<Account> Account { get; set; }
    public DbSet<AccountHistory> AccountHistory { get; set; }
    public DbSet<UserAccount> UserAccount { get; set; }
    public DbSet<UserAccountHistory> UserAccountHistory { get; set; }
    public DbSet<Plan> Plan { get; set; }
    public DbSet<Status> Status { get; set; }
    public DbSet<RefreshToken> RefreshToken { get; set; }
    public DbSet<UserClaim> UserClaim { get; set; }

    

    //public DbSet<UserRole> UserRoles { get; set; }

    public DbSet<User> User { get; set; }

    public DbSet<Role> Role { get; set; }

    private readonly IDateTimeService _dateTimeService;

    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;
    private readonly IMediator _mediator;

    public EDSystemsDbContext(DbContextOptions<EDSystemsDbContext> options, IDateTimeService dateTimeService, AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor, IMediator mediator) : base(options)
    {
        _dateTimeService = dateTimeService;
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
        _mediator = mediator;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchDomainEvents(this);

        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new BranchConfiguration());
        builder.ApplyConfiguration(new ParcelBranchConfiguration());
        builder.ApplyConfiguration(new ParcelCostConfiguration());
        builder.ApplyConfiguration(new ParcelDescriptionConfiguration());
        builder.ApplyConfiguration(new ParcelImageConfiguration());
        builder.ApplyConfiguration(new ParcelSoundConfiguration());
        builder.ApplyConfiguration(new ParcelConfiguration());
        builder.ApplyConfiguration(new ParcelOwnersConfiguration());
        builder.ApplyConfiguration(new ParcelPlanConfiguration());
        builder.ApplyConfiguration(new ParcelSizeConfiguration());
        builder.ApplyConfiguration(new ParcelStatusConfiguration());
        builder.ApplyConfiguration(new PlanConfiguration());
        builder.ApplyConfiguration(new TokensConfiguration());
        builder.ApplyConfiguration(new UserConfiguration());
        builder.ApplyConfiguration(new RoleConfiguration());
        builder.ApplyConfiguration(new AccountConfiguration());
        builder.ApplyConfiguration(new AccountHistoryConfiguration());
        builder.ApplyConfiguration(new UserAccountConfiguration());
        builder.ApplyConfiguration(new UserAccountHistoryConfiguration());
        builder.ApplyConfiguration(new CurrencyConfiguration());
        builder.ApplyConfiguration(new ParcelJobConfiguration());
        builder.ApplyConfiguration(new ExpensesConfiguration());

        builder.Entity<User>(b =>
        {
            // Each User can have many entries in the UserRole join table
            b.HasMany(e => e.UserClaim)
                .WithOne(e => e.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
        });

        builder.Entity<User>(b =>
        {
            // Each User can have many entries in the UserRole join table
            b.HasMany(e => e.UserRoles)
                .WithOne(e => e.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
        });


        builder.Entity<Role>(b =>
        {
            // Each Role can have many entries in the UserRole join table
            b.HasMany(e => e.UserRoles)
                .WithOne(e => e.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();
        });

        foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            switch (relationship.GetDefaultName())
            {
                case "FK_ParcelBranch_Branch_FromBranchId":
                    relationship.DeleteBehavior = DeleteBehavior.SetNull;
                    break;

                case "FK_ParcelBranch_Branch_ToBranchId":
                    relationship.DeleteBehavior = DeleteBehavior.SetNull;
                    break;

                case "FK_ParcelStatus_Status_StatusId":
                    relationship.DeleteBehavior = DeleteBehavior.SetNull;
                    break;

                case "FK_ParcelPlan_Plan_PlanId":
                    relationship.DeleteBehavior = DeleteBehavior.SetNull;
                    break;
            }
        }
        builder.Entity<Status>().HasData(
        new Status { Id = 1, Name = "Создан", Description = "Создан", DateCreated = _dateTimeService.Now },
        new Status { Id = 2, Name = "В пути", Description = "В пути", DateCreated = _dateTimeService.Now },
        new Status { Id = 3, Name = "Прибыл", Description = "Прибыл в пункт доставки", DateCreated = _dateTimeService.Now },
        new Status { Id = 4, Name = "У курьера", Description = "На доставке у курьера", DateCreated = _dateTimeService.Now },
        new Status { Id = 5, Name = "Доставлен", Description = "Доставлен", DateCreated = _dateTimeService.Now },
        new Status { Id = 6, Name = "Выдан", Description = "Выдан", DateCreated = _dateTimeService.Now });

        builder.Entity<Branch>().HasData(
       new Branch { Id = 1, Name = "Москва", Country = "Россия", City = "Москва", Email = "info@ethnologistics.asia", Address = "Российская Федерация, Московская область, г. Москва, Академический район, улица Винокурова 7/5, корпус 3, индекс 117449", Phone = "+765165498496", Code = "643", DateCreated = _dateTimeService.Now },
       new Branch { Id = 2, Name = "Ташкент", Country = "Узбекистан", City = "Ташкент", Email = "info@ethnologistics.asia", Address = "Республика Узбекистан, г. Ташкент, Юнусабадский район, улица Кашгар 11,", Phone = "+998984651", Code = "860", DateCreated = _dateTimeService.Now },
       new Branch { Id = 3, Name = "Бишкек", Country = "Киргистан", City = "Бишкек", Email = "info@ethnologistics.asia", Address = "Киргизия, Бишкек, Жибек-Жолу д 443/1", Phone = "+765165498496", Code = "417", DateCreated = _dateTimeService.Now },
       new Branch { Id = 4, Name = "Душанбе", Country = "Таджикистан", City = "Душанбе", Email = "info@ethnologistics.asia", Address = "Душанбе 122", Phone = "+665165498496", Code = "762", DateCreated = _dateTimeService.Now },
       new Branch { Id = 5, Name = "Алматы", Country = "Казахстан", City = "Алматы", Email = "info@ethnologistics.asia", Address = "Алматы 123", Phone = "+665165498496", Code = "398", DateCreated = _dateTimeService.Now },
       new Branch { Id = 6, Name = "Стамбул", Country = "Турция", City = "Стамбул", Email = "info@ethnologistics.asia", Address = "Хайдарпашша", Phone = "+665165498496", Code = "792", DateCreated = _dateTimeService.Now });

        Currency cr = new Currency();
        
        builder.Entity<Account>().HasData(
        new Account { Id = 1, Number = "643840USD", Balance = 0, Name = "Валютный счет Москвы", DateCreated = _dateTimeService.Now, BranchId = 1, CurrencyId = 1 },
        new Account { Id = 2, Number = "643643RUB", Balance = 0, Name = "Рублевый счет Москвы", DateCreated = _dateTimeService.Now, BranchId = 1, CurrencyId = 2 },
        new Account { Id = 3, Number = "860840USD", Balance = 0, Name = "Валютный счет Ташкента", DateCreated = _dateTimeService.Now, BranchId = 2, CurrencyId = 1 },
        new Account { Id = 4, Number = "860643RUB", Balance = 0, Name = "Рублевый счет Ташкента", DateCreated = _dateTimeService.Now, BranchId = 2, CurrencyId = 2 },
        new Account { Id = 5, Number = "417840USD", Balance = 0, Name = "Валютный счет Бишкека", DateCreated = _dateTimeService.Now, BranchId = 3, CurrencyId = 1 },
        new Account { Id = 6, Number = "417643RUB", Balance = 0, Name = "Рублевый счет Бишкека", DateCreated = _dateTimeService.Now, BranchId = 3, CurrencyId = 2 },
        new Account { Id = 7, Number = "972840USD", Balance = 0, Name = "Валютный счет Душанбе", DateCreated = _dateTimeService.Now, BranchId = 4, CurrencyId = 1 },
        new Account { Id = 8, Number = "972843RUB", Balance = 0, Name = "Рублевый счет Душанбе", DateCreated = _dateTimeService.Now, BranchId = 4, CurrencyId = 2 },
        new Account { Id = 9, Number = "398840USD", Balance = 0, Name = "Валютный счет Алматы", DateCreated = _dateTimeService.Now, BranchId = 5, CurrencyId = 1 },
        new Account { Id = 10, Number = "398643RUB", Balance = 0, Name = "Рублевый счет Алматы", DateCreated = _dateTimeService.Now, BranchId = 5, CurrencyId = 2 },
        new Account { Id = 11, Number = "792840USD", Balance = 0, Name = "Валютный счет Стамбул", DateCreated = _dateTimeService.Now, BranchId = 6, CurrencyId = 1 },
        new Account { Id = 12, Number = "792949TRY", Balance = 0, Name = "Лировый счет Стамбул", DateCreated = _dateTimeService.Now, BranchId = 6, CurrencyId = 5 });

        builder.Entity<UserAccount>().HasData(
            new UserAccount { Id = 1, Number = "30a8f9cc-840USD", Balance = 0, Name = "Валютный счет", DateCreated = _dateTimeService.Now, UserId = "1", CurrencyId = 1 },
            new UserAccount { Id = 2, Number = "cadaa51d-840USD", Balance = 0, Name = "Валютный счет", DateCreated = _dateTimeService.Now, UserId = "2", CurrencyId = 1 },
            new UserAccount { Id = 3, Number = "5a6f1681-840USD", Balance = 0, Name = "Валютный счет", DateCreated = _dateTimeService.Now, UserId = "3", CurrencyId = 1 },
            new UserAccount { Id = 4, Number = "3b9d7f21-840USD", Balance = 0, Name = "Валютный счет", DateCreated = _dateTimeService.Now, UserId = "1", CurrencyId = 1 },
            new UserAccount { Id = 5, Number = "0a1e5c27-840USD", Balance = 0, Name = "Валютный счет", DateCreated = _dateTimeService.Now, UserId = "2", CurrencyId = 1 },
            new UserAccount { Id = 6, Number = "e13b576b-840USD", Balance = 0, Name = "Валютный счет", DateCreated = _dateTimeService.Now, UserId = "3", CurrencyId = 1 });

        builder.Entity<ExpenseType>().HasData(
            new ExpenseType { Id = 1, Name = "Зарплата", Description = "Зарплата", DateCreated = _dateTimeService.Now },
            new ExpenseType { Id = 2, Name = "Аванс", Description = "Аванс", DateCreated = _dateTimeService.Now },
            new ExpenseType { Id = 3, Name = "Курерам за перевозку", Description = "Курерам за перевозку", DateCreated = _dateTimeService.Now },
            new ExpenseType { Id = 4, Name = "Обед", Description = "Обед", DateCreated = _dateTimeService.Now },
            new ExpenseType { Id = 5, Name = "Карзи Хасана", Description = "Карзи Хасана", DateCreated = _dateTimeService.Now },
            new ExpenseType { Id = 6, Name = "Депозит", Description = "Депозит", DateCreated = _dateTimeService.Now },
            new ExpenseType { Id = 7, Name = "За перевозку до филиала", Description = "За перевозку до филиала", DateCreated = _dateTimeService.Now },
            new ExpenseType { Id = 8, Name = "За доставку до получателя", Description = "За доставку до получателя", DateCreated = _dateTimeService.Now },
            new ExpenseType { Id = 9, Name = "За забор посылки", Description = "За забор посылки", DateCreated = _dateTimeService.Now },
            new ExpenseType { Id = 10, Name = "За выкуп", Description = "За выкуп", DateCreated = _dateTimeService.Now },
            new ExpenseType { Id = 11, Name = "Ковертация", Description = "Ковертация", DateCreated = _dateTimeService.Now },
            new ExpenseType { Id = 12, Name = "Перевод", Description = "Перевод", DateCreated = _dateTimeService.Now },
            new ExpenseType { Id = 13, Name = "За мелкие расходы", Description = "За мелкие расходы", DateCreated = _dateTimeService.Now });

        builder.Entity<Role>().HasData(
            new Role { Id = 1, Name = "Administrator", NormalizedName = "ADMINISTRATOR", ConcurrencyStamp = Guid.NewGuid().ToString("D") },
            new Role { Id = 2, Name = "Manager", NormalizedName = "MANAGER", ConcurrencyStamp = Guid.NewGuid().ToString("D") },
            new Role { Id = 3, Name = "Staff", NormalizedName = "STAFF", ConcurrencyStamp = Guid.NewGuid().ToString("D") },
            new Role { Id = 4, Name = "Courier", NormalizedName = "COURIER", ConcurrencyStamp = Guid.NewGuid().ToString("D") },
            new Role { Id = 5, Name = "Customer", NormalizedName = "CUSTOMER", ConcurrencyStamp = Guid.NewGuid().ToString("D") });

        //builder.Entity<UserClaim>().HasData(
        //    new UserClaim { Id = 1, ClaimType = "CanAddBranch", ClaimValue = "CanAddBranch", UserId = 1 },
        //    new UserClaim { Id = 2, ClaimType = "Manager", ClaimValue = "CanOnlyRead", UserId = 2 });

        var hasher = new PasswordHasher<User>();
        var password = hasher.HashPassword(null, "Qwertyruru20@@");
        builder.Entity<User>().HasData(

        new User() { Id = 1, UserName = "administrator", NormalizedUserName = "ADMINISTRATOR", Email = "administrator@gmail.com", NormalizedEmail = "ADMINISTRATOR@GMAIL.COM", FirstName = "EDSystem", LastName = "Administrator", Address = "Республика Узбекистан, г. Ташкент, Кашгар 11, 100099", PhoneNumber = "998970000675", PasswordHash = password, DateCreated = _dateTimeService.Now },
        new User() { Id = 2, UserName = "hayrulloh", NormalizedUserName = "HAYRULLOH", Email = "hayrulloh@gmail.com", NormalizedEmail = "HAYRULLOH@GMAIL.COM", FirstName = "EDTashkent", LastName = "Hayrulloh", Address = "Республика Узбекистан, г. Ташкент, Кашгар 11, 100099", PhoneNumber = "998935788886", PasswordHash = password, DateCreated = _dateTimeService.Now },
        new User() { Id = 3, UserName = "nodir", NormalizedUserName = "NODIR", Email = "Nodir@gmail.com", NormalizedEmail = "NODIR@GMAIL.COM", FirstName = "EDTashkent", LastName = "Nodir", Address = "Республика Узбекистан, г. Ташкент, Кашгар 11, 100099", PhoneNumber = "998909046605", PasswordHash = password, DateCreated = _dateTimeService.Now },
        new User() { Id = 4, UserName = "javohir", NormalizedUserName = "JAVOHIR", Email = "Javohir@gmail.com", NormalizedEmail = "JAVOHIR@GMAIL.COM", FirstName = "EDTashkent", LastName = "Javohir", Address = "Республика Узбекистан, г. Ташкент, Кашгар 11, 100099", PhoneNumber = "998931710966", PasswordHash = password, DateCreated = _dateTimeService.Now },
        new User() { Id = 5, UserName = "ismoil", NormalizedUserName = "ISMOIL", Email = "Ismoil@gmail.com", NormalizedEmail = "ISMOIL@GMAIL.COM", FirstName = "EDTashkent", LastName = "Ismoil", Address = "Республика Узбекистан, г. Ташкент, Кашгар 11, 100099", PhoneNumber = "998977093262", PasswordHash = password, DateCreated = _dateTimeService.Now });


        builder.Entity<UserRole>().HasData(
         new UserRole { RoleId = 1, UserId = 1 },
         new UserRole { RoleId = 2, UserId = 2 });

        builder.Entity<UserClaim>().HasData(
            new UserClaim { Id= 1, UserId = 1, ClaimType = "CanGetAllBranches", ClaimValue = "CanGetAllBranches" },
            new UserClaim { Id= 2, UserId = 1, ClaimType = "CanGetAllBranchesWithPagination", ClaimValue = "CanGetAllBranchesWithPagination" },
            new UserClaim { Id= 3, UserId = 1, ClaimType = "CanGetBranchDetails", ClaimValue = "CanGetBranchDetails" },
            new UserClaim { Id= 4, UserId = 1, ClaimType = "CanCreateBranch", ClaimValue = "CanCreateBranch" },
            new UserClaim { Id= 5, UserId = 1, ClaimType = "CanUpdateBranch", ClaimValue = "CanUpdateBranch" },
            new UserClaim { Id= 6, UserId = 1, ClaimType = "CanDeleteBranch", ClaimValue = "CanDeleteBranch" },
            new UserClaim { Id= 7, UserId = 1, ClaimType = "CanDeleteBranches", ClaimValue = "CanDeleteBranches" },
            new UserClaim { Id= 8, UserId = 1, ClaimType = "CanGetAllPlans", ClaimValue = "CanGetAllPlans" },
            new UserClaim { Id= 9, UserId = 1, ClaimType = "CanGetAllPlansWithPagination", ClaimValue = "CanGetAllPlansWithPagination" },
            new UserClaim { Id= 10,UserId = 1, ClaimType = "CanGetPlanDetails", ClaimValue = "CanGetPlanDetails" },
            new UserClaim { Id= 11,UserId = 1, ClaimType = "CanCreatePlan", ClaimValue = "CanCreatePlan" },
            new UserClaim { Id= 12,UserId = 1, ClaimType = "CanUpdatePlan", ClaimValue = "CanUpdatePlan" },
            new UserClaim { Id= 13,UserId = 1, ClaimType = "CanDeletePlan", ClaimValue = "CanDeletePlan" },
            new UserClaim { Id= 14,UserId = 1, ClaimType = "CanDeletePlans", ClaimValue = "CanDeletePlans" },
            new UserClaim { Id= 15,UserId = 1, ClaimType = "CanGetAllStatuses", ClaimValue = "CanGetAllStatuses", },
            new UserClaim { Id= 16,UserId = 1, ClaimType = "CanGetAllStatusesWithPagination", ClaimValue = "CanGetAllStatusesWithPagination" },
            new UserClaim { Id= 17,UserId = 1, ClaimType = "CanGetStatusDetails", ClaimValue = "CanGetStatusDetails" },
            new UserClaim { Id= 18,UserId = 1, ClaimType = "CanCreateStatus", ClaimValue = "CanCreateStatus" },
            new UserClaim { Id= 19,UserId = 1, ClaimType = "CanUpdateStatus", ClaimValue = "CanUpdateStatus" },
            new UserClaim { Id= 20,UserId = 1, ClaimType = "CanDeleteStatus", ClaimValue = "CanDeleteStatus" },
            new UserClaim { Id= 21,UserId = 1, ClaimType = "CanDeleteStatuses", ClaimValue = "CanDeleteStatuses" },
            new UserClaim { Id= 22,UserId = 1, ClaimType = "CanGetAllParcels", ClaimValue = "CanGetAllParcels" },
            new UserClaim { Id= 23,UserId = 1, ClaimType = "CanGetAllParcelsWithPagination", ClaimValue = "CanGetAllParcelsWithPagination" },
            new UserClaim { Id= 24,UserId = 1, ClaimType = "CanGetParcelDetails", ClaimValue = "CanGetParcelDetails" },
            new UserClaim { Id= 25,UserId = 1, ClaimType = "CanCreateParcel", ClaimValue = "CanCreateParcel" },
            new UserClaim { Id= 26,UserId = 1, ClaimType = "CanUpdateParcel", ClaimValue = "CanUpdateParcel" },
            new UserClaim { Id= 27,UserId = 1, ClaimType = "CanDeleteParcel", ClaimValue = "CanDeleteParcel" },
            new UserClaim { Id= 28,UserId = 1, ClaimType = "CanDeleteParcels", ClaimValue = "CanDeleteParcels" },
            new UserClaim { Id= 29,UserId = 1, ClaimType = "CanGetAllUsers", ClaimValue = "CanGetAllUsers" },
            new UserClaim { Id= 30,UserId = 1, ClaimType = "CanGetAllUsersWithPagination", ClaimValue = "CanGetAllUsersWithPagination" },
            new UserClaim { Id= 31,UserId = 1, ClaimType = "CanGetUserDetails", ClaimValue = "CanGetUserDetails" },
            new UserClaim { Id= 32,UserId = 1, ClaimType = "CanCreateUser", ClaimValue = "CanCreateUser" },
            new UserClaim { Id= 33,UserId = 1, ClaimType = "CanUpdateUser", ClaimValue = "CanUpdateUser" },
            new UserClaim { Id= 34,UserId = 1, ClaimType = "CanDeleteUser", ClaimValue = "CanDeleteUser" },
            new UserClaim { Id = 35, UserId = 1, ClaimType = "CanDeleteUsers", ClaimValue = "CanDeleteUsers" }
        );

        builder.Entity<Plan>().HasData(
             new Plan { Id = 1, Name = "Стандарт", Cost = 7, Description = "Description", DateCreated = _dateTimeService.Now },
             new Plan { Id = 2, Name = "Экспресс", Cost = 12, Description = "Description", DateCreated = _dateTimeService.Now },
             new Plan { Id = 3, Name = "Ультра", Cost = 30, Description = "Description", DateCreated = _dateTimeService.Now },
             new Plan { Id = 5, Name = "Авто", Cost = 5, Description = "Description", DateCreated = _dateTimeService.Now });

        builder.Entity<Currency>().HasData(
        new Currency { Id = 1, Name = "Доллар", Code = "USD", Number = 840, Country = "Соединенные Штаты Америки", DateCreated = _dateTimeService.Now },
        new Currency { Id = 2, Name = "Сум", Code = "UZS", Number = 860, Country = "Республика Узбекистан", DateCreated = _dateTimeService.Now },
        new Currency { Id = 3, Name = "Рубль", Code = "RUB", Number = 643, Country = "Российская Федерация", DateCreated = _dateTimeService.Now },
        new Currency { Id = 4, Name = "Тенге", Code = "KZT", Number = 398, Country = "Республика Казахстан", DateCreated = _dateTimeService.Now },
        new Currency { Id = 5, Name = "Лира", Code = "TRY", Number = 949, Country = "Турция", DateCreated = _dateTimeService.Now },
        new Currency { Id = 6, Name = "Дирхам", Code = "AED", Number = 784, Country = "Объедененные Арабские Эмираты", DateCreated = _dateTimeService.Now },
        new Currency { Id = 7, Name = "Сом", Code = "KGS", Number = 417, Country = "Кыргызская Республика", DateCreated = _dateTimeService.Now },
        new Currency { Id = 8, Name = "Сомони", Code = "TJS", Number = 972, Country = "Республика Таджикистан", DateCreated = _dateTimeService.Now }
   );
    }
}