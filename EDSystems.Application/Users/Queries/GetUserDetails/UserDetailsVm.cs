using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Domain.Entities.UserEntities;
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
    public virtual ICollection<UserRole> UserRoles { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<User, UserDetailsVm>()
            .ForMember(userVm => userVm.Id, opt => opt.MapFrom(customer => customer.Id))
            .ForMember(userVm => userVm.FirstName, opt => opt.MapFrom(customer => customer.FirstName))
            .ForMember(userVm => userVm.LastName, opt => opt.MapFrom(customer => customer.LastName))
            .ForMember(userVm => userVm.Address, opt => opt.MapFrom(customer => customer.Address))
            .ForMember(userVm => userVm.PhoneNumber, opt => opt.MapFrom(customer => customer.PhoneNumber))
            .ForMember(userVm => userVm.UserRoles, opt => opt.MapFrom(customer => customer.UserRoles))
            .ForMember(userVm => userVm.DateCreated, opt => opt.MapFrom(customer => customer.DateCreated))
            .ForMember(userVm => userVm.DateUpdated, opt => opt.MapFrom(customer => customer.DateUpdated));
    }
}