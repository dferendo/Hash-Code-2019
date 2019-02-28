using HashCode2019.Entities;
using System.Collections.Generic;

namespace HashCode2019.Logic
{
    interface ISlideGenerator
    {
        List<Slide> generateSlide(List<Photo> photos);
    }
}
