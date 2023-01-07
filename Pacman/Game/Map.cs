using OpenTK.Mathematics;

public class Map : IGameComponent
{
    public readonly List<Vector2i> Obstacles = new();
    private readonly List<Vector2i> _freeCells = new();
    private readonly List<GameObject> _obstaclesView = new();
    private readonly ObstacleSpawner _obstacleSpawner;

    public Map(Transform transform)
    {
        _obstacleSpawner = new ObstacleSpawner(transform);
    }
    
    void IGameComponent.Initialize()
    {
        _obstacleSpawner.Initialize();
    }
    
    public Vector2i GetRandomFreeCell()
    {
        int randomIndex = new Random().Next(0, _freeCells.Count);

        return _freeCells[randomIndex];
    }

    public void Generate(int rows, int columns)
    {
        Release();
        GenerateMap(rows, columns);
        SpawnObstacles();
    }

    private void Release()
    {
        _freeCells.Clear();
        Obstacles.Clear();

        foreach (GameObject obstacle in _obstaclesView)
        {
            obstacle.Dispose();
        }
        
        _obstaclesView.Clear();
    }

    private void GenerateMap(int rows, int columns)
    {
        for (int i = 0; i < rows; ++i)
        {
            for (int j = 0; j < columns; ++j)
            {
                List<Vector2i> container = (j + i) % 2 == 0 ? _freeCells : Obstacles;
                
                container.Add(new Vector2i(i, j));
            }
        }
    }

    private void SpawnObstacles()
    {
        foreach (Vector2i position in Obstacles)
        {
            GameObject obstacle = _obstacleSpawner.Create(position);
            WorldBrowser.Instance.Add(obstacle);
            _obstaclesView.Add(obstacle);
        }
    }
}