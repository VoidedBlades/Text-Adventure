using System;
using System.Threading;

namespace project_les_1
{
    public class TextWriter
    {
        public void Writer(string text)
        {
            for (int i = 0; i < text.Length; i++)

            {
                Console.Write(text[i]);
                Thread.Sleep(10);
            }
        }
    }
}
