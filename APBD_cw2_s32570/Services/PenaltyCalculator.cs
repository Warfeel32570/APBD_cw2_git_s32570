using APBD_cw2_s32570.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_cw2_s32570.Services;

//Helper classies don't need to store obj state --> static
public static class PenaltyCalculator
{
    private const decimal DailyPenalty = 2.00m;

    public static decimal CalculatePenalty(Rental rental, DateTime returnDate)
    {
        if (returnDate.Date <= rental.DueDate.Date)
        {
            return 0m;
        }

        int lateDays = (returnDate.Date - rental.DueDate.Date).Days;
        return lateDays * DailyPenalty;
    }
}
