using OpenTK.Mathematics;

public class ObstacleSpawner
{
    private readonly RenderData _cachedRenderData;
    private readonly Transform _parent;
    private readonly AutoTiling _autoTiling;

    public ObstacleSpawner(Transform parent)
    {
        _parent = parent;
        _autoTiling = new AutoTiling(new Dictionary<int, Texture>()
        {
            {5, new Texture(Paths.GetTexture("Tiles/tile013.png"))},
            {68, new Texture(Paths.GetTexture("Tiles/tile002.png"))},
            {17, new Texture(Paths.GetTexture("Tiles/tile012.png"))},
            {0, new Texture(Paths.GetTexture("Tiles/tile036.png"))},
            {16, new Texture(Paths.GetTexture("Tiles/tile024.png"))},
            {64, new Texture(Paths.GetTexture("Tiles/tile003.png"))},
            {1, new Texture(Paths.GetTexture("Tiles/tile000.png"))},
            {4, new Texture(Paths.GetTexture("Tiles/tile001.png"))},
            {65, new Texture(Paths.GetTexture("Tiles/tile014.png"))},
            {193, new Texture(Paths.GetTexture("Tiles/tile014.png"))},
            {23, new Texture(Paths.GetTexture("Tiles/tile015.png"))},
            {29, new Texture(Paths.GetTexture("Tiles/tile015.png"))},
            {80, new Texture(Paths.GetTexture("Tiles/tile026.png"))},
            {112, new Texture(Paths.GetTexture("Tiles/tile026.png"))},
            {20, new Texture(Paths.GetTexture("Tiles/tile025.png"))},
            {28, new Texture(Paths.GetTexture("Tiles/tile025.png"))},
            {85, new Texture(Paths.GetTexture("Tiles/tile037.png"))},
            {7, new Texture(Paths.GetTexture("Tiles/tile013.png"))},
            {71, new Texture(Paths.GetTexture("Tiles/tile016.png"))},
            {197, new Texture(Paths.GetTexture("Tiles/tile016.png"))},
            {199, new Texture(Paths.GetTexture("Tiles/tile016.png"))},
            {124, new Texture(Paths.GetTexture("Tiles/tile027.png"))},
            {92, new Texture(Paths.GetTexture("Tiles/tile027.png"))},
            {116, new Texture(Paths.GetTexture("Tiles/tile027.png"))},
            {69, new Texture(Paths.GetTexture("Tiles/tile016.png"))},
            {21, new Texture(Paths.GetTexture("Tiles/tile015.png"))},
            {31, new Texture(Paths.GetTexture("Tiles/tile015.png"))},
            {84, new Texture(Paths.GetTexture("Tiles/tile027.png"))},
            {209, new Texture(Paths.GetTexture("Tiles/tile028.png"))},
            {113, new Texture(Paths.GetTexture("Tiles/tile028.png"))},
            {255, new Texture(Paths.GetTexture("Tiles/tile037.png"))},
            {241, new Texture(Paths.GetTexture("Tiles/tile028.png"))},
            {215, new Texture(Paths.GetTexture("Tiles/tile037.png"))},
            {247, new Texture(Paths.GetTexture("Tiles/tile037.png"))},
            {253, new Texture(Paths.GetTexture("Tiles/tile037.png"))},
            {127, new Texture(Paths.GetTexture("Tiles/tile037.png"))},
            {223, new Texture(Paths.GetTexture("Tiles/tile037.png"))},
            {246, new Texture(Paths.GetTexture("Tiles/tile037.png"))},
            {81, new Texture(Paths.GetTexture("Tiles/tile028.png"))},
            {125, new Texture(Paths.GetTexture("Tiles/tile037.png"))},
            {245, new Texture(Paths.GetTexture("Tiles/tile037.png"))},
            {221, new Texture(Paths.GetTexture("Tiles/tile037.png"))},
            {93, new Texture(Paths.GetTexture("Tiles/tile037.png"))},
            {95, new Texture(Paths.GetTexture("Tiles/tile037.png"))},
            {213, new Texture(Paths.GetTexture("Tiles/tile037.png"))},
            {117, new Texture(Paths.GetTexture("Tiles/tile037.png"))},
            {119, new Texture(Paths.GetTexture("Tiles/tile037.png"))},
            {87, new Texture(Paths.GetTexture("Tiles/tile037.png"))},
        });
        
        _cachedRenderData = new RenderData()
        {
            Mesh = MeshBuilder.Quad(1f),
            Material = new UnlitMaterial(new LitMaterialData())
        };
    }

    public GameObject Create(Vector2i position, TileNeighbours tileNeighbours)
    {
        _cachedRenderData.Transform = new Transform(new Vector3(position.X, position.Y, 0), _parent);
        _cachedRenderData.Material = _autoTiling.GetMaterial(tileNeighbours);
       
        return GameObjectFactory.WithRenderData(_cachedRenderData);
    }
}