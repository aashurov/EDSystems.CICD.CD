using EDSystems.Domain.Entities;
using EDSystems.Domain.Entities.UserEntities;
using MediatR;
using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Commands.ParcelJobs.CreateParcelJob
{
    public class CreateParcelJobCommand : IRequest<int>
    {
        public decimal Cost { get; set; }
        public ICollection<User> Courier { get; set; }
        public string CourierId { get; set; }
        public string JobType { get; set; }
        public int ParcelId { get; set; }
        public Parcel Parcel { get; set; }

        //zabor dostavka
        public bool PaymentState { get; set; } = false; //Oplache Ne oplache kureru
    }
}