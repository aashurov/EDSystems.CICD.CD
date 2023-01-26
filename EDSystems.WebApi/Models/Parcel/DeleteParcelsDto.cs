using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.EDSystems.Commands.Parcels.DeleteParcels;
using System.ComponentModel.DataAnnotations;

namespace EDSystems.WebApi.Models.Parcel;

/// <summary>
///
/// </summary>
public class DeleteParcelsDto : IMapWith<DeleteParcelsCommand>
{
    /// <summary>
    ///
    /// </summary>
    [Required]
    public IEnumerable<int> Id { get; set; }

    /// <summary>
    ///
    /// </summary>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<DeleteParcelsDto, DeleteParcelsCommand>()
            .ForMember(deleteParcelsCommand => deleteParcelsCommand.Id,
                options => options.MapFrom(deleteParcelsDto => deleteParcelsDto.Id));
    }
}