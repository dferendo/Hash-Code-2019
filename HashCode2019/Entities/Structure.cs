using System;
using System.Collections.Generic;
using System.Text;

namespace HashCode2019.Entities
{
    [Serializable]
    public class InputReading
    {
        public int NumberOfPhotos { get; set; }

        public List<Photo> Photos { get; set; }
    }
}
