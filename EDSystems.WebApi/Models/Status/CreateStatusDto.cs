using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.EDSystems.Commands.Statuses.CreateStatus;
using System.ComponentModel.DataAnnotations;

namespace EDSystems.WebApi.Models.Status;

/// <summary>
///
/// </summary>
public class CreateStatusDto : IMapWith<CreateStatusCommand>
{
    /// <summary>
    ///
    /// </summary>
    [Required]
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
        profile.CreateMap<CreateStatusDto, CreateStatusCommand>()
            .ForMember(createStatusCommand => createStatusCommand.Name,
                options => options.MapFrom(createStatusDto => createStatusDto.Name))
            .ForMember(createStatusCommand => createStatusCommand.Description,
                options => options.MapFrom(createStatusDto => createStatusDto.Description));
    }
}