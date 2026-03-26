using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_cw2_s32570.Models;

public class Employee : User
{
    public Employee(string firstName, string lastName) : base(firstName, lastName, UserType.Employee)
    {

    }
}
