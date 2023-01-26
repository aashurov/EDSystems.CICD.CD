using EDSystems.Application.Common.Exceptions;
using EDSystems.Domain.Entities.UserEntities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.Users.Commands.AddToRole;

public class AddToRoleCommandHandler : IRequestHandler<AddToRoleCommand, string>
{
    private readonly UserManager<User> _userManager;

    private readonly RoleManager<Role> _roleManager;

    public AddToRoleCommandHandler(UserManager<User> userManager, RoleManager<Role> roleManager) => (_userManager, _roleManager) = (userManager, roleManager);

    public async Task<string> Handle(AddToRoleCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.UserId);
        var role = await _roleManager.FindByIdAsync(request.RoleId);

        if (user == null)
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }

        if (role == null)
        {
            throw new NotFoundException(nameof(Role), request.RoleId);
        }

        await _userManager.AddToRoleAsync(user, role.Name);
        return user.Id;
    }
}