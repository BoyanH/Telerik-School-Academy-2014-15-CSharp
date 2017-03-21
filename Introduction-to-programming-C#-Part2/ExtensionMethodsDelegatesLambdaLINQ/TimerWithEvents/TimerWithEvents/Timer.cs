using System;
using System.Threading;
using System.Threading.Tasks;

namespace TimerWithEvents
{

    public delegate void TimerDelegate();

    public class Timer
    {
        private int nthExecution = 0;
        private bool running = false;
        private TimeSpan timePassed;

        public TimerDelegate DelegateMethod { get; set; }
        public int TickRate { get; set; }

        public TimeSpan TimePassed
        {
            get
            {
                return this.timePassed;
            }
        }

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
            this.timePassed = new TimeSpan(0, 0, 0, 0, 0);
        }

        private void TimeTicking()
        {
            Task.Run(() =>
            {
                while (this.running)
                {
                    this.nthExecution++;
                    Console.WriteLine("Execution Number{0}!", this.nthExecution);
                    this.DelegateMethod();
                    this.timePassed += new TimeSpan(0, 0, 0, 0, this.TickRate);
                    Thread.Sleep(this.TickRate); //in milliseconds
                }
            });
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

        public void ChangeState()
        {
            this.running = !this.running;

            if (this.running)
            {
                TimeTicking();
            }
        }

        public void Reset()
        {
            this.timePassed = new TimeSpan(0, 0, 0, 0, 0);
        }
    }
}
