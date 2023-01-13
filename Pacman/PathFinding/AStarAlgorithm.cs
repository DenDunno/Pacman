using OpenTK.Mathematics;

public class AStarAlgorithm : IPathFindingAlgorithm
{
    private readonly Dictionary<Vector2i, float> _predictedCostToTargetFromNode = new();
    private readonly Dictionary<Vector2i, float> _costToNode = new();
    private readonly Dictionary<Vector2i, Vector2i> _path = new();
    private readonly HashSet<Vector2i> _closedNodes = new();
    private readonly HashSet<Vector2i> _openedNodes = new();
    private readonly HashSet<Vector2i> _freeCells;
    private Vector2i _target;
    private Vector2i _start;

    public AStarAlgorithm(HashSet<Vector2i> freeCells)
    {
        _freeCells = freeCells;
    }
    
    public List<Vector2i> Execute(Vector2i start, Vector2i target)
    {
       Initialize(start, target);
       Run();
       return BuildPath();
    }

    private void Run()
    {
        while (_openedNodes.IsNotEmpty())
        {
            Vector2i current = GetOpenedNodeWithMinPredictedPath();

            _openedNodes.Remove(current);
            _closedNodes.Add(current);
            
            if (current == _target)
            {
                return;
            }
            
            foreach (Vector2i neighbour in GetNeighbours(current))
            {
                _path[neighbour] = current;
                _costToNode[neighbour] = _costToNode[current] + 1;
                _predictedCostToTargetFromNode[neighbour] = _costToNode[neighbour] + GetRealDistanceToTarget(neighbour);
                _openedNodes.Add(neighbour);
            }
        }
    }

    private void Initialize(Vector2i start, Vector2i target)
    {
        _start = start;
        _target = target;

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

        if (_closedNodes.Contains(_target)) // success
        {
            while (node != _start)
            {
                result.Add(node);
                node = _path[node];
            }   
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