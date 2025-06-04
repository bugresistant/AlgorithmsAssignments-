namespace ALGO.ASS2.PART1B.DataTypes;

public struct Wizard
{
    public Point Position { get; set; }
    public double Speed { get; set; } // corridors per unit of time

    public Wizard(Point position, double speed)
    {
        Position = position;
        Speed = speed;
    }
}