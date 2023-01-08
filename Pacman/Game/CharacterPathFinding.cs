using OpenTK.Mathematics;

public class CharacterPathFinding 
{
    private readonly IPathFindingAlgorithm _pathFinding = new AStarAlgorithm();
    private readonly List<Vector2i> _obstacles;
    private readonly Transform _character;
    private readonly Transform _cherry;

    public CharacterPathFinding(Transform character, Transform cherry, List<Vector2i> obstacles)
    {
        _obstacles = obstacles;
        _character = character;
        _cherry = cherry;
    }

    public List<Vector2i> Evaluate()
    {
        Vector2i from = _character.Position.ToVector2I();
        Vector2i to = _cherry.Position.ToVector2I();
        
        return _pathFinding.Execute(from, to, _obstacles);
    }
}