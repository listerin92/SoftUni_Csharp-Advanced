using System;
using System.Linq;

namespace DefiningClasses
{
    public class DateModifier
    {
        public string CalculateDifference(string dateOne, string dateTwo)
        {

            int[] dateSplit = dateOne.Split().Select(int.Parse).ToArray();
            var year = dateSplit[0];
            var month = dateSplit[1];
            var day = dateSplit[2];
            DateTime dateOneDT = new DateTime(year, month, day);

            dateSplit = dateTwo.Split().Select(int.Parse).ToArray();
            year = dateSplit[0];
            month = dateSplit[1];
            day = dateSplit[2];
            DateTime dateTwoDT = new DateTime(year, month, day);
            TimeSpan difference = dateTwoDT - dateOneDT;

            return Math.Abs(difference.Days).ToString();
        }
    }
}
