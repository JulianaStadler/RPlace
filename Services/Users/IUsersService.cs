using RPlace.Models;
using RPlace.UseCases.User.EditAccount;
using RPlace.Services.Password;

namespace RPlace.Services.Users;

public interface IUsersService
{
    Task<Player> FindByLogin(string login);
    Task<Guid> Create(Player player);
    Task<Player> Alter(EditAccountPayload payload, IUsersService usersService, IPasswordService passwordService);
}