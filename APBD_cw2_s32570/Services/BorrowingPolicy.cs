using APBD_cw2_s32570.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_cw2_s32570.Services;

public static class BorrowingPolicy
{
    //For both types of users
    public static int GetMaxActiveRentals(User user)
    {
        if(user.userType == UserType.Student)
        {
            return 2;
        }
        return 5;
    }

    public static int GetMaxRentalDays()
    {
        return 7;
    }
}
