using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

using APBD_cw2_s32570.AppData;
using APBD_cw2_s32570.Models;

namespace APBD_cw2_s32570.Services;

public class UserService
{
    private readonly SystemData _appData;

    public UserService(SystemData appData)
    {
        _appData = appData;
    }

    public void AddUser(User user)
    {
        _appData.Users.Add(user);
    }

    public List<User> GetAllUsers()
    {
        return _appData.Users;
    }

    public User? GetUsersByID(int userID)
    {
        foreach (User user in _appData.Users)
        {
            if (user.ID == userID) return user;
        }
        return null;
    }
}
