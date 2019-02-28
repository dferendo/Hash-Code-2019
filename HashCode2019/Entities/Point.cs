using System;
using System.Collections.Generic;
using System.Text;

namespace HashCode2019.Entities
{
    public class Point
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Point(int x, int y)
        {
            Row = x;
            Column = y;
        }
    }
}
