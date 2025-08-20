using RPlace.Models;

namespace RPlace.Services.Players;

public interface IPlayerService
{
    Task<Player> FindByLogin(string login);
    Task<Guid> Create(Player player);
}