namespace ASP.NET_MVC_SimpleApp.Models
{
    using System;
    using System.ComponentModel;

    public static class EnumHelperExtension
    {
        public static string ToDescription(this Enum value)
        {
            var description = (DescriptionAttribute[])value
                .GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (description.Length > 0)
            {
                //If a description was found (or more than one) return the 1st
                return description[0].Description;
            }

            //else, return the enumeration.ToString()S
            return value.ToString();
        }
    }
}