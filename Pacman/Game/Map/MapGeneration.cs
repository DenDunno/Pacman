using OpenTK.Mathematics;

public class MapGeneration
{
    private readonly List<Vector2i> _obstacles;
    private readonly HashSet<Vector2i> _freeCells;

    public MapGeneration(List<Vector2i> obstacles, HashSet<Vector2i> freeCells)
    {
        _obstacles = obstacles;
        _freeCells = freeCells;
    }
    
    public void Evaluate(int rows, int columns)
    {
        SetupBorders(rows, columns);
        BuildMaze(rows - 1, columns - 1);
        EvaluateFreeCells(rows, columns);
    }

    private void SetupBorders(int rows, int columns)
    {
        for (int i = 0; i < columns; ++i)
        {
            _obstacles.Add(new Vector2i(i, 0));
            _obstacles.Add(new Vector2i(i, rows - 1));
        }
        
        for (int i = 1; i < rows - 1; ++i)
        {
            _obstacles.Add(new Vector2i(0, i));
            _obstacles.Add(new Vector2i(columns - 1, i));
        }
    }

    private void BuildMaze(int rows, int columns)
    {
        int centre = columns / 2;

        for (int i = 2; i < rows - 1; ++i)
        {
            _obstacles.Add(new Vector2i(centre, i));
        }
    }

    private void EvaluateFreeCells(int rows, int columns)
    {
        for (int i = 0; i < rows; ++i)
        {
            for (int j = 0; j < columns; ++j)
            {
                Vector2i tile = new(j, i);
                
                if (_obstacles.Contains(tile) == false)
                {
                    _freeCells.Add(tile);
                }
            }
        }
    }
}