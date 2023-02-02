
public class PacmanWorld : IWorldFactory
{
    public List<GameObject> CreateGameObjects()
    {
        PacmanTransforms transforms = new();
        PacmanModel model = new(transforms);
        
        return new List<GameObject>()
        {
            GameObjectFactory.Point(model.Game),
            GameObjectFactory.Point(model.Maze, transforms.Maze),
            CreateCharacter(model.Character, transforms.Character),
            GameObjectFactory.CreateCamera(new OrthographicProjection()),
            GameObjectFactory.Sprite(model.Cherry, Paths.GetTexture("Cherry.png"), transforms.Cherry),
            GameObjectFactory.Sprite(model.Ghost1, Paths.GetTexture("Ghosts/blue_0.png"), transforms.Ghost1),
            GameObjectFactory.Sprite(model.Ghost2, Paths.GetTexture("Ghosts/orange_0.png"), transforms.Ghost2),
        };
    }

    private GameObject CreateCharacter(Character character, Transform transform)
    {
        GameObject view = GameObjectFactory.Sprite(character, Paths.GetTexture("Pacman/pac_man_0.png"), transform);
        Material material = ((Model)view.Data.Drawable).Material;
        SpriteAnimation animation = new(Paths.GetTexturesInFolder("Pacman"), 0.15f, material);
        
        view.Data.Components.Add(animation);

        return view;
    }
}