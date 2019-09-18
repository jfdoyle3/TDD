using System;
using System.Collections.Generic;

namespace PaymentDateCheck
{
    public class HolidayService <T>: IHolidayService
    {
        public bool isHoliday (DateTime dueDate)
        {
            var holidays = new List<DateTime>
            {
                new DateTime(2019, 12, 25),
                new DateTime(2019, 8, 3),
                new DateTime(2019, 9,23)
            };
            if (holidays.Contains(dueDate))
                return true;

            return false;
        }
    }
}