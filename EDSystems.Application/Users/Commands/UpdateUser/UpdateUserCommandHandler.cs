using EDSystems.Application.Common.Exceptions;
using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities.UserEntities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    private readonly UserManager<User> _userManager;

    private readonly IDateTimeService _dateTimeService;

    public UpdateUserCommandHandler(UserManager<User> userManager, IDateTimeService dateTimeService) => (_userManager, _dateTimeService) = (userManager, dateTimeService);

    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await _userManager.FindByIdAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(User), request.Id);
        }

        entity.FirstName = request.FirstName;
        entity.LastName = request.LastName;
        entity.Address = request.Address;
        entity.Email = request.Email;
        entity.PhoneNumber = request.PhoneNumber;
        entity.DateUpdated = _dateTimeService.Now;
        entity.SecurityStamp = Guid.NewGuid().ToString("D");
        entity.ConcurrencyStamp = Guid.NewGuid().ToString("D");

        var tt = await _userManager.UpdateAsync(entity);
        if (tt.Succeeded == false)
        {
            System.Console.WriteLine("salom");
        }
        return Unit.Value;
    }
}