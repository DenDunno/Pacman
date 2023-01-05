namespace Pacman;

public class LevelGeneration : IGameComponent
{
    private readonly Map _map;
    private readonly Character _character;
    private readonly Cherry _cherry;

    public LevelGeneration(Map map, Character character, Cherry cherry)
    {
        _map = map;
        _character = character;
        _cherry = cherry;
    }

    [EditorButton]
    private void Generate()
    {
        
    }
}