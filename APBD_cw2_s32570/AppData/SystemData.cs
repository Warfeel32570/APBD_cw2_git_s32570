using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using APBD_cw2_s32570.Models;

namespace APBD_cw2_s32570.AppData;

public class SystemData
{
    public List<User> Users { get; } = new();
    public List<Equipment> Items { get; } = new();
    public List<Rental> Rentals { get; } = new();
}
