using System;

namespace project_les_1
{
    public class Startup
    {
        public void Mainmenu()
        {
            int selected = 0;
            bool inmain = true;
            while (inmain)
            {
                string[] opts = new string[3] { " start ", " exit ", " credits " };
                string[] contxt = new string[3] { "starts the game", "leave and close the game", "credits and such containing from the game" };
                opts[selected] = ">" + opts[selected] + "<";
                string menu = "\n\n\n\n\n\n\n\n\n\n\n                                               -------------------------" + "\n                                                      " + opts[0] + "\n                                                      " + opts[1] + "\n                                                      " + opts[2] + "\n                                               -------------------------";
                Console.WriteLine(menu);
                ConsoleKey key = Console.ReadKey().Key;

                if (key == ConsoleKey.DownArrow)
                {
                    selected = selected + 1; ;
                    if (selected == 3)
                    {
                        selected = 0;
                    }
                }
                else if (key == ConsoleKey.UpArrow)
                {
                    opts[selected].Remove(0, 1);
                    selected = selected - 1;
                    if (selected == -1)
                    {
                        selected = 2;
                    }
                }
                else if (key == ConsoleKey.Enter)
                {
                    if (selected == 0)
                    {
                        inmain = false;
                    }
                    else if (selected == 1)
                    {
                        Environment.Exit(0);
                    }
                    else if (selected == 2)
                    {
                        bool inCreds = true;
                        while (inCreds)
                        {
                            Console.Clear();
                            Console.WriteLine(" \n\n\n\n\n\n\n\n\n\n\n                                               -------------------------\n                                                 Scripting: Blade (Aka Jurian Vierbergen)\n                                                Concept creator: Blade\n\n                                               -------------------------\n                                                       [1] Return");
                            if (Console.ReadKey().Key == ConsoleKey.D1)
                            {
                                inCreds = false;
                            }
                        }
                    }
                }
                Console.Clear();
            }
        }
    }
}
