using MediatR;
using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Commands.Parcels.UpdateParcelsStatusById
{
    public class UpdateParcelsStatusByIdCommand : IRequest
    {
        public ICollection<int> ParcelId { get; set; }
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
    }
}