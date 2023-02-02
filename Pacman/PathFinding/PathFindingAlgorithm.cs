using OpenTK.Mathematics;

public abstract class PathFindingAlgorithm
{
    protected readonly HashSet<Vector2i> FreeCells;
    private readonly Transform _transform;
    private readonly Transform _target;

    protected PathFindingAlgorithm(Transform transform, Transform target, HashSet<Vector2i> freeCells)
    {
        _transform = transform;
        _target = target;
        FreeCells = freeCells;
    }

    protected Vector2i Target => _target.Position.ToVector2I();
    protected Vector2i Start => _transform.Position.ToVector2I();

    public abstract List<Vector2i> Execute();
}