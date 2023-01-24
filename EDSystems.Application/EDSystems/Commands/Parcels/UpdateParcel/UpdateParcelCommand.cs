using EDSystems.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Commands.Parcels.UpdateParcel;

public class UpdateParcelCommand : IRequest
{
    public int Id { get; set; }
    public virtual ParcelCost ParcelCost { get; set; }
    public string SenderId { get; set; }
    public string RecepientId { get; set; }
    public string RecepientStaffId { get; set; }
    public string SenderStaffId { get; set; }
    public string RecepientCourierId { get; set; }
    public string SenderCourierId { get; set; }
    public int ParcelPlanId { get; set; }
    public int ParcelBranchFromId { get; set; }
    public int ParcelBranchToId { get; set; }
    public virtual ParcelSize ParcelSize { get; set; }
    public int ParcelStatusId { get; set; }
    public virtual ICollection<ParcelImage> ParcelImage { get; set; }
    public virtual ICollection<ParcelSound> ParcelSound { get; set; }
    public virtual ParcelDescription ParcelDescription { get; set; }
    public DateTime DateUpdated { get; set; } = DateTime.Now;
}