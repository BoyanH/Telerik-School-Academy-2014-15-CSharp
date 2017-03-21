using System;
using System.Globalization;

namespace Date.After
{
    public class PrintAfter
    {
        static void PrintDateAfter(DateTime date, TimeSpan after)
        {

            DateTime afterDate = date.Add(after); //result is already in days.h:m:s

            Console.WriteLine("The date, 6.5 hours after {0} is: {1}", date, afterDate);
            Console.WriteLine("That would be {0}!", afterDate.DayOfWeek);
        }

        public static void Main()
        {
            // Set culture to bg-BG.
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture("bg-BG");
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.CreateSpecificCulture("bg-BG");

            DateTime inputDate = DateTime.Now; //will be changed later if no parse error
            TimeSpan after = new TimeSpan(0, 6, 30, 0); //0 days, 6 hours, 30 minutes, 0 seconds
            bool err = false;

            Console.WriteLine("Enter dd.MM.yyyy hh:mm:ss formated date to get the date 6,5 hours later + day of week!\n");
            Console.Write("Date: ");
            string dateString = Console.ReadLine();

            try
            {
                inputDate = DateTime.ParseExact(dateString, "dd.MM.yyyy hh:mm:ss", DateTimeFormatInfo.InvariantInfo); //Bulgarian DateTime
            }
            catch
            {
                Console.WriteLine("Invalid Date!");
                err = true;
            }

            if (!err)
            {
                PrintDateAfter(inputDate, after);
            }
        }
    }
}
