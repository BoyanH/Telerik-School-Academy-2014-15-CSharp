using System;

namespace TimerWithEvents
{
    public class TimerTest
    {
        public static Timer timer = new Timer(PrintTime, 50); //very similar to javascript's SetInterval function
        static event EventHandler<ConsoleKey> HandleEnter;
        static event EventHandler<ConsoleKey> HandleSpace;

        public static void KeyPressed(ConsoleKey key)
        {
            if (key == ConsoleKey.Enter)
            {
                HandleEnter(null, ConsoleKey.Enter);
            }

            if (key == ConsoleKey.Spacebar)
            {
                HandleSpace(null, ConsoleKey.Spacebar);
            }
        }

        public static void PrintTime()
        {
            Console.Clear();
            Console.WriteLine("Press <ENTER> to start/stop the timer, <SPACE> to reset it!\n");
            Console.WriteLine("Time passed: {0:00}:{1:00}:{2:00}:{3:00} (hh:mm:ss:ms)",
                timer.TimePassed.Hours, timer.TimePassed.Minutes, timer.TimePassed.Seconds, timer.TimePassed.Milliseconds);
        }

        public static void Main()
        {

            Console.WriteLine("Press <ENTER> to start/stop the timer, <SPACE> to reset it!");

            HandleEnter = delegate(object sender, ConsoleKey key)
            {
                timer.ChangeState();
            };

            HandleSpace = delegate(object sender, ConsoleKey key)
            {
                timer.Reset();
                PrintTime();
            };

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    KeyPressed(Console.ReadKey().Key);
                }
            }
        }
    }
}
