using System;
using List;

namespace daysofweek_list
{
    class Program
    {
        static void Main(string[] args)
        {
            var daysOfWeek = new List<string>{
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday"
            };

            daysOfWeek.Add("Saturday");
            daysOfWeek.Add("Sunday");

        }
    }
}
