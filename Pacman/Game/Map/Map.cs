using OpenTK.Mathematics;

public class Map : IGameComponent
{
    public readonly HashSet<Vector2i> FreeCells = new();
    private readonly List<Vector2i> _obstacles = new();
    private readonly List<GameObject> _obstaclesView = new();
    private readonly ObstacleSpawner _obstacleSpawner;
    private readonly MapGeneration _mapGeneration;
    
    public Map(Transform transform)
    {
        _obstacleSpawner = new ObstacleSpawner(transform);
        _mapGeneration = new MapGeneration(_obstacles, FreeCells);
    }
    
    void IGameComponent.Initialize()
    {
        _obstacleSpawner.Initialize();
    }

    public void Generate(int rows, int columns)
    {
        Release();
        _mapGeneration.Evaluate(rows, columns);
        SpawnObstacles();
    }

    private void Release()
    {
        FreeCells.Clear();
        _obstacles.Clear();

        foreach (GameObject obstacle in _obstaclesView)
        {
            WorldBrowser.Instance.Destroy(obstacle);
        }
        
        _obstaclesView.Clear();
    }

    private void SpawnObstacles()
    {
        foreach (Vector2i position in _obstacles)
        {
            GameObject obstacle = _obstacleSpawner.Create(position);
            WorldBrowser.Instance.Add(obstacle);
            _obstaclesView.Add(obstacle);
        }
    }
}