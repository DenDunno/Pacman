﻿using OpenTK.Mathematics;

public class MazeView
{
    private readonly ObstacleSpawner _obstacleSpawner;
    private readonly HashSet<Vector2i> _obstacles;
    private readonly RenderData _cachedRenderData;
    private GameObject _view = null!;

    public MazeView(Transform parent, HashSet<Vector2i> obstacles)
    {
        _obstacles = obstacles;
        _obstacleSpawner = new ObstacleSpawner();
        _cachedRenderData = new RenderData()
        {
            Material = new UnlitMaterial(new LitMaterialData()),
            Transform = parent
        };
    }

    public void Instantiate()
    {
        _view = new GameObject(new GameObjectData("Maze view", _cachedRenderData.Transform));
        WorldBrowser.Instance.Add(_view);
    }

    public void Regenerate()
    {
        _cachedRenderData.Mesh = GetMazeMesh();
        _view.Data.Model.Dispose();
        _view.Data.Model = new Model(_cachedRenderData);
        _view.Data.Model.Initialize();
    }
    
    private Mesh GetMazeMesh()
    {
        MeshData[] meshData = new MeshData[_obstacles.Count];
        
        int index = 0;
        foreach (Vector2i obstacle in _obstacles)
        {
            meshData[index] = _obstacleSpawner.Create(obstacle, GetNeighbours(obstacle));
            ++index;
        }

        return MeshBuilder.BuildMesh(StaticBatching.Concatenate(meshData));
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