
public class PacmanWorld : WorldFactory
{
    protected override List<GameObject> CreateGameObjects()
    {
        Transform mapTransform = new();
        Transform cherryTransform = new();
        Transform characterTransform = new();
        
        Map map = new(mapTransform);
        Cherry cherry = new(cherryTransform);
        Character character = new(cherry, map, characterTransform);
        PacmanGame pacmanGame = new(map, character, cherry);

        return new List<GameObject>()
        {
            GameObjectFactory.Point(pacmanGame),
            GameObjectFactory.Point(map, mapTransform),
            CreateCharacter(character, characterTransform),
            GameObjectFactory.Sprite(cherry, Paths.GetTexture("Cherry.png"), cherryTransform),
        };
    }

    private GameObject CreateCharacter(Character character, Transform transform)
    {
        GameObject view = GameObjectFactory.Sprite(character, Paths.GetTexture("Pacman/pac_man_0.png"), transform);
        Material material = ((Model)view.Data.Model).Material;
        SpriteAnimation animation = new(Paths.GetTexturesInFolder("Pacman"), 0.15f, material);
        
        view.Data.Components.Add(animation);

        return view;
    }
}