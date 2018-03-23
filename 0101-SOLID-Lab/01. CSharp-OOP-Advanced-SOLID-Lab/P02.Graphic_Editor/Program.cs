using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            IShape rect = new Rectangle();
            rect.Draw();
        }
    }
}
