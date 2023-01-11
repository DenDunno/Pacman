
public readonly struct Edge
{
    public readonly int FirstNode;
    public readonly int SecondNode;
    public readonly float Weight;

    public Edge(int firstNode, int secondNode, float weight)
    {
        FirstNode = firstNode;
        SecondNode = secondNode;
        Weight = weight;
    }
}