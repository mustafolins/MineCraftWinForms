namespace MineCraftShared
{
    public interface ICube
    {
        int Depth { get; set; }
        int Height { get; set; }
        int Width { get; set; }
        CubeData[] Points { get; set; }
    }
}