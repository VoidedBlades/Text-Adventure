using System;

namespace project_les_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = new Grid();
            var mainmen = new Startup();

            bool playing = true;
            bool paused = false;
            int pos = 212;
            int prevposs = 212;
            mainmen.Mainmenu();
            grid.CreateSetup();
            while (playing)
            {
                pos = grid.CreateLevel(pos, prevposs);
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    prevposs = pos;
                    pos = pos - 102;
                }

                else if (key.Key == ConsoleKey.DownArrow)
                {
                    prevposs = pos;
                    pos = pos + 102;
                }

                else if (key.Key == ConsoleKey.LeftArrow)
                {
                    prevposs = pos;
                    pos = pos - 1;
                }

                else if (key.Key == ConsoleKey.RightArrow)
                {
                    prevposs = pos;
                    pos = pos + 1;
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    if (paused)
                    {
                        paused = false;
                    }
                    else
                    {
                        paused = true;
                        int selected = 0;
                        while (paused)
                        {
                            Console.Clear();
                            string[] opts = new string[2] { " continue ", " exit "};
                            string[] contxt = new string[2] { "continues the game", "leave and close the game"};
                            opts[selected] = ">" + opts[selected] + "<";
                            string menu = "\n\n\n\n\n\n\n\n\n\n\n                                               -------------------------" + "\n                                                      " + opts[0] + "\n                                                      " + opts[1] + "\n                                               -------------------------";
                            Console.WriteLine(menu);
                            ConsoleKeyInfo k = Console.ReadKey();
                            if (k.Key == ConsoleKey.DownArrow)
                            {
                                selected = selected + 1;
                                if (selected == 2)
                                {
                                    selected = 0;
                                }
                            }
                            else if (k.Key == ConsoleKey.UpArrow)
                            {
                                opts[selected].Remove(0, 1);
                                selected = selected - 1;
                                if (selected == -1)
                                {
                                    selected = 1;
                                }
                            }
                            else if (k.Key == ConsoleKey.Enter)
                            {
                                if (selected == 0)
                                {
                                    paused = false;
                                }
                                else if (selected == 1)
                                {
                                    Environment.Exit(0);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
