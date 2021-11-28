namespace ToyRobot
{
    /// <summary>
    /// Class represents a flat table with boundary
    /// </summary>
    public class FlatTable
    {
        public int XAxisMax { get; set; }
        public int YAxisMax { get; set; }

        public FlatTable(int xAxisIndex,int yAxisIndex)
        {
            XAxisMax = xAxisIndex;
            YAxisMax = yAxisIndex;
        } 

        public bool IsOutOfBoundary(FlatVector flatPosition)
        {
            return flatPosition.Xaxis > XAxisMax || flatPosition.Yaxis > YAxisMax || flatPosition.Xaxis < 0 || flatPosition.Yaxis < 0;
        }
    }
}
