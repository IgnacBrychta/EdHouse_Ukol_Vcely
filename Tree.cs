namespace EdHouse_Ukol_Vcely;

internal class Tree
{
    internal readonly Coordinate coordinate;
    internal readonly int height;
    internal bool isVisible = false;
    internal Tree(Coordinate coordinate, int height)
    {
        this.coordinate = coordinate;
        this.height = height;
    }

    public override string ToString()
    {
        return $"{coordinate}: Height: {height} | Visible: {(isVisible ? 'T' : 'F')}";
    }
}
