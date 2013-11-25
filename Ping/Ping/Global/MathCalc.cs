using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ping.Global
{
    public static class MathCalc
    {
        public static float SimplifyAngle(float degrees)
        {
            return degrees % 360;
        }
    }
}
