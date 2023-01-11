using OpenTK.Mathematics;

public interface IPathFindingAlgorithm
{
    List<Vector2i> Execute(Vector2i start, Vector2i target);
}