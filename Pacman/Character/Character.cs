namespace Pacman;

public class Character : IGameComponent
{
    private readonly Target _target;

    public Character(Target target)
    {
        _target = target;
    }
}