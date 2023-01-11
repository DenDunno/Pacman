using OpenTK.Mathematics;

public class CharacterPathFinding 
{
    private readonly IPathFindingAlgorithm _pathFinding = new AStarAlgorithm();
    private readonly HashSet<Vector2i> _freeCells;
    private readonly Transform _character;
    private readonly Transform _cherry;

    public CharacterPathFinding(Transform character, Transform cherry, HashSet<Vector2i> freeCells)
    {
        _freeCells = freeCells;
        _character = character;
        _cherry = cherry;
    }

    public List<Vector2i> Evaluate()
    {
        Vector2i from = _character.Position.ToVector2I();
        Vector2i to = _cherry.Position.ToVector2I();
        
        return _pathFinding.Execute(from, to, _freeCells);
    }
}