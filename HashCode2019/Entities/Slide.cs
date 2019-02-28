using System.Collections.Generic;
using System.Linq;

namespace HashCode2019.Entities
{
    public class Slide
    {
        public Orientation Orientation => Photos.Count() == 1 ? 
            Orientation.Horizontal : 
            Orientation.Vertical;

        public List<Photo> Photos { get; set; }

        public List<string> Tags
        {
            get
            {
                return Photos.SelectMany(photo => photo.Tags).Distinct().ToList();
            }
        }
    }
}
