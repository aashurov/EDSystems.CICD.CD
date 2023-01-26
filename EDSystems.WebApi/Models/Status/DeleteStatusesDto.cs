using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.EDSystems.Commands.Statuses.DeleteStatuses;
using System.ComponentModel.DataAnnotations;

namespace EDSystems.WebApi.Models.Status;

/// <summary>
///
/// </summary>
public class DeleteStatusesDto : IMapWith<DeleteStatusesCommand>
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
        profile.CreateMap<DeleteStatusesDto, DeleteStatusesCommand>()
            .ForMember(deleteStatusesCommand => deleteStatusesCommand.Id,
                options => options.MapFrom(updateStatusDto => updateStatusDto.Id));
    }
}