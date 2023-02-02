
public class PacmanModel
{
    public readonly Character Character;
    public readonly PacmanGame Game;
    public readonly Ghost Ghost1;
    public readonly Ghost Ghost2;
    public readonly Cherry Cherry;
    public readonly Maze Maze;

    public PacmanModel(PacmanTransforms transforms)
    {
        Maze = new(transforms.Maze);
        Cherry = new(transforms.Cherry);
        Character = new(transforms.Character, new AStarAlgorithm(transforms.Character, transforms.Cherry, Maze.FreeCells));
        Ghost1 = new(transforms.Ghost1, new DijkstraAlgorithm(transforms.Ghost1, transforms.Character, Maze.FreeCells));
        Ghost2 = new(transforms.Ghost2, new AStarAlgorithm(transforms.Ghost2, transforms.Character, Maze.FreeCells));
        Game = new PacmanGame(Character, Cherry, new[] {Ghost1, Ghost2}, Maze);
    }
}