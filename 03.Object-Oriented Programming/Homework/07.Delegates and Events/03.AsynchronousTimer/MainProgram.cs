using System;

namespace _03.AsynchronousTimer
{
    class MainProgram
    {
        static void Main()
        {
            var timer = new Timer(Console.WriteLine, 5, 500, "I'm an asynchronous timer!");
            timer.Run();
        }
    }
}