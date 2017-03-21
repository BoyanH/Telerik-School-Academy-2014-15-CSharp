using System;
using System.Text;
using System.Collections.Generic;
using Phone.CallManagement;

namespace Phone.Handler
{
    public class GSM
    {
        private readonly string model;
        private readonly string manufacturer;
        private Nullable<decimal> price;
        private string owner;
        private Battery battery = new Battery();
        private Display display = new Display();
        private List<Call> callHistory;
        private static GSM iPhone4S;

        public string Model
        {
            get
            {
                return model;
            }
        }

        public string Manufacturer
        {
            get
            {
                return manufacturer;
            }
        }

        public Nullable<decimal> Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid Price!");
                }
                else
                {
                    this.price = value;
                }
            }
        }

        public string Owner
        {
            get
            {
                return owner;
            }
            set
            {
                owner = value;
            }
        }

        public Display Display
        {
            get
            {
                return display;
            }
            set
            {
                this.display = value;
            }
        }

        public Battery Battery
        {
            get
            {
                return battery;
            }
            set
            {
                this.battery = value;
            }
        }

        public List<Call> CallHistory
        {
            get
            {
                return callHistory;
            }
        }

        public static GSM IPhone4S
        {
            get
            {
                return iPhone4S;
            }
        }

        public GSM(string model, string manufacturer)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.callHistory = new List<Call>();
        }

        public GSM(string model, string manufacturer, decimal price)
            : this(model, manufacturer)
        {
            this.price = price;
        }

        public GSM(string model, string manufacturer, decimal price, string owner)
            : this(model, manufacturer, price)
        {
            this.owner = owner;
        }

        public GSM(string model, string manufacturer, decimal price, string owner, Battery battery)
            : this(model, manufacturer, price, owner)
        {
            this.battery = battery;
        }

        public GSM(string model, string manufacturer, decimal price, string owner, Battery battery, Display display)
            : this(model, manufacturer, price, owner, battery)
        {
            this.display = display;
        }

        static GSM()
        {
            iPhone4S = new GSM("Iphone 4S", "Apple", 600, "", new Battery("Iphone's battery", 20, 5, BatteryType.LiIon), new Display (3.5, 2000000));
        }

        public void AddCall(DateTime date, TimeSpan duration, string dialedNumber)
        {
            this.callHistory.Add(new Call(date, duration, dialedNumber));
        }

        public void DeleteCall(DateTime date) //date is unique, could be used like ID
        {
            for (int call = 0; call < this.callHistory.Count; call++)
            {
                if (this.callHistory[call].Date == date)
                {
                    this.callHistory.RemoveAt(call);
                }
            }
        }

        public void DeleteCallHistory()
        {
            this.callHistory.Clear();
        }

        public decimal CalculateCallCost(DateTime date, decimal pricePerMin)
        {
            for (int call = 0; call < this.callHistory.Count; call++)
            {
                if (this.callHistory[call].Date == date)
                {
                    return Convert.ToDecimal(this.callHistory[call].Duration.TotalMinutes) * pricePerMin;
                }
            }

            return 0;
        }

        public decimal CalculateTotalCallCost(decimal pricePerMin)
        {
            decimal totalCost = 0;

            foreach (var call in this.callHistory)
            {
                totalCost += Convert.ToDecimal(call.Duration.TotalMinutes) * pricePerMin;
            }

            return totalCost;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(string.Format("GSM Model: {0}", Model));
            sb.Append(Environment.NewLine);
            sb.Append(string.Format("GSM Manufacturer: {0}", Manufacturer));
            sb.Append(Environment.NewLine);
            sb.Append(string.Format("GSM Price: {0:C2}", Price));
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append(string.Format("Battery Model: {0}", Battery.Model));
            sb.Append(Environment.NewLine);
            sb.Append(string.Format("Battery Type: {0}", Battery.TypeOfBattery));
            sb.Append(Environment.NewLine);
            sb.Append(string.Format("Battery Idle Duration: {0} hours",Battery.HoursIdle ));
            sb.Append(Environment.NewLine);
            sb.Append(string.Format("Battery Talk Duration: {0} hours", Battery.HoursTalk));
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append(string.Format("Display Size: {0}\"", Display.Size));
            sb.Append(Environment.NewLine);
            sb.Append(string.Format("Display Colors: {0}M", Display.NumberOfColors));
            sb.Append(Environment.NewLine);
            sb.Append(string.Format("GSM Owner: {0}", Owner));
            sb.Append(Environment.NewLine);

            return sb.ToString();
        }
    }
}
