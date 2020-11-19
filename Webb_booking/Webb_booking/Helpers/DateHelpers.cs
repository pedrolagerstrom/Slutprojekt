﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Webb_booking.Helpers
{
    public class DateHelpers : Controller
    {
        public static bool HasSharedDateIntervals(DateTime startDate1, DateTime endDate1, DateTime startDate2, DateTime endDate2)
        {
            if ((startDate1 > startDate2 && startDate1 < endDate2) || (endDate1 > startDate2 && endDate1 < endDate2))
            {
                return true;
            }
            else if ((startDate2 > startDate1 && startDate2 < endDate1) || (endDate2 > startDate1 && endDate2 < endDate1))
            {
                return true;
            }

            return false;
        }
    }
}
