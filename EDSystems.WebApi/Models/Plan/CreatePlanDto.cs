using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.EDSystems.Commands.Plans.CreatePlan;
using System.ComponentModel.DataAnnotations;

namespace EDSystems.WebApi.Models.Plan;

/// <summary>
///
/// </summary>
public class CreatePlanDto : IMapWith<CreatePlanCommand>
{
    /// <summary>
    ///
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    ///
    /// </summary>
    public decimal Cost { get; set; }

    /// <summary>
    ///
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    ///
    /// </summary>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreatePlanDto, CreatePlanCommand>()
            .ForMember(createPlanCommand => createPlanCommand.Name,
                options => options.MapFrom(createPlanDto => createPlanDto.Name))
            .ForMember(createPlanCommand => createPlanCommand.Cost,
                options => options.MapFrom(createPlanDto => createPlanDto.Cost))
            .ForMember(createPlanCommand => createPlanCommand.Description,
                options => options.MapFrom(createPlanDto => createPlanDto.Description));
    }
}