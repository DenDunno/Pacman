using OpenTK.Mathematics;

public class Ghost : IGameComponent
{
    public readonly Transform Transform;
    private readonly PathFindingAlgorithm _pathFindingAlgorithm;
    [EditorField] private readonly float _speed = 2f;

    public Ghost(Transform transform, PathFindingAlgorithm pathFindingAlgorithm)
    {
        _pathFindingAlgorithm = pathFindingAlgorithm;
        Transform = transform;
    }

    void IGameComponent.Update(float deltaTime)
    {
        List<Vector2i> path = _pathFindingAlgorithm.Execute();

        if (path.Count > 1)
        {
            Transform.Position.MoveTowards2D(path[1].ToVector3(), _speed * deltaTime);    
        }
    }
}