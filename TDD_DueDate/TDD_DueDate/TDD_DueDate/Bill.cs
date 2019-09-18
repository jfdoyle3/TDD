using System;

namespace PaymentDateCheck
{
    public class Bill
    {
        public Bill(IHolidayService mockHolidayService)
        {

        }
        //bring in holiday service to check for holidays
        //use dependency injection
        public DateTime CheckDate (DateTime dueDate)
        {
            // throw new NotImplementedException();
            return dueDate;
        }
    }

}

