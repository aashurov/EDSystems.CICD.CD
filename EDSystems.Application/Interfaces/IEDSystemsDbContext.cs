using EDSystems.Domain.Entities;
using EDSystems.Domain.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.Interfaces;

public interface IEDSystemsDbContext
{
    DbSet<Branch> Branch { get; set; }
    DbSet<ParcelBranch> ParcelBranch { get; set; }
    DbSet<ParcelCost> ParcelCost { get; set; }
    DbSet<ParcelDescription> ParcelDescription { get; set; }
    DbSet<ParcelImage> ParcelImage { get; set; }
    DbSet<ParcelSound> ParcelSound { get; set; }
    DbSet<Parcel> Parcel { get; set; }
    DbSet<Account> Account { get; set; }
    DbSet<AccountHistory> AccountHistory { get; set; }
    DbSet<UserAccount> UserAccount { get; set; }
    DbSet<UserAccountHistory> UserAccountHistory { get; set; }
    DbSet<Expenses> Expenses { get; set; }
    DbSet<ExpenseType> ExpenseType { get; set; }
    DbSet<ParcelOwners> ParcelOwners { get; set; }
    DbSet<ParcelPlan> ParcelPlan { get; set; }
    DbSet<ParcelSize> ParcelSize { get; set; }
    DbSet<ParcelStatus> ParcelStatus { get; set; }
    DbSet<ParcelJob> ParcelJob { get; set; }
    DbSet<RefreshToken> RefreshToken { get; set; }
    DbSet<Plan> Plan { get; set; }
    DbSet<Status> Status { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}