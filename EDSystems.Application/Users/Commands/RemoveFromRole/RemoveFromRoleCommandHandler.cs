using EDSystems.Application.Common.Exceptions;
using EDSystems.Domain.Entities.UserEntities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.Users.Commands.DeleteFromRole;

public class DeleteFromRoleCommandHandler : IRequestHandler<DeleteFromRoleCommand, Unit>
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;

    public DeleteFromRoleCommandHandler(UserManager<User> userManager, RoleManager<Role> roleManager) => (_userManager, _roleManager) = (userManager, roleManager);

    public async Task<Unit> Handle(DeleteFromRoleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _userManager.FindByIdAsync(request.UserId);

        if (entity == null)
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }

        var entityRole = await _roleManager.FindByIdAsync(request.RoleId);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Role), request.RoleId);
        }

        await _userManager.RemoveFromRoleAsync(entity, _roleManager.FindByIdAsync(request.RoleId).Result.Name);
        return Unit.Value;
    }
}