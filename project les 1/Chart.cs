using System;
using System.Collections.Generic;
using System.Text;

namespace project_les_1
{
    public class Chart
    {
        public string Character = "@";
        public object Getpos(int currY, int currX)
        {
            int[] pos = new int[2] { currY, currX };
            return pos;
        }

    }
}
