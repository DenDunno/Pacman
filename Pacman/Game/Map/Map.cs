using OpenTK.Mathematics;

public class Map : IGameComponent
{
    public readonly HashSet<Vector2i> FreeCells = new();
    private readonly HashSet<Vector2i> _obstacles = new();
    private readonly List<GameObject> _obstaclesView = new();
    private readonly ObstacleSpawner _obstacleSpawner;
    private readonly MapGeneration _mapGeneration;

    public Map(Transform transform)
    {
        _obstacleSpawner = new ObstacleSpawner(transform);
        _mapGeneration = new MapGeneration(_obstacles, FreeCells);
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
        foreach (Vector2i obstacle in _obstacles)
        {
            GameObject view = _obstacleSpawner.Create(obstacle, GetNeighbours(obstacle));
            WorldBrowser.Instance.Add(view);
            _obstaclesView.Add(view);
        }
    }

    private TileNeighbours GetNeighbours(Vector2i tile)
    {
        return new TileNeighbours()
        {
            Top = _obstacles.Contains(new Vector2i(tile.X, tile.Y + 1)),
            Left = _obstacles.Contains(new Vector2i(tile.X - 1, tile.Y)),
            Right = _obstacles.Contains(new Vector2i(tile.X + 1, tile.Y)),
            Bottom = _obstacles.Contains(new Vector2i(tile.X, tile.Y - 1)),
            
            TopLeft = _obstacles.Contains(new Vector2i(tile.X - 1, tile.Y + 1)),
            TopRight = _obstacles.Contains(new Vector2i(tile.X + 1, tile.Y + 1)),
            BottomLeft = _obstacles.Contains(new Vector2i(tile.X - 1, tile.Y - 1)),
            BottomRight = _obstacles.Contains(new Vector2i(tile.X + 1, tile.Y - 1))
        };
    }
}