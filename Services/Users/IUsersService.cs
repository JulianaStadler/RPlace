using RPlace.Models;

namespace RPlace.Services.Users;

public interface IUsersService
{
    Task<Player> FindByLogin(string login);
    Task<Guid> Create(Player player);
}