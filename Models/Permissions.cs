namespace RPlace.Models;

public class Permissions
{
    public Guid Id {get; set;}
    public bool Type {get; set;}
    public bool Invite {get; set;}
    public bool Remove {get; set;}
    public bool Promote {get; set;}
    public bool Paint {get; set;}
    public bool Watch {get; set;}
}