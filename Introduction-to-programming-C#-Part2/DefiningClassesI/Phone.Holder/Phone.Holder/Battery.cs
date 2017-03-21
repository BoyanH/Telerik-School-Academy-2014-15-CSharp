using System;

namespace Phone.Handler
{
    public enum BatteryType
    {
        LiIon,
        NiMH,
        NiCd
    }

    public class Battery
    {
        private readonly string model;
        private double hoursIdle;
        private double hoursTalk;
        private BatteryType typeOfBattery;

        public string Model
        {
            get
            {
                return model;
            }
        }

        public double HoursIdle
        {
            get
            {
                return hoursIdle;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Hours can't be negative!");
                }
                else
                {
                    this.hoursIdle = value;
                }
            }
        }

        public double HoursTalk
        {
            get
            {
                return hoursTalk;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Hours can't be negative!");
                }
                else
                {
                    this.hoursTalk = value;
                }
            }
        }

        public BatteryType TypeOfBattery
        {
            get
            {
                return typeOfBattery;
            }
            set
            {
                this.typeOfBattery = value;
            }
        }

        public Battery()
        {

        }
        public Battery(string model)
        {
            this.model = model;
        }
        public Battery(string model, double hoursIdle)
            : this(model)
        {
            this.hoursIdle = hoursIdle;
        }
        public Battery(string model, double hoursIdle, double hoursTalk)
            : this(model, hoursIdle)
        {
            this.hoursTalk = hoursTalk;
        }
        public Battery(string model, double hoursIdle, double hoursTalk, BatteryType batteryType)
            : this(model, hoursIdle, hoursTalk)
        {
            this.typeOfBattery = batteryType;
        }

    }
}
