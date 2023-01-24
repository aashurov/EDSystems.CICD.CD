using EDSystems.Application.Common.Exceptions;
using EDSystems.Domain.Entities.UserEntities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.Users.Commands.UpdatePassword;

public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommand>
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;

    public UpdatePasswordCommandHandler(UserManager<User> userManager, RoleManager<Role> roleManager) => (_userManager, _roleManager) = (userManager, roleManager);

    public async Task<Unit> Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
    {
        var entity = await _userManager.FindByIdAsync(request.UserId);

        if (entity == null)
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }

        //var token = await UserManager.GeneratePasswordResetTokenAsync(entity);
        //await UserManager.ResetPasswordAsync(user, token, request.PasswordHash);

        entity.PasswordHash = _userManager.PasswordHasher.HashPassword(entity, request.PasswordHash);
        await _userManager.UpdateAsync(entity);
        return Unit.Value;
    }
}

//public async Task<IHttpActionResult> changePassword(UsercredentialsModel usermodel)
//    {
//        ApplicationUser user = await AppUserManager.FindByIdAsync(usermodel.Id);
//        if (user == null)
//        {
//            return NotFound();
//        }
//        user.PasswordHash = AppUserManager.PasswordHasher.HashPassword(usermodel.Password);
//        var result = await AppUserManager.UpdateAsync(user);
//        if (!result.Succeeded)
//        {
//            //throw exception......
//        }
//        return Ok();
//    }