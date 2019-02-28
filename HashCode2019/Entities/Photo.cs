using System;
using System.Collections.Generic;
using System.Text;

namespace HashCode2019.Entities
{
    public enum Orientation
    {
        Horizontal,
        Vertical
    }

    public class Photo
    {
        public int PhotoID { get; set; }

        public Orientation Orientation { get; set; }

        public List<int> Tags { get; set; }
    }
}
