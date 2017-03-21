namespace ASP.NET_MVC_SimpleApp.Models
{

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Mvc;

    public class BitCalculator
    {

        private List<KeyValuePair<string, double>> conversions;

        //Declare selection lists for the UI part
        private List<SelectListItem> measureTypeSelection = new List<SelectListItem>();
        private List<SelectListItem> kiloSelection = new List<SelectListItem>();

        private class ConversionMultiplier
        {
            //yte to it => byte to kilobit, kilobyte to megabit ... etc.
            //it to yte => bit to byte, kilobit to kilobyte ... etc.


            //decimal => Kilo = 1000
            public const double decimalYteToIt = 0.008;  //=1/125
            public const double decimalItToYte = 0.125; //=1/8

            //binary => Kilo = 1024

            public const double binaryYtetoIt = 0.0078125; //=1/128
            public const double binaryItToYte = 0.125;    //=1/8

        }

        public BitCalculator()
        {
            this.SelectedUnitType = "5"; //Megabyte
            this.SelectedAmount = 1; //1MB
            this.SelectedKilo = 1024; //binary

            //Load the selections lists for the UI
            LoadKiloSelection();
            LoadSizeSuffixesSelection();
            CalculateConversions();
        }

        public double SelectedAmount { get; set; }
        public string SelectedUnitType { get; set; }
        public int SelectedKilo { get; set; }
        public List<KeyValuePair<string, double>> Conversions
        {
            get
            {
                return this.conversions;
            }
        }
        public IEnumerable<SelectListItem> MeasureTypeSelection
        {
            get
            {
                return this.measureTypeSelection;
            }
        }

        public IEnumerable<SelectListItem> KiloTypeSelection
        {
            get
            {
                return this.kiloSelection;
            }
        }

        public void CalculateConversions()
        {

            this.conversions = new List<KeyValuePair<string, double>>();

            int nthSelectedUnitType = int.Parse(this.SelectedUnitType);
            SizeSuffixes selectedUnitType = (SizeSuffixes)nthSelectedUnitType;

            this.conversions.Add(new KeyValuePair<string, double>(selectedUnitType.ToDescription(), this.SelectedAmount) );

            double tempResult = this.SelectedAmount;
            int len = Enum.GetValues(typeof(SizeSuffixes)).Length;
            for (int i = nthSelectedUnitType + 1; i < len; i++)
            {
                if (this.SelectedKilo == 1000)
                {
                    tempResult *= i % 2 == 0 ?
                                ConversionMultiplier.decimalYteToIt :
                                ConversionMultiplier.decimalItToYte;

                }
                else if (this.SelectedKilo == 1024)
                {
                    tempResult *= i % 2 == 0 ?
                                ConversionMultiplier.binaryYtetoIt : 
                                ConversionMultiplier.binaryItToYte;
                }

                this.conversions.Add( new KeyValuePair<string, double>( ((SizeSuffixes)i).ToDescription(), tempResult ) );
            }

            tempResult = this.SelectedAmount;
            for (int i = nthSelectedUnitType - 1; i >= 0; i--)
            {
                if (this.SelectedKilo == 1000)
                {
                    
                        tempResult /= i % 2 == 0 ?
                            ConversionMultiplier.decimalItToYte :
                            ConversionMultiplier.decimalYteToIt;
                }
                else if (this.SelectedKilo == 1024)
                {
                    tempResult /= i % 2 == 0 ?
                            ConversionMultiplier.binaryItToYte :
                            ConversionMultiplier.binaryYtetoIt;
                }

                this.conversions.Insert(0, new KeyValuePair<string, double>(((SizeSuffixes)i).ToDescription(), tempResult) );
            }

        }

        private void LoadKiloSelection()
        {
            this.kiloSelection = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text="1000",
                    Value = "1000"
                },
                new SelectListItem
                {
                    Text = "1024",
                    Value = "1024"
                }
            };
        }

        private void LoadSizeSuffixesSelection()
        {
            for (int i = 0; i < Enum.GetValues(typeof(SizeSuffixes)).Length; i++)
            {
                var description = ((SizeSuffixes)i).ToDescription();
                this.measureTypeSelection.Add(
                    new SelectListItem
                    {
                        Text = description,
                        Value = (i).ToString()
                    });
            }
        }
    }
}