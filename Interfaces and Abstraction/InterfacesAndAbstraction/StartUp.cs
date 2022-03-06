
using System;

namespace Shapes
{ 
    public class StartUp
    {
        static void Main(string[] args)
        {
            IDrawable rectangle = new Rectangle(4, 6);
            rectangle.Draw();
        }
    }
}
