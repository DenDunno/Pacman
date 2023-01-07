using OpenTK.Mathematics;

public interface IPathFindingAlgorithm
{
    List<Vector2i> Execute(Vector2i from, Vector2i to, List<Vector2i> obstacles);
}