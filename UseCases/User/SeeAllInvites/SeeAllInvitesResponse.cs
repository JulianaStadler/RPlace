using RPlace.Models;

namespace RPlace.UseCases.User.SeeAllInvites;

public record SeeAllInvitesResponse(
    IEnumerable<Invite> Invites
);
