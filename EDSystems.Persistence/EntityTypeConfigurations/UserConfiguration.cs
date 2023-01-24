using EDSystems.Domain.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDSystems.Persistence.EntityTypeConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        //builder.HasKey(applicationUser => applicationUser.Id);
        //builder.HasIndex(applicationUser => applicationUser.Id).IsUnique();
        builder.HasIndex(applicationUser => applicationUser.PhoneNumber).IsUnique();
        builder.HasMany(e => e.UserRoles).WithOne(e => e.User).HasForeignKey(e => e.UserId).IsRequired();

        //builder.HasOne(e => e.ParcelOwners).WithOne(e => e.Sender);//.HasForeignKey(e => e.SenderId).IsRequired();
        //builder.HasOne(e => e.ParcelOwners).WithOne(e => e.SenderStaff);//.HasForeignKey(e => e.SenderStaffId).IsRequired();
        //builder.HasOne(e => e.ParcelOwners).WithOne(e => e.SenderCourier);//.HasForeignKey(e => e.SenderCourierId).IsRequired();
        //builder.HasOne(e => e.ParcelOwners).WithOne(e => e.Recepient);//.HasForeignKey(e => e.RecepientId).IsRequired();
        //builder.HasOne(e => e.ParcelOwners).WithOne(e => e.RecepientStaff);//.HasForeignKey(e => e.RecepientStaffId).IsRequired();
        //builder.HasOne(e => e.ParcelOwners).WithOne(e => e.RecepientCourier);//.HasForeignKey(e => e.RecepientCourierId).IsRequired();

        //builder.HasMany(e => e.UserRoles).WithOne(e => e.User).HasForeignKey(ur => ur.UserId).IsRequired();
    }
}