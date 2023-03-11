using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Domain.Entities.UserEntities;
using EDSystems.Domain.IdentityUserEntities;
using System;
using System.Collections.Generic;

namespace EDSystems.Application.Users.Queries.GetUserDetails;

public class UserDetailsVm : IMapWith<User>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public virtual ICollection<UserRole> UserRoles { get; set; }
    public virtual ICollection<UserClaim> UserClaim { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<User, UserDetailsVm>()
            .ForMember(userVm => userVm.Id, opt => opt.MapFrom(customer => customer.Id))
            .ForMember(userVm => userVm.FirstName, opt => opt.MapFrom(customer => customer.FirstName))
            .ForMember(userVm => userVm.LastName, opt => opt.MapFrom(customer => customer.LastName))
            .ForMember(userVm => userVm.UserName, opt => opt.MapFrom(customer => customer.UserName))
            .ForMember(userVm => userVm.Address, opt => opt.MapFrom(customer => customer.Address))
            .ForMember(userVm => userVm.PhoneNumber, opt => opt.MapFrom(customer => customer.PhoneNumber))
            .ForMember(userVm => userVm.Email, opt => opt.MapFrom(customer => customer.Email))
            .ForMember(userVm => userVm.UserRoles, opt => opt.MapFrom(customer => customer.UserRoles))
            .ForMember(userVm => userVm.UserClaim, opt => opt.MapFrom(customer => customer.UserClaim))
            .ForMember(userVm => userVm.DateCreated, opt => opt.MapFrom(customer => customer.DateCreated))
            .ForMember(userVm => userVm.DateUpdated, opt => opt.MapFrom(customer => customer.DateUpdated));
    }
}