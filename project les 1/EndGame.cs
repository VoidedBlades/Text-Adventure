using System;
using System.Collections.Generic;
using System.Text;

namespace project_les_1
{
    class EndGame : TextWriter
    {
        public void Ending()
        {
            Writer("you came out of the forest alive, it has been a journey but it surely is something to remember!\npress any key to end the game.");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
