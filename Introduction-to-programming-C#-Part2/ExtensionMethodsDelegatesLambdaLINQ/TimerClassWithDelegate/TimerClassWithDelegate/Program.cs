using System;
using System.Threading;
using System.Threading.Tasks;

namespace TimerClassWithDelegate
{
    public class TimerTest
    {

        public static void SampleVoid()
        {
            Console.WriteLine("tik tok mind block pen stop eye pop full shock time up no luck.");
        }

        public static void Main()
        {
            Timer timer = new Timer(SampleVoid, 500); //very similar to javascript's SetInterval function
            
            Task.Run(() =>
            {
                timer.StartTimer();
            });

            Thread.Sleep(5000);
            timer.StopTimer();

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
