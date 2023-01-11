using OpenTK.Mathematics;

public class AStarAlgorithm : IPathFindingAlgorithm
{
    private readonly HashSet<Vector2i> _closedNodes = new();
    private readonly HashSet<Vector2i> _openedNodes = new();
    private readonly Dictionary<Vector2i, float> _costToNode = new();
    private readonly Dictionary<Vector2i, float> _predictedCostToTargetFromNode = new();
    private readonly Dictionary<Vector2i, Vector2i> _path = new();
    private HashSet<Vector2i> _freeCells = null!;
    private Vector2i _target;
    private Vector2i _start;
    
    public List<Vector2i> Execute(Vector2i start, Vector2i target, HashSet<Vector2i> freeCells)
    {
       Initialize(start, target, freeCells);

        while (_openedNodes.IsNotEmpty())
        {
            Vector2i current = GetOpenedNodeWithMinPredictedPath();

            if (current == target)
            {
                return BuildPath();
            }

            _openedNodes.Remove(current);
            _closedNodes.Add(current);

            foreach (Vector2i neighbour in GetNeighbours(current))
            {
                _path[neighbour] = current;
                _costToNode[neighbour] = _costToNode[current] + 1;
                _predictedCostToTargetFromNode[neighbour] = _costToNode[neighbour] + GetRealDistanceToTarget(neighbour);
                _openedNodes.Add(neighbour);
            }
        }

        throw new Exception("Pacman doesn't have path to target. Bad maze!");
    }

    private void Initialize(Vector2i start, Vector2i target, HashSet<Vector2i> freeCells)
    {
        _start = start;
        _target = target;
        _freeCells = freeCells;
        
        _closedNodes.Clear();
        _openedNodes.Clear();
        _costToNode.Clear();
        _predictedCostToTargetFromNode.Clear();
        _path.Clear();
        
        _openedNodes.Add(start);
        _costToNode[start] = 0;
        _predictedCostToTargetFromNode[start] = _costToNode[start] + GetRealDistanceToTarget(start);
    }

    private List<Vector2i> BuildPath()
    {
        List<Vector2i> result = new();
        Vector2i node = _target;

        while (node != _start)
        {
            result.Add(node);
            node = _path[node];
        }
        
        result.Add(_start);
        result.Reverse();
        
        return result;
    }

    private List<Vector2i> GetNeighbours(Vector2i node)
    {
        List<Vector2i> result = new();
        
        TryAddNeighbour(result, new Vector2i(node.X + 1, node.Y));
        TryAddNeighbour(result, new Vector2i(node.X - 1, node.Y));
        TryAddNeighbour(result, new Vector2i(node.X, node.Y + 1));
        TryAddNeighbour(result, new Vector2i(node.X, node.Y - 1));

        return result;
    }

    private void TryAddNeighbour(List<Vector2i> container, Vector2i node)
    {
        if (_closedNodes.Contains(node) == false && _freeCells.Contains(node))
        {
            container.Add(node);
        }
    }
    
    private Vector2i GetOpenedNodeWithMinPredictedPath()
    {
        float min = float.MaxValue;
        Vector2i node = Vector2i.Zero;
        
        foreach (Vector2i openedNode in _openedNodes)
        {
            if (_predictedCostToTargetFromNode[openedNode] < min)
            {
                min = _predictedCostToTargetFromNode[openedNode];
                node = openedNode;
            } 
        }

        return node;
    }
    
    private float GetRealDistanceToTarget(Vector2i node)
    {
        return Vector2.Distance(_target, node);
    }
}