using OpenTK.Mathematics;

public class AStarAlgorithm : IPathFindingAlgorithm
{
    public List<Vector2i> Execute(Vector2i from, Vector2i to, List<Vector2i> obstacles)
    {
        return new List<Vector2i>()
        {
            from,
            new(1, 1),
            new(-1, 2),
            to
        };
    }
}