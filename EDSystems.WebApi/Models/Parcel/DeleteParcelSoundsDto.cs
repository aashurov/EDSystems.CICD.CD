using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.EDSystems.Commands.Parcels.DeleteParcelSounds;

namespace EDSystems.WebApi.Models.Parcel
{
    /// <summary>
    ///
    /// </summary>
    public class DeleteParcelSoundsDto : IMapWith<DeleteParcelSoundsCommand>
    {
        /// <summary>
        ///
        /// </summary>
        public int ParcelId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<int> ParcelSoundId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public void Mapping(Profile profile)
        {
            profile.CreateMap<DeleteParcelSoundsDto, DeleteParcelSoundsCommand>()
                .ForMember(deleteParcelSoundsCommand => deleteParcelSoundsCommand.ParcelId,
                    options => options.MapFrom(deleteParcelSoundsDto => deleteParcelSoundsDto.ParcelId))
                .ForMember(deleteParcelSoundsCommand => deleteParcelSoundsCommand.ParcelSoundId,
                    options => options.MapFrom(deleteParcelSoundsDto => deleteParcelSoundsDto.ParcelSoundId));
        }
    }
}