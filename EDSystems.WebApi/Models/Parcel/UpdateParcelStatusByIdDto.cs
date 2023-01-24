using AutoMapper;
using EDSystems.Application.EDSystems.Commands.Parcels.UpdateParcelStatusById;
using MediatR;

namespace EDSystems.WebApi.Models.Parcel
{
    /// <summary>
    ///
    /// </summary>
    public class UpdateParcelStatusByIdDto : IRequest
    {
        /// <summary>
        ///
        /// </summary>
        public int ParcelId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string SenderId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string RecepientId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string RecepientStaffId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string SenderStaffId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string RecepientCourierId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string SenderCourierId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateParcelStatusByIdDto, UpdateParcelStatusByIdCommand>()
                .ForMember(updateParcelStatusByIdCommand => updateParcelStatusByIdCommand.StatusId,
                    options => options.MapFrom(updateParcelStatusByIdDto => updateParcelStatusByIdDto.StatusId))
                .ForMember(updateParcelStatusByIdCommand => updateParcelStatusByIdCommand.SenderId,
                    options => options.MapFrom(updateParcelStatusByIdDto => updateParcelStatusByIdDto.SenderId))
            .ForMember(updateParcelStatusByIdCommand => updateParcelStatusByIdCommand.RecepientId,
                    options => options.MapFrom(updateParcelStatusByIdDto => updateParcelStatusByIdDto.RecepientId))
            .ForMember(updateParcelStatusByIdCommand => updateParcelStatusByIdCommand.RecepientStaffId,
                    options => options.MapFrom(updateParcelStatusByIdDto => updateParcelStatusByIdDto.RecepientStaffId))
             .ForMember(updateParcelStatusByIdCommand => updateParcelStatusByIdCommand.SenderStaffId,
                    options => options.MapFrom(updateParcelStatusByIdDto => updateParcelStatusByIdDto.SenderStaffId))
             .ForMember(updateParcelStatusByIdCommand => updateParcelStatusByIdCommand.RecepientCourierId,
                    options => options.MapFrom(updateParcelStatusByIdDto => updateParcelStatusByIdDto.RecepientCourierId))
             .ForMember(updateParcelStatusByIdCommand => updateParcelStatusByIdCommand.SenderCourierId,
                    options => options.MapFrom(updateParcelStatusByIdDto => updateParcelStatusByIdDto.SenderCourierId))
             .ForMember(updateParcelStatusByIdCommand => updateParcelStatusByIdCommand.ParcelId,
                    options => options.MapFrom(updateParcelStatusByIdDto => updateParcelStatusByIdDto.ParcelId));
        }
    }
}