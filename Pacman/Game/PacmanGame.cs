using OpenTK.Mathematics;

public class PacmanGame : IGameComponent
{
    [EditorField] private readonly int _rows = 4;
    [EditorField] private readonly int _columns = 4;
    private readonly Map _map;
    private readonly Character _character;
    private readonly Cherry _cherry;

    public PacmanGame(Map map, Character character, Cherry cherry)
    {
        _map = map;
        _character = character;
        _cherry = cherry;
    }

    void IGameComponent.Initialize()
    {
        GenerateLevel();
    }

    [EditorButton]
    private void GenerateLevel()
    {
        _map.Generate(_rows, _columns);
        PlaceAtRandomFreeCell(_character.Transform);
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

    private void PlaceAtRandomFreeCell(Transform transform)
    {
        Vector2i position = _map.GetRandomFreeCell();
        transform.Position = new Vector3(position.X, position.Y, 0);
    }
}