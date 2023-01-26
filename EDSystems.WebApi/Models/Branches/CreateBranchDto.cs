using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.EDSystems.Commands.Branches.CreateBranch;
using System.ComponentModel.DataAnnotations;

namespace EDSystems.WebApi.Models.Branches;

/// <summary>
///
/// </summary>
public class CreateBranchDto : IMapWith<CreateBranchCommand>
{
    /// <summary>
    ///
    /// </summary>
    [Required]
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
        profile.CreateMap<CreateBranchDto, CreateBranchCommand>()
            .ForMember(createBranchCommand => createBranchCommand.Name,
                options => options.MapFrom(createBranchDto => createBranchDto.Name))
            .ForMember(createBranchCommand => createBranchCommand.Country,
                options => options.MapFrom(createBranchDto => createBranchDto.Country))
            .ForMember(createBranchCommand => createBranchCommand.Code,
                options => options.MapFrom(createBranchDto => createBranchDto.Code))
        .ForMember(createBranchCommand => createBranchCommand.City,
                options => options.MapFrom(createBranchDto => createBranchDto.City))
        .ForMember(createBranchCommand => createBranchCommand.Address,
                options => options.MapFrom(createBranchDto => createBranchDto.Address))
        .ForMember(createBranchCommand => createBranchCommand.Email,
                options => options.MapFrom(createBranchDto => createBranchDto.Email))
        .ForMember(createBranchCommand => createBranchCommand.Phone,
                options => options.MapFrom(createBranchDto => createBranchDto.Phone));
    }
}