using System;

namespace Phone.CallManagement
{
    public class Call
    {
        private readonly DateTime date; //the date contains both date&time
        private readonly TimeSpan duration;
        private readonly string dialedPhoneNumber;

        public DateTime Date
        {
            get
            {
                return date;
            }
        }
        public TimeSpan Duration
        {
            get
            {
                return duration;
            }
        }
        public string DialedPhoneNumber
        {
            get
            {
                return dialedPhoneNumber;
            }
        }

        public Call(DateTime date, TimeSpan duration, string dialedNumber)
        {
            this.date = date;
            this.duration = duration;
            this.dialedPhoneNumber = dialedNumber;
        }
    }
}
