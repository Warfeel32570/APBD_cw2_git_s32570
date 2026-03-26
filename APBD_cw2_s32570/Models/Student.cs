using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_cw2_s32570.Models;

public class Student : User
{
    public Student(string firstName, string lastName) : base(firstName,lastName, UserType.Student)
    {

    }
}
