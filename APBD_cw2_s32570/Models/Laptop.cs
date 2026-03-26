using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_cw2_s32570.Models;

public class Laptop : Equipment
{

    public int RamGB { get; }
    public string OperatingSystem { get; }
    public Laptop(string name, int ramGB, string OS) : base(name)
    {
        RamGB = ramGB;
        OperatingSystem = OS; 
    }

    public override string ToString()
    {
        return $"{base.ToString()} | RAM: {RamGB} GB | OS: {OperatingSystem}";
    }
}
