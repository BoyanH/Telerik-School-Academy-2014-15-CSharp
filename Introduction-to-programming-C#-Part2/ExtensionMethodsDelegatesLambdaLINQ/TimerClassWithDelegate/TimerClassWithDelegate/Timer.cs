using System;
using System.Threading;

namespace TimerClassWithDelegate
{

    public delegate void TimerDelegate();

    public class Timer
    {
        private int nthExecution = 0;
        private bool running = false;
       
        public TimerDelegate DelegateMethod { get; set; }
        public int TickRate { get; set; }

        public int NthExecution
        {
            get
            {
                return this.nthExecution;
            }
        }

        public Timer(TimerDelegate func, int tickRate)
        {
            this.DelegateMethod = func;
            this.TickRate = tickRate;
        }

        private void TimeTicking()
        {
            while (this.running)
            {
                this.nthExecution++;
                Console.WriteLine("Execution Number{0}!", this.nthExecution);
                this.DelegateMethod();
                Thread.Sleep(this.TickRate); //in milliseconds
            }
        }

        public void StartTimer()
        {
            this.running = true;
            TimeTicking();
        }

        public void StopTimer()
        {
            this.running = false;
            this.nthExecution = 0;
        }
    }
}
