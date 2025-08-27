using RPlace.Models;
using RPlace.UseCases.User.EditAccount;

namespace RPlace.Services.Users;

public interface IUsersService
{
    Task<Player> FindByLogin(string login);
    Task<Guid> Create(Player player);
    Task<Player> Alter(EditAccountPayload payload);

}