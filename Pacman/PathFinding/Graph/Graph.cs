using OpenTK.Mathematics;

public class Graph
{
    private readonly Dictionary<Vector2i, Edge[]> _value;

    public IReadOnlyDictionary<Vector2i, Edge[]> Value => _value;
}