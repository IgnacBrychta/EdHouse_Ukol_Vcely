namespace EdHouse_Ukol_Vcely;

internal class Coordinate
{
    internal readonly int x;
    internal readonly int y;
    public Coordinate(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public override string ToString()
    {
        return $"[{x}; {y}]";
    }
}
