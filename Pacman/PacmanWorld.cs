using Pacman;

public class PacmanWorld : WorldFactory
{
    protected override List<GameObject> CreateGameObjects()
    {
        Map map = new();
        Target target = new();
        Character character = new(target);
        LevelGeneration levelGeneration = new(map, character, target);
        
        return new List<GameObject>()
        {
            CreateObject(character),
        };
    }

    private GameObject CreateObject(IGameComponent gameComponent)
    {
        RenderData renderData = new()
        {
            Mesh = MeshBuilder.Quad(1f),
            Material = new UnlitMaterial(new LitMaterialData()
            {
                Base = new Texture(Paths.GetTexture("Pacman/pac_man_0.png"))
            })
        };

        return new GameObject(new GameObjectData(gameComponent.GetType().Name, renderData.Transform)
        {
            Components = new List<IGameComponent>()
            {
                gameComponent,
                new SpriteAnimation(Paths.GetTexturesInFolder("Pacman"), 0.15f, renderData.Material)
            },
            
            Model = new Model(renderData)
        });
    }
}