using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.EDSystems.Commands.Plans.DeletePlans;
using System.ComponentModel.DataAnnotations;

namespace EDSystems.WebApi.Models.Plan;

/// <summary>
///
/// </summary>
public class DeletePlansDto : IMapWith<DeletePlansCommand>
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
        profile.CreateMap<DeletePlansDto, DeletePlansCommand>()
            .ForMember(deletePlansCommand => deletePlansCommand.Id,
                options => options.MapFrom(deletePlansDto => deletePlansDto.Id));
    }
}