using MediatR;

namespace EDSystems.Application.EDSystems.Commands.Parcels.DeleteParcelStatus;

public class DeleteParcelStatusCommand : IRequest
{
    /// <summary>
    ///
    /// </summary>
    public int ParcelStatusId { get; set; }

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
    public int ParcelId { get; set; }
}