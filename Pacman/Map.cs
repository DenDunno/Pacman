
public enum MapPart
{
    Obstacle,
    None,
}

public class Map : IGameComponent
{
    private readonly List<List<MapPart>> _map = new();

    public void Generate(int rows, int columns)
    {
        _map.Clear();

        for (int i = 0; i < rows; ++i)
        {
            List<MapPart> row = new(columns);
            
            for (int j = 0; j < columns; ++j)
            {
                row[j] = (MapPart)new Random().Next(0, 2);
            }
            
            _map.Add(row);
        }
    }
}