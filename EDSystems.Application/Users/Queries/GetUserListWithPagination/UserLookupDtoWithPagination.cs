using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Domain.Entities.UserEntities;
using System;
using System.Collections.Generic;

namespace EDSystems.Application.Users.Queries.GetUserListWithPagination;

public class UserLookupDtoWithPagination : IMapWith<User>
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public virtual ICollection<UserRole> UserRoles { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<User, UserLookupDtoWithPagination>()
            .ForMember(userDto => userDto.Id, opt => opt.MapFrom(customer => customer.Id))
            .ForMember(userDto => userDto.FirstName, opt => opt.MapFrom(customer => customer.FirstName))
            .ForMember(userDto => userDto.LastName, opt => opt.MapFrom(customer => customer.LastName))
            .ForMember(userDto => userDto.Address, opt => opt.MapFrom(customer => customer.Address))
            .ForMember(userDto => userDto.Phone, opt => opt.MapFrom(customer => customer.PhoneNumber))
            .ForMember(userDto => userDto.UserRoles, opt => opt.MapFrom(customer => customer.UserRoles))
            .ForMember(userDto => userDto.DateCreated, opt => opt.MapFrom(customer => customer.DateCreated))
            .ForMember(userDto => userDto.DateUpdated, opt => opt.MapFrom(customer => customer.DateUpdated));
    }
}