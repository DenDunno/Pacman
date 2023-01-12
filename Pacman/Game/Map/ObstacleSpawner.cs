using OpenTK.Mathematics;

public class ObstacleSpawner
{
    private readonly RenderData _cachedRenderData;
    private readonly Transform _parent;
    private readonly AutoTiling _autoTiling;
    private readonly Mesh _cachedMesh = MeshBuilder.Quad(1f);

    public ObstacleSpawner(Transform parent)
    {
        _parent = parent;
        
        _autoTiling = new AutoTiling(new Dictionary<int, Texture>()
        {
            {5, new Texture(Paths.GetTexture("Tiles/tile013.png"))},
            {68, new Texture(Paths.GetTexture("Tiles/tile002.png"))},
            {20, new Texture(Paths.GetTexture("Tiles/tile025.png"))},
            {17, new Texture(Paths.GetTexture("Tiles/tile012.png"))},
            {0, new Texture(Paths.GetTexture("Tiles/tile036.png"))},
            {65, new Texture(Paths.GetTexture("Tiles/tile014.png"))},
            {80, new Texture(Paths.GetTexture("Tiles/tile026.png"))},
            {16, new Texture(Paths.GetTexture("Tiles/tile024.png"))},
            {64, new Texture(Paths.GetTexture("Tiles/tile003.png"))},
            {1, new Texture(Paths.GetTexture("Tiles/tile000.png"))},
            {85, new Texture(Paths.GetTexture("Tiles/tile037.png"))},
            {4, new Texture(Paths.GetTexture("Tiles/tile001.png"))},
            {193, new Texture(Paths.GetTexture("Tiles/tile037.png"))},
            {28, new Texture(Paths.GetTexture("Tiles/tile037.png"))},
            {7, new Texture(Paths.GetTexture("Tiles/tile037.png"))},
        });
        
        _cachedRenderData = new RenderData()
        {
            Mesh = MeshBuilder.Quad(1f),
            Material = new UnlitMaterial(new LitMaterialData())
        };
    }

    public void Initialize()
    {
        _cachedRenderData.Material.Initialize();
        _autoTiling.Initialize();
    }

    public GameObject Create(Vector2i position, TileNeighbours tileNeighbours)
    {
        Transform transform = new Transform(new Vector3(position.X, position.Y, 0), _parent);
        
        RenderData renderData = new()
        {
            Mesh = _cachedMesh,
            Transform = transform,
            Material = new UnlitMaterial(new LitMaterialData()
            {
                Base = _autoTiling.GetTexture(tileNeighbours)
            }),
        };
        
        return GameObjectFactory.WithRenderData(renderData);
    }
}