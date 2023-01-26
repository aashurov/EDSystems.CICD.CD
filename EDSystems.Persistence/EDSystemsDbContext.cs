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

public class EDSystemsDbContext : IdentityDbContext<User, Role, string,
    IdentityUserClaim<string>, UserRole, IdentityUserLogin<string>,
    IdentityRoleClaim<string>, IdentityUserToken<string>>, IEDSystemsDbContext
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

    //public DbSet<UserRole> UserRoles { get; set; }

    //public DbSet<User> User { get; set; }

    //public DbSet<Role> Role { get; set; }
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

        //builder.Entity<User>(b =>
        //{
        //    // Each User can have many entries in the UserRole join table
        //    b.HasMany(e => e.UserRoles)
        //        .WithOne(e => e.User)
        //        .HasForeignKey(ur => ur.UserId)
        //        .IsRequired();
        //});

        //builder.Entity<Role>(b =>
        //{
        //    // Each Role can have many entries in the UserRole join table
        //    b.HasMany(e => e.UserRoles)
        //        .WithOne(e => e.Role)
        //        .HasForeignKey(ur => ur.RoleId)
        //        .IsRequired();
        //});

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
            new UserAccount { Id = 1, Number = "30a8f9cc-840USD", Balance = 0, Name = "Валютный счет", DateCreated = _dateTimeService.Now, UserId = "30a8f9cc-8d37-4d93-ab2f-774428387e4a", CurrencyId = 1 },
            new UserAccount { Id = 2, Number = "cadaa51d-840USD", Balance = 0, Name = "Валютный счет", DateCreated = _dateTimeService.Now, UserId = "cadaa51d-ddb3-4564-a8c5-79e80c98a032", CurrencyId = 1 },
            new UserAccount { Id = 3, Number = "5a6f1681-840USD", Balance = 0, Name = "Валютный счет", DateCreated = _dateTimeService.Now, UserId = "5a6f1681-c582-46f5-905b-4eb2c222dcf5", CurrencyId = 1 },
            new UserAccount { Id = 4, Number = "3b9d7f21-840USD", Balance = 0, Name = "Валютный счет", DateCreated = _dateTimeService.Now, UserId = "3b9d7f21-1d66-4c98-8648-64a68777bccb", CurrencyId = 1 },
            new UserAccount { Id = 5, Number = "0a1e5c27-840USD", Balance = 0, Name = "Валютный счет", DateCreated = _dateTimeService.Now, UserId = "0a1e5c27-0b09-4f60-a9c3-8618791a8672", CurrencyId = 1 },
            new UserAccount { Id = 6, Number = "e13b576b-840USD", Balance = 0, Name = "Валютный счет", DateCreated = _dateTimeService.Now, UserId = "e13b576b-afbe-4b4c-aaad-64fd9bee3852", CurrencyId = 1 });

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
            new Role { Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = "Administrator", NormalizedName = "ADMINISTRATOR", ConcurrencyStamp = Guid.NewGuid().ToString("D") },
            new Role { Id = "68373a2b-932e-4fff-a7a9-b31e156d4101", Name = "Manager", NormalizedName = "MANAGER", ConcurrencyStamp = Guid.NewGuid().ToString("D") },
            new Role { Id = "5919c97a-b888-4858-bbbe-0123a1952624", Name = "Staff", NormalizedName = "STAFF", ConcurrencyStamp = Guid.NewGuid().ToString("D") },
            new Role { Id = "401bc2e9-3a0b-4281-9685-d6b36fc37d31", Name = "Courier", NormalizedName = "COURIER", ConcurrencyStamp = Guid.NewGuid().ToString("D") },
            new Role { Id = "336b1b38-f4c9-4844-8dcb-b59a0d7f0533", Name = "Customer", NormalizedName = "CUSTOMER", ConcurrencyStamp = Guid.NewGuid().ToString("D") });

        builder.Entity<UserClaim>().HasData(
            new UserClaim { Id = 1, ClaimType = "CanAddBranch", ClaimValue = "CanAddBranch", UserId = "30a8f9cc-8d37-4d93-ab2f-774428387e4a" },
            new UserClaim { Id = 2, ClaimType = "Manager", ClaimValue = "CanOnlyRead", UserId = "cadaa51d-ddb3-4564-a8c5-79e80c98a032" });

        var hasher = new PasswordHasher<User>();
        var password = hasher.HashPassword(null, "Qwertyruru20@@");
        builder.Entity<User>().HasData(

        new User() { Id = "30a8f9cc-8d37-4d93-ab2f-774428387e4a", UserName = "administrator", NormalizedUserName = "ADMINISTRATOR", Email = "administrator@gmail.com", NormalizedEmail = "ADMINISTRATOR@GMAIL.COM", FirstName = "EDSystem", LastName = "Administrator", Address = "Республика Узбекистан, г. Ташкент, Кашгар 11, 100099", PhoneNumber = "998970000675", PasswordHash = password, DateCreated = _dateTimeService.Now },
        new User() { Id = "cadaa51d-ddb3-4564-a8c5-79e80c98a032", UserName = "hayrulloh", NormalizedUserName = "HAYRULLOH", Email = "hayrulloh@gmail.com", NormalizedEmail = "HAYRULLOH@GMAIL.COM", FirstName = "EDTashkent", LastName = "Hayrulloh", Address = "Республика Узбекистан, г. Ташкент, Кашгар 11, 100099", PhoneNumber = "998935788886", PasswordHash = password, DateCreated = _dateTimeService.Now },
        new User() { Id = "5a6f1681-c582-46f5-905b-4eb2c222dcf5", UserName = "nodir", NormalizedUserName = "NODIR", Email = "Nodir@gmail.com", NormalizedEmail = "NODIR@GMAIL.COM", FirstName = "EDTashkent", LastName = "Nodir", Address = "Республика Узбекистан, г. Ташкент, Кашгар 11, 100099", PhoneNumber = "998909046605", PasswordHash = password, DateCreated = _dateTimeService.Now },
        new User() { Id = "3b9d7f21-1d66-4c98-8648-64a68777bccb", UserName = "javohir", NormalizedUserName = "JAVOHIR", Email = "Javohir@gmail.com", NormalizedEmail = "JAVOHIR@GMAIL.COM", FirstName = "EDTashkent", LastName = "Javohir", Address = "Республика Узбекистан, г. Ташкент, Кашгар 11, 100099", PhoneNumber = "998931710966", PasswordHash = password, DateCreated = _dateTimeService.Now },
        new User() { Id = "0a1e5c27-0b09-4f60-a9c3-8618791a8672", UserName = "ismoil", NormalizedUserName = "ISMOIL", Email = "Ismoil@gmail.com", NormalizedEmail = "ISMOIL@GMAIL.COM", FirstName = "EDTashkent", LastName = "Ismoil", Address = "Республика Узбекистан, г. Ташкент, Кашгар 11, 100099", PhoneNumber = "998977093262", PasswordHash = password, DateCreated = _dateTimeService.Now },
        new User() { Id = "e13b576b-afbe-4b4c-aaad-64fd9bee3852", UserName = "sadulla", NormalizedUserName = "SADULLA", Email = "Sadulla@gmail.com", NormalizedEmail = "SADULLA@GMAIL.COM", FirstName = "EDTashkent", LastName = "Sadulla", Address = "Республика Узбекистан, г. Ташкент, Кашгар 11, 100099", PhoneNumber = "998994885995", PasswordHash = password, DateCreated = _dateTimeService.Now },
        new User() { Id = "34a0eb9b-6797-40f7-a84c-aa31cdd4cdc6", UserName = "ubaydulla", NormalizedUserName = "UBAYDULLA", Email = "Ubaydulla@gmail.com", NormalizedEmail = "UBAYDULLA@GMAIL.COM", FirstName = "EDTashkent", LastName = "Ubaydulla", Address = "Республика Узбекистан, г. Ташкент, Кашгар 11, 100099", PhoneNumber = "998990500033", PasswordHash = password, DateCreated = _dateTimeService.Now },
        new User() { Id = "131d5dd1-6bf1-4f52-be90-00815000fb57", UserName = "khikmatillo", NormalizedUserName = "KHIKMATILLO", Email = "Khikmatillo@gmail.com", NormalizedEmail = "KHIKMATILLO@GMAIL.COM", FirstName = "EDTashkent", LastName = "Khikmatillo", Address = "Республика Узбекистан, г. Ташкент, Кашгар 11, 100099", PhoneNumber = "998974468090", PasswordHash = password, DateCreated = _dateTimeService.Now },
        new User() { Id = "221c0048-08c9-4e72-8f5c-ddf4039f9488", UserName = "abbos", NormalizedUserName = "ABBOS", Email = "Abbos@gmail.com", NormalizedEmail = "ABBOS@GMAIL.COM", FirstName = "EDTashkent", LastName = "Abbos", Address = "Республика Узбекистан, г. Ташкент, Кашгар 11, 100099", PhoneNumber = "998903550022", PasswordHash = password, DateCreated = _dateTimeService.Now },
        new User() { Id = "e0c3bef9-fd70-421e-b07b-055c38b6d77c", UserName = "shohruh", NormalizedUserName = "SHOHRUH", Email = "Shohruh@gmail.com", NormalizedEmail = "SHOHRUH@GMAIL.COM", FirstName = "EDMoscow", LastName = "Shohruh", Address = "Российская Федерация, Московская область, г. Москва, Академический район, улица Винокурова 7/5, корпус 3, индекс 117449", PhoneNumber = "79060470085", PasswordHash = password, DateCreated = _dateTimeService.Now },
        new User() { Id = "4ff7819d-8e17-4aa8-a0da-964c2db21591", UserName = "ulugbek", NormalizedUserName = "ULUGBEK", Email = "Ulugbek@gmail.com", NormalizedEmail = "ULUGBEK@GMAIL.COM", FirstName = "EDMoscow", LastName = "Ulugbek", Address = "Российская Федерация, Московская область, г. Москва, Академический район, улица Винокурова 7/5, корпус 3, индекс 117449", PhoneNumber = "79777403487", PasswordHash = password, DateCreated = _dateTimeService.Now },
        new User() { Id = "92db214d-cd73-4fbc-8b34-1dc0709ba0b2", UserName = "abdulaziz", NormalizedUserName = "ABDULAZIZ", Email = "Abdulaziz@gmail.com", NormalizedEmail = "ABDULAZIZ@GMAIL.COM", FirstName = "EDMoscow", LastName = "Abdulaziz", Address = "Российская Федерация, Московская область, г. Москва, Академический район, улица Винокурова 7/5, корпус 3, индекс 117449", PhoneNumber = "79691799000", PasswordHash = password, DateCreated = _dateTimeService.Now },
        new User() { Id = "9c57fadd-110a-4b45-aa89-69aa141564c6", UserName = "doniyor", NormalizedUserName = "DONIYOR", Email = "Doniyor@gmail.com", NormalizedEmail = "DONIYOR@GMAIL.COM", FirstName = "EDMoscow", LastName = "Doniyor", Address = "Российская Федерация, Московская область, г. Москва, Академический район, улица Винокурова 7/5, корпус 3, индекс 117449", PhoneNumber = "79777601654", PasswordHash = password, DateCreated = _dateTimeService.Now },
        new User() { Id = "eb6a85b0-a7fb-4f8e-9bea-03825e6f020f", UserName = "shaxzod", NormalizedUserName = "SHAXZOD", Email = "Shaxzod@gmail.com", NormalizedEmail = "SHAXZOD@GMAIL.COM", FirstName = "EDMoscow", LastName = "Shaxzod", Address = "Российская Федерация, Московская область, г. Москва, Академический район, улица Винокурова 7/5, корпус 3, индекс 117449", PhoneNumber = "79163870009", PasswordHash = password, DateCreated = _dateTimeService.Now },
        new User() { Id = "11fafeb4-c7c1-463c-bb1e-55203e68dfdf", UserName = "umar", NormalizedUserName = "UMAR", Email = "Umar@gmail.com", NormalizedEmail = "UMAR@GMAIL.COM", FirstName = "EDMoscow", LastName = "Umar", Address = "Российская Федерация, Московская область, г. Москва, Академический район, улица Винокурова 7/5, корпус 3, индекс 117449", PhoneNumber = "79963321030", PasswordHash = password, DateCreated = _dateTimeService.Now },
        new User() { Id = "92b7c777-0d3e-4026-844f-20164bb0f97e", UserName = "abror", NormalizedUserName = "ABROR", Email = "Abror@gmail.com", NormalizedEmail = "ABROR@GMAIL.COM", FirstName = "EDMoscow", LastName = "Abror", Address = "Российская Федерация, Московская область, г. Москва, Академический район, улица Винокурова 7/5, корпус 3, индекс 117449", PhoneNumber = "79296800899", PasswordHash = password, DateCreated = _dateTimeService.Now });

        builder.Entity<UserRole>().HasData(
         new UserRole { RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210", UserId = "30a8f9cc-8d37-4d93-ab2f-774428387e4a" },
         new UserRole { RoleId = "401bc2e9-3a0b-4281-9685-d6b36fc37d31", UserId = "cadaa51d-ddb3-4564-a8c5-79e80c98a032" },
         new UserRole { RoleId = "401bc2e9-3a0b-4281-9685-d6b36fc37d31", UserId = "5a6f1681-c582-46f5-905b-4eb2c222dcf5" },
         new UserRole { RoleId = "401bc2e9-3a0b-4281-9685-d6b36fc37d31", UserId = "3b9d7f21-1d66-4c98-8648-64a68777bccb" },
         new UserRole { RoleId = "401bc2e9-3a0b-4281-9685-d6b36fc37d31", UserId = "0a1e5c27-0b09-4f60-a9c3-8618791a8672" },
         new UserRole { RoleId = "401bc2e9-3a0b-4281-9685-d6b36fc37d31", UserId = "e13b576b-afbe-4b4c-aaad-64fd9bee3852" },
         new UserRole { RoleId = "401bc2e9-3a0b-4281-9685-d6b36fc37d31", UserId = "34a0eb9b-6797-40f7-a84c-aa31cdd4cdc6" },
         new UserRole { RoleId = "68373a2b-932e-4fff-a7a9-b31e156d4101", UserId = "131d5dd1-6bf1-4f52-be90-00815000fb57" },
         new UserRole { RoleId = "401bc2e9-3a0b-4281-9685-d6b36fc37d31", UserId = "221c0048-08c9-4e72-8f5c-ddf4039f9488" },
         new UserRole { RoleId = "401bc2e9-3a0b-4281-9685-d6b36fc37d31", UserId = "e0c3bef9-fd70-421e-b07b-055c38b6d77c" },
         new UserRole { RoleId = "401bc2e9-3a0b-4281-9685-d6b36fc37d31", UserId = "4ff7819d-8e17-4aa8-a0da-964c2db21591" },
         new UserRole { RoleId = "401bc2e9-3a0b-4281-9685-d6b36fc37d31", UserId = "92db214d-cd73-4fbc-8b34-1dc0709ba0b2" },
         new UserRole { RoleId = "401bc2e9-3a0b-4281-9685-d6b36fc37d31", UserId = "9c57fadd-110a-4b45-aa89-69aa141564c6" },
         new UserRole { RoleId = "401bc2e9-3a0b-4281-9685-d6b36fc37d31", UserId = "eb6a85b0-a7fb-4f8e-9bea-03825e6f020f" },
         new UserRole { RoleId = "68373a2b-932e-4fff-a7a9-b31e156d4101", UserId = "11fafeb4-c7c1-463c-bb1e-55203e68dfdf" },
         new UserRole { RoleId = "401bc2e9-3a0b-4281-9685-d6b36fc37d31", UserId = "92b7c777-0d3e-4026-844f-20164bb0f97e" }
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