namespace Pacman;

public class LevelGeneration : IGameComponent
{
    private readonly Map _map;
    private readonly Character _character;
    private readonly Target _target;

    public LevelGeneration(Map map, Character character, Target target)
    {
        _map = map;
        _character = character;
        _target = target;
    }
}