using OpenTK.Mathematics;

public class ObstacleSpawner
{
    private readonly RenderData _cachedRenderData;
    private readonly Transform _parent;

    public ObstacleSpawner(Transform parent)
    {
        _parent = parent;
        _cachedRenderData = new RenderData()
        {
            Mesh = MeshBuilder.Quad(1f),
            Material = new UnlitMaterial(new LitMaterialData()
            {
                Base = new Texture(Paths.GetTexture("Tiles/tile036.png"))
            })
        };
    }

    public void Initialize()
    {
        _cachedRenderData.Material.Init();
    }

    public GameObject Create(Vector2i position)
    {
        Transform transform = new(new Vector3(position.X, position.Y, 0), _parent);
        
        return GameObjectFactory.WithRenderData(_cachedRenderData, transform);
    }
}