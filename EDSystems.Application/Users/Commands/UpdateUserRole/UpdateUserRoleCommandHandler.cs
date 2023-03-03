using EDSystems.Application.Common.Exceptions;
using EDSystems.Domain.Entities.UserEntities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.Users.Commands.UpdateUserRole;

public class UpdateUserRoleCommandHandler : IRequestHandler<UpdateUserRoleCommand, Unit>
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;

    public UpdateUserRoleCommandHandler(UserManager<User> userManager, RoleManager<Role> roleManager) => (_userManager, _roleManager) = (userManager, roleManager);

    public async Task<Unit> Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _userManager.FindByIdAsync(request.UserId);

        if (entity == null)
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }
        await _userManager.RemoveFromRoleAsync(entity, _roleManager.FindByIdAsync(request.OldRoleId).Result.Name);
        await _userManager.AddToRoleAsync(entity, _roleManager.FindByIdAsync(request.NewRoleId).Result.Name);
        return Unit.Value;
    }
}