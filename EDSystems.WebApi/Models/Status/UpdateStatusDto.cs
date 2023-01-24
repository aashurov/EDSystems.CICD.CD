using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.EDSystems.Commands.Statuses.UpdateStatus;
using System.ComponentModel.DataAnnotations;

namespace EDSystems.WebApi.Models.Status;

/// <summary>
///
/// </summary>
public class UpdateStatusDto : IMapWith<UpdateStatusCommand>
{
    /// <summary>
    ///
    /// </summary>
    [Required]
    public int Id { get; set; }

    /// <summary>
    ///
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    ///
    /// </summary>

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateStatusDto, UpdateStatusCommand>()
            .ForMember(updateStatusCommand => updateStatusCommand.Id,
                options => options.MapFrom(updateStatusDto => updateStatusDto.Id))
            .ForMember(updateStatusCommand => updateStatusCommand.Name,
                options => options.MapFrom(updateStatusDto => updateStatusDto.Name))
            .ForMember(updateStatusCommand => updateStatusCommand.Description,
                options => options.MapFrom(updateStatusDto => updateStatusDto.Description));
    }
}