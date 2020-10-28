using System;
using System.Collections.Generic;
using System.Text;

namespace project_les_1
{
    public class LevelCheck
    {
        public string Level(int lvl)
        {
            string map = "";
            var level = new Levels();
            if (lvl == 1)
            {
                map = level.Level1();

            }
            else if (lvl == 2)
            {
                map = level.Level2();

            }
            return map;
        }
    }
}
