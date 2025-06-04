namespace ALGO.ASS2.PART1B.DataTypes;

public struct Point
{
    public int Row { get; set; }
    public int Col { get; set; }
    
    public Point(int row, int col)
    {
        Row = row;
        Col = col;
    }
}
