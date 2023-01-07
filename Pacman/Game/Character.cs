using OpenTK.Mathematics;

public class Character : IGameComponent
{
    public readonly Transform Transform;
    [EditorField] private readonly float _speed = 2f;
    private readonly IPathFindingAlgorithm _pathFinding = new AStarAlgorithm();
    private readonly Cherry _cherry;
    private readonly Map _map;
    private List<Vector2i> _path = new();
    [EditorField] private int _currentWayPoint;
    
    public Character(Cherry cherry, Map map, Transform transform)
    {
        Transform = transform;
        _cherry = cherry;
        _map = map;
    }

    private bool IsChasing => _currentWayPoint < _path.Count;
    private Vector3 Target => _path[_currentWayPoint].ToVector3();
    
    public void CalculatePath()
    {
        List<Vector2i> obstacles = _map.Obstacles;
        Vector2i from = Transform.Position.ToVector2I();
        Vector2i to = _cherry.Transform.Position.ToVector2I();
        
        _path = _pathFinding.Execute(from, to, obstacles);
        _currentWayPoint = 0;
    }
    
    void IGameComponent.Update(float deltaTime)
    {
        if (IsChasing)
        {
            MoveThePath(deltaTime);
            //RotateToTarget();
        }
    }

    private void MoveThePath(float deltaTime)
    {
        Transform.Position.MoveTowards(Target, _speed * deltaTime);

        if (Vector3.Distance(Transform.Position, Target) <= 0.001f)
        {
            _currentWayPoint++;
        }
    }

    private void RotateToTarget()
    {
        Vector3 direction = Target - Transform.Position;
        Matrix4.LookAt(Vector3.UnitX, direction, Vector3.UnitZ);
        Transform.Rotation = Quaternion.FromEulerAngles(0, 0, direction.Z);
    }
}