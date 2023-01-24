using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.EDSystems.Commands.Branches.DeleteBranches;
using System.ComponentModel.DataAnnotations;

namespace EDSystems.WebApi.Models.Branches;

/// <summary>
///
/// </summary>
public class DeleteBranchesDto : IMapWith<DeleteBranchesCommand>
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
        profile.CreateMap<DeleteBranchesDto, DeleteBranchesCommand>()
            .ForMember(deleteBranchesCommand => deleteBranchesCommand.Id,
                options => options.MapFrom(deleteBranchesDto => deleteBranchesDto.Id));
    }
}