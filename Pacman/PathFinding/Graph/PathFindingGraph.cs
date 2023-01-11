using OpenTK.Mathematics;

public class PathFindingGraph
{
    private readonly Vector2i _from;
    private readonly Vector2i _target;
    private readonly List<Vector2i> _freeCells;

    public PathFindingGraph(Vector2i from, Vector2i target, List<Vector2i> freeCells)
    {
        _from = from;
        _target = target;
        _freeCells = freeCells;
    }

    public void Evaluate()
    {
        foreach (Vector2i freeCell in _freeCells)
        {
            
        }
    }
}