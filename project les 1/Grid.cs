using System;
using System.Collections.Generic;
using System.Text;

namespace project_les_1
{
    class Grid : EndGame
    {
        TextAdventure textadvent = new TextAdventure();
        int level = 1;
        int totalLevels = 2;
        bool[] objTaken;
        bool[] objectives;

        public void CreateSetup()
        {
            objTaken = new bool[totalLevels];
            objectives = new bool[totalLevels];

            for (int x = 0; x < totalLevels; x++)
            {
                objTaken.SetValue(false, x);
                objectives.SetValue(false, x);
            }

            textadvent.Create(new Item() { Name = "Fists", Amount = "INF" });
        }
        public int CreateLevel(int poss, int prevposs) // create room 1
        {
            Console.Clear();
            var pos = new Chart();
            var Level = new LevelCheck();
            var writer = new TextWriter();

            string player = "@";
            string map = Level.Level(level);
            var lvls = new Levels();
            int startpos = map.IndexOf('S');
            int endpos = map.IndexOf('R');

            string I = "";
            foreach (Item x in textadvent.ReturnInv())
            {
                I = I + x.Name + " - [Amount/Durability: " + x.Amount + "]\n";
            }
            //checking if the position is taken by a border or a level pass
            if (objTaken[level - 1])
            {
                map = map.Replace("X", " ");
            }
            if (objectives[level - 1])
            {
                map = map.Replace("*", " ");
            }
            for (int x = 0; x < map.Length; x++)
            {
                if (map[x] == '#')
                {
                    if (poss == x)
                    {
                        map = map.Remove(prevposs, 1);
                        map = map.Insert(prevposs, player);
                        if (objTaken[level - 1])
                        {
                            map = map.Replace("X", " ");
                        }
                        map = map.Replace('S', ' ');
                        map = map.Replace('R', ' ');
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine(map);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("X = object   * = fighting    [Esc] = Pause   \n# = Border   ^ = Next Level   V = Previous level\n");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\n           =[Inventory]=\n");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(I);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        return prevposs;
                    }
                }
                else if (map[x] == '^')
                {
                    if (poss == x)
                    {
                        level = level + 1;
                        map = Level.Level(level);
                        startpos = map.IndexOf('S');
                        map = map.Remove(startpos, 1);
                        map = map.Insert(startpos, player);
                        if (objTaken[level - 1])
                        {
                            map = map.Replace("X", " ");
                        }
                        map = map.Replace('R', ' ');
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine(map);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("X = object   * = fighting    [Esc] = Pause   \n# = Border   ^ = Next Level   V = Previous level\n");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\n           =[Inventory]=\n");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(I);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        return startpos;
                    }
                }
                else if (map[x] == 'W')
                {
                    if(poss == x)
                    {
                        Ending();
                    }
                }
                else if (map[x] == 'v')
                {
                    if (poss == x)
                    {
                        level = level - 1;
                        map = Level.Level(level);
                        endpos = map.IndexOf('R');
                        map = map.Remove(endpos, 1);
                        map = map.Insert(endpos, player);
                        if (objTaken[level - 1])
                        {
                            map = map.Replace("X", " ");
                        }
                        map = map.Replace('S', ' ');
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine(map);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("X = object   * = fighting    [Esc] = Pause   \n# = Border   ^ = Next Level   V = Previous level\n");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\n           =[Inventory]=\n");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(I);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        return endpos;
                    }
                }
            }
            // objective
            int treasure = map.IndexOf("X");
            int objective = map.IndexOf("*");
            if (poss == treasure)
            {
                textadvent.textNquest(level);
                Console.Clear();
                objTaken[level - 1] = true;
            }
            else if (poss == objective)
            {
                textadvent.objective(level);
                Console.Clear();
                objectives[level - 1] = true;
            }
            map = map.Remove(poss, 1);
            map = map.Insert(poss, player);
            I = "";
            foreach (Item x in textadvent.ReturnInv())
            {
                I = I + x.Name + " - [Amount/Durability: " + x.Amount + "]\n";
            }
            map = map.Replace('S', ' ');
            map = map.Replace('R', ' ');
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(map);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("X = object   * = fighting    [Esc] = Pause   \n# = Border   ^ = Next Level   V = Previous level\n");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n           =[Inventory]=\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(I);
            Console.ForegroundColor = ConsoleColor.Gray;
            return poss;
        }
    }
}
