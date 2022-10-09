using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        public DateModifier(DateTime firstDate, DateTime secondDate)
        {
            FirstDate = firstDate;
            SecondDate = secondDate;
        }

        public DateTime FirstDate { get; set; }

        public DateTime SecondDate { get; set; }

        public void DayDifference(DateTime firstDate, DateTime secondDate)
        {
            var difference = secondDate - firstDate;
            int days = int.Parse(difference.Days.ToString());

            Console.WriteLine(Math.Abs(days));
        }
    }
}
