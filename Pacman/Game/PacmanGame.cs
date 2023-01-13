using OpenTK.Mathematics;

public class PacmanGame : IGameComponent
{
    [EditorField] private readonly int _rows = 10;
    [EditorField] private readonly int _columns = 10;
    private readonly Character _character;
    private readonly Cherry _cherry;
    private readonly Map _map;

    public PacmanGame(Character character, Cherry cherry, Map map)
    {
        _character = character;
        _cherry = cherry;
        _map = map;
    }

    void IGameComponent.Initialize()
    {
        GenerateLevel();
    }

    [EditorButton]
    private void GenerateLevel()
    {
        _map.Generate(_rows, _columns);
        PlaceAtRandomFreeCell(_character.Transform, 0.001f);
        RestartRound();
    }

    void IGameComponent.Update(float deltaTime)
    {
        if (Vector3.Distance(_character.Transform.Position, _cherry.Transform.Position) < 0.01f)
        {
            RestartRound();
        }
    }

    private void RestartRound()
    {
        PlaceAtRandomFreeCell(_cherry.Transform);
        _character.CalculatePath();
    }

    private void PlaceAtRandomFreeCell(Transform transform, float z = 0)
    {
        Vector2i position = _map.FreeCells.GetRandom();
        transform.Position = new Vector3(position.X, position.Y, z);
    }
}