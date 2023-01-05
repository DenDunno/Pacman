using Pacman;

public class PacmanWorld : WorldFactory
{
    protected override List<GameObject> CreateGameObjects()
    {
        Map map = new();
        Cherry cherry = new();
        Character character = new(cherry);
        LevelGeneration levelGeneration = new(map, character, cherry);
        
        return new List<GameObject>()
        {
            CreateCharacter(character),
            GameObjectFactory.Point(map),
            GameObjectFactory.Point(levelGeneration),
            GameObjectFactory.Sprite(cherry, "Cherry.png"),
        };
    }

    private GameObject CreateCharacter(Character character)
    {
        GameObject view = GameObjectFactory.Sprite(character, "Pacman/pac_man_0.png");
        
        Material material = ((Model)view.Data.Model).Material;
        SpriteAnimation animation = new(Paths.GetTexturesInFolder("Pacman"), 0.15f, material);
        
        view.Data.Components.Add(animation);
        view.Data.Components.Add(new ObjectControlling(view.Data.Transform, Input.Keyboard));

        return view;
    }
}