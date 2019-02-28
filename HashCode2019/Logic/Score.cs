using HashCode2019.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HashCode2019.Logic
{
    public static class Score
    {
        static int ComputeScore(Slide s1, Slide s2)
        {
            var tags1 = s1.Photos.SelectMany(p => p.Tags).Distinct().ToList();
            var tags2 = s2.Photos.SelectMany(p => p.Tags).Distinct().ToList();
            var mergedTags = tags1.Intersect(tags2).ToList();

            return Math.Min(Math.Min(tags1.Count, tags2.Count), mergedTags.Count);
        }

        static int ComputeScore(List<Slide> s)
        {
            var total = 0;
            for(var i = 0; i < s.Count - 1; ++i)
            {
                total += ComputeScore(s[i], s[i + 1]);
            }

            return total;
        }
    }
}
