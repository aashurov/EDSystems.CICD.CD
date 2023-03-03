﻿using MediatR;

namespace EDSystems.Application.EDSystems.Commands.Parcels.DeleteParcel;

public class DeleteParcelCommand : IRequest<Unit>
{
    public int Id { get; set; }
}