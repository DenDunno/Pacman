using OpenTK.Mathematics;

public class ObstacleSpawner
{
    private readonly Transform _parent;
    private readonly AutoTiling _autoTiling;
    private readonly RenderData _cachedRenderData = new()
    {
        Mesh = MeshBuilder.Quad(1f)
    };

    public ObstacleSpawner(Transform parent)
    {
        _parent = parent;
        _autoTiling = new AutoTiling(new AutoTile[] 
        {
            new(5, GetTexturePath(13)),
            new(68, GetTexturePath(02)),
            new(17, GetTexturePath(12)),
            new(0, GetTexturePath(36)),
            new(16, GetTexturePath(24)),
            new(64, GetTexturePath(03)),
            new(1, GetTexturePath(00)),
            new(4, GetTexturePath(01)),
            new(65, GetTexturePath(14)),
            new(193, GetTexturePath(14)),
            new(23, GetTexturePath(15)),
            new(29, GetTexturePath(15)),
            new(80, GetTexturePath(26)),
            new(112, GetTexturePath(26)),
            new(20, GetTexturePath(25)),
            new(28, GetTexturePath(25)),
            new(85, GetTexturePath(37)),
            new(7, GetTexturePath(13)),
            new(71, GetTexturePath(16)),
            new(197, GetTexturePath(16)),
            new(199, GetTexturePath(16)),
            new(124, GetTexturePath(27)),
            new(92, GetTexturePath(27)),
            new(116, GetTexturePath(27)),
            new(69, GetTexturePath(16)),
            new(21, GetTexturePath(15)),
            new(31, GetTexturePath(15)),
            new(84, GetTexturePath(27)),
            new(209, GetTexturePath(28)),
            new(113, GetTexturePath(28)),
            new(255, GetTexturePath(37)),
            new(241, GetTexturePath(28)),
            new(215, GetTexturePath(37)),
            new(247, GetTexturePath(37)),
            new(253, GetTexturePath(37)),
            new(127, GetTexturePath(37)),
            new(223, GetTexturePath(37)),
            new(246, GetTexturePath(37)),
            new(81, GetTexturePath(28)),
            new(125, GetTexturePath(37)),
            new(245, GetTexturePath(37)),
            new(221, GetTexturePath(37)),
            new(93, GetTexturePath(37)),
            new(95, GetTexturePath(37)),
            new(213, GetTexturePath(37)),
            new(117, GetTexturePath(37)),
            new(119, GetTexturePath(37)),
            new(87, GetTexturePath(37)),
        });
    }

    private string GetTexturePath(int index)
    {
        return Paths.GetTexture($"Tiles/tile0{index:D2}.png");
    }

    public GameObject Create(Vector2i position, TileNeighbours tileNeighbours)
    {
        _cachedRenderData.Transform = new Transform(new Vector3(position.X, position.Y, 0), _parent);
        _cachedRenderData.Material = _autoTiling.GetMaterial(tileNeighbours);
       
        return GameObjectFactory.WithRenderData(_cachedRenderData);
    }
}