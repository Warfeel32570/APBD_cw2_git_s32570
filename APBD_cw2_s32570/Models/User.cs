using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_cw2_s32570.Models;

public abstract class User
{
    private static int _nextID = 1;
    public int ID { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public UserType userType { get; }

    protected User(string firstName, string lastName, UserType Usertype)
    {
        ID = _nextID++;
        FirstName = firstName;
        LastName = lastName;
        userType = Usertype; 
    }

    public string FullName => $"{FirstName} {LastName}";

    public override string ToString()
    {
        return $"ID: {ID} | Name: {FullName} | Type: {userType}";
    }

}

