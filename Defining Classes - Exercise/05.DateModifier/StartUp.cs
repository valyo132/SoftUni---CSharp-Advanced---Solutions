using System;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] firstDateInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] secondDateInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            var date1 = new DateTime(firstDateInput[0], firstDateInput[1], firstDateInput[2]);
            var date2 = new DateTime(secondDateInput[0], secondDateInput[1], secondDateInput[2]);

            var newDate = new DateModifier(date1, date2);

            newDate.DayDifference(date1, date2);
        }
    }
}
