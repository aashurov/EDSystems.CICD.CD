﻿using MediatR;
using System.Collections.Generic;

namespace EDSystems.Application.EDSystems.Commands.Parcels.AddParcelImages;

public class AddParcelImagesCommand : IRequest
{
    public int ParcelId { get; set; }
    public IEnumerable<string> ImageBytes { get; set; }
}