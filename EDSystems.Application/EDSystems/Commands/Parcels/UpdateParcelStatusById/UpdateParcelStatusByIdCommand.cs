using MediatR;

namespace EDSystems.Application.EDSystems.Commands.Parcels.UpdateParcelStatusById;

public class UpdateParcelStatusByIdCommand : IRequest<Unit>
{
    public int ParcelId { get; set; }
    public int StatusId { get; set; }
    public int ParcelStatusId { get; set; }

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