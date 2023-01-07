using OpenTK.Mathematics;

public class Character : IGameComponent
{
    public readonly Transform Transform;
    [EditorField] private readonly float _speed = 2f;
    private readonly IPathFindingAlgorithm _pathFinding = new AStarAlgorithm();
    private readonly Cherry _cherry;
    private readonly Map _map;

    public Character(Cherry cherry, Map map, Transform transform)
    {
        Transform = transform;
        _cherry = cherry;
        _map = map;
    }

    public void CalculatePath()
    {
    }
    
    void IGameComponent.Update(float deltaTime)
    {
        MoveToTarget(deltaTime);
    }

    private void MoveToTarget(float deltaTime)
    {
        Vector3 target = new(_cherry.Transform.Position.X, _cherry.Transform.Position.Y, 0);

        if (target != Transform.Position)
        {
            Transform.Position += (target - Transform.Position).Normalized() * _speed * deltaTime;
        }
    }
}