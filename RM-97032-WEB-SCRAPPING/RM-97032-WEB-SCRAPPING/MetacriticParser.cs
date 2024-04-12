using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RM_97032_WEB_SCRAPPING
{
    internal class MetacriticParser
    {
        public record CriticRating(string Title = "", int MetascoreAverage = -1, double UserScoreAverage = -1);
    }
}
