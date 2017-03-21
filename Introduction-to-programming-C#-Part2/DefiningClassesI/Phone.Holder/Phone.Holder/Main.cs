using System;
using Phone.Handler;
using System.Globalization;
using System.Threading;

public class AppStart
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        //for the price to be displayed correctly we set bulgarian culture
        Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");
        Thread.CurrentThread.CurrentUICulture = new CultureInfo("bg-BG");

        var battery = new Battery("MegaBattery", 48, 10, BatteryType.LiIon);
        var display = new Display(15.6, 99999999);
        var prestigio = new GSM("PAP4055DUO", "Prestigio", 150, "Boco", battery, display);
        var phoneWithMinSpecs = new GSM("someModel", "someManufacturer");
        var basicPhone = new GSM("Nokia", "TANK", 20, "Grandpa");
        var iphone = GSM.IPhone4S;
        iphone.Owner = "NotMe";

        GSM[] listOfPhones = new GSM[] {prestigio, phoneWithMinSpecs, basicPhone, iphone};

        for (int phone = 0; phone < listOfPhones.Length; phone++)
        {
            Console.WriteLine(new string('-', 70));
            Console.WriteLine(listOfPhones[phone].ToString());
            Console.WriteLine(new string('-', 70));
        }

        Console.WriteLine("Static property iPhone4S: \n{0}", GSM.IPhone4S);

        //LAST TASK (I use the already created phone prestigio)

        //add a few calls
        prestigio.AddCall(DateTime.Now, new TimeSpan(0, 0, 2, 12), "08827102xx");
        prestigio.AddCall(new DateTime(2014, 12, 23, 12, 22, 31), new TimeSpan(0,0,1,30), "08827103xx");
        prestigio.AddCall(new DateTime(2014, 12, 22, 21, 22, 31), new TimeSpan(0, 0, 4, 12), "08827104xx");

        //Display info about the calls in the call history
        foreach (var call in prestigio.CallHistory)
        {
            Console.WriteLine("Call: Date&Time: {0}, Duration: {1}, dialedPhoneNumber: {2}",
                call.Date, call.Duration, call.DialedPhoneNumber);
        }

        //Calculate the total price of all calls
        Console.WriteLine("Total price in all call in history: {0}", prestigio.CalculateTotalCallCost(0.37m));


        TimeSpan crntMaxDuration = new TimeSpan(0,0,0,0);
        int maxIndex = -1;
        for (var call = 0; call < prestigio.CallHistory.Count; call++)
        {

            if (prestigio.CallHistory[call].Duration > crntMaxDuration)
            {
                crntMaxDuration = prestigio.CallHistory[call].Duration;
                maxIndex = call;
            }
        }
        prestigio.DeleteCall(prestigio.CallHistory[maxIndex].Date); //remove by date, because only 1 call has this date, its unique like an ID

        //Display calls after deletion
        Console.WriteLine("After the longest call has been deleted, calls are: \n{0}\n", new string('-', 70));
        foreach (var call in prestigio.CallHistory)
        {
            Console.WriteLine("Call: Date&Time: {0}, Duration: {1}, dialedPhoneNumber: {2}",
                call.Date, call.Duration, call.DialedPhoneNumber);
        }

        prestigio.DeleteCallHistory();
        Console.WriteLine("After callHistory has been cleared, all calls are: ");
        foreach (var call in prestigio.CallHistory)
        {
            Console.WriteLine("Call: Date&Time: {0}, Duration: {1}, dialedPhoneNumber: {2}",
                call.Date, call.Duration, call.DialedPhoneNumber);
        }
    }
}
