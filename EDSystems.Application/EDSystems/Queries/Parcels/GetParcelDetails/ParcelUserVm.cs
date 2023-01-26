using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Domain.Entities.UserEntities;

namespace EDSystems.Application.EDSystems.Queries.Parcels.GetParcelDetails;

public class ParcelUserVm : IMapWith<User>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<User, ParcelUserVm>()
            .ForMember(parcelUserVm => parcelUserVm.FirstName, opt => opt.MapFrom(parcel => parcel.FirstName))
            .ForMember(parcelUserVm => parcelUserVm.LastName, opt => opt.MapFrom(parcel => parcel.LastName))
            .ForMember(parcelUserVm => parcelUserVm.Address, opt => opt.MapFrom(parcel => parcel.Address))
            .ForMember(parcelUserVm => parcelUserVm.PhoneNumber, opt => opt.MapFrom(parcel => parcel.PhoneNumber));
    }
}