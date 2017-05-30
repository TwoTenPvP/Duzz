using Shared.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNC.Core.Helper
{
    class ScreenHelper
    {
        public static double DistanceBetweenScreenPoint(ScreenPoint point1, ScreenPoint point2)
        {
            return Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2));
        }
    }
}
