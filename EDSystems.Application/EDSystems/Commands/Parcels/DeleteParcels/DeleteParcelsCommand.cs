﻿using MediatR;
using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Commands.Parcels.DeleteParcels;

public class DeleteParcelsCommand : IRequest<Unit>
{
    public IEnumerable<int> Id { get; set; }
}