namespace Pacman;

public class Character : IGameComponent
{
    private readonly Cherry _cherry;

    public Character(Cherry cherry)
    {
        _cherry = cherry;
    }
}