using System;
using System.Globalization;

namespace Date.Calculator
{
    public class CalculateDiff
    {

        static TimeSpan GetDiffBetweenDates(DateTime fDate, DateTime sDate)
        {

            return sDate.Subtract(fDate); //result is already in days.h:m:s
        }

        public static void Main()
        {
            DateTime fDate = DateTime.Now; //will be changed later if no parse error
            DateTime sDate = DateTime.Now;
            bool err = false;

            Console.WriteLine("Enter dd/mm/yyyy formated 2 dates to get difference in days between them!\n");
            Console.Write("Date One: ");
            string fDateString = Console.ReadLine();
            Console.Write("Date Two: ");
            string sDateString = Console.ReadLine();

            try
            {
                fDate = DateTime.ParseExact(fDateString, "dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);
                sDate = DateTime.ParseExact(sDateString, "dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);
            }
            catch
            {
                Console.WriteLine("Invalid Date(s)!");
                err = true;
            }

            if (!err)
            {
                TimeSpan diffInDays = GetDiffBetweenDates(fDate, sDate);
                Console.WriteLine("Number of days between dates: {0:%d} day(s)", diffInDays); //%d gives days only from otherwise days.hour:minute:second format
            }
        }
    }
}
