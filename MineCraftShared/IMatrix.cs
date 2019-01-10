namespace MineCraftShared
{
    public interface IMatrix
    {
        int Depth { get; set; }
        int Length { get; set; }
        int Width { get; set; }
        Data[,,] Data { get; set; }
    }
}