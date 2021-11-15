using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot
{
    public class FlatTable
    {
        private List<FlatVector> _positions;
        public List<FlatVector> Positions 
        {
            get { return _positions; }
        }

        public FlatTable(int xLength,int yLenght)
        {
            var _cells = new List<FlatVector>();
            for (int i = 0; i < xLength; i++) {
                for (int j = 0; j < yLenght; j++)
                {
                    _cells.Add(new FlatVector() { Xaxis = i , Yaxis = j});
                }
            }

            this._positions = _cells;
        } 

        public bool IsOutOfBoundary(FlatVector flatPosition)
        {
            return !this._positions.Any(c=>c.Xaxis == flatPosition.Xaxis && c.Yaxis == flatPosition.Yaxis);
        }
    }
}
