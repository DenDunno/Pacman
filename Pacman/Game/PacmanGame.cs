﻿using OpenTK.Mathematics;

public class PacmanGame : IGameComponent
{
    [EditorField] private readonly int _rows = 3;
    [EditorField] private readonly int _columns = 3;
    private readonly Character _character;
    private readonly Ghost[] _ghosts;
    private readonly Cherry _cherry;
    private readonly Maze _maze;

    public PacmanGame(Character character, Cherry cherry, Ghost[] ghosts, Maze maze)
    {
        _character = character;
        _cherry = cherry;
        _ghosts = ghosts;
        _maze = maze;
    }

    [EditorButton]
    private void GenerateLevel()
    {
        _maze.Generate(_rows, _columns);
        RestartRound();
    }

    void IGameComponent.Update(float deltaTime)
    {
        if (Vector3.Distance(_character.Transform.Position, _cherry.Transform.Position) < 0.01f)
        {
            RestartRound();
        }
    }

    [EditorButton]
    private void RestartRound()
    {
        PlaceAtRandomFreeCell(_character.Transform, 0.001f);
        PlaceAtRandomFreeCell(_cherry.Transform);

        foreach (Ghost ghost in _ghosts)
        {
            PlaceAtRandomFreeCell(ghost.Transform);
        }
        
        _character.CalculatePath();
    }

    private void PlaceAtRandomFreeCell(Transform transform, float z = 0)
    {
        Vector2i position = _maze.FreeCells.GetRandomElement();
        transform.Position = new Vector3(position.X, position.Y, z);
    }
}