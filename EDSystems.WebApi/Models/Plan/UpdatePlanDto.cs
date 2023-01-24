using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.EDSystems.Commands.Plans.UpdatePlan;

namespace EDSystems.WebApi.Models.Plan;

/// <summary>
///
/// </summary>
public class UpdatePlanDto : IMapWith<UpdatePlanCommand>
{
    /// <summary>
    ///
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    ///
    /// </summary>
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
        profile.CreateMap<UpdatePlanDto, UpdatePlanCommand>()
            .ForMember(updatePlanCommand => updatePlanCommand.Id,
                options => options.MapFrom(updatePlanDto => updatePlanDto.Id))
            .ForMember(updatePlanCommand => updatePlanCommand.Name,
                options => options.MapFrom(updatePlanDto => updatePlanDto.Name))
            .ForMember(updatePlanCommand => updatePlanCommand.Cost,
                options => options.MapFrom(updatePlanDto => updatePlanDto.Cost))
                    .ForMember(updatePlanCommand => updatePlanCommand.Description,
                options => options.MapFrom(updatePlanDto => updatePlanDto.Description));
    }
}