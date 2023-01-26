using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.EDSystems.Commands.Branches.UpdateBranch;

namespace EDSystems.WebApi.Models.Branches;

/// <summary>
///
/// </summary>
public class UpdateBranchDto : IMapWith<UpdateBranchCommand>
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
    public string Country { get; set; }

    /// <summary>
    ///
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    ///
    /// </summary>
    public string City { get; set; }

    /// <summary>
    ///
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    ///
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    ///
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    ///
    /// </summary>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateBranchDto, UpdateBranchCommand>()
            .ForMember(updateBranchCommand => updateBranchCommand.Id,
                options => options.MapFrom(updateBranchDto => updateBranchDto.Id))
            .ForMember(updateBranchCommand => updateBranchCommand.Name,
                options => options.MapFrom(updateBranchDto => updateBranchDto.Name))
            .ForMember(updateBranchCommand => updateBranchCommand.Country,
                options => options.MapFrom(updateBranchDto => updateBranchDto.Country))
            .ForMember(updateBranchCommand => updateBranchCommand.Code,
                options => options.MapFrom(updateBranchDto => updateBranchDto.Code))
        .ForMember(updateBranchCommand => updateBranchCommand.City,
                options => options.MapFrom(updateBranchDto => updateBranchDto.City))
        .ForMember(updateBranchCommand => updateBranchCommand.Address,
                options => options.MapFrom(updateBranchDto => updateBranchDto.Address))
        .ForMember(updateBranchCommand => updateBranchCommand.Email,
                options => options.MapFrom(updateBranchDto => updateBranchDto.Email))
        .ForMember(updateBranchCommand => updateBranchCommand.Phone,
                options => options.MapFrom(updateBranchDto => updateBranchDto.Phone));
    }
}