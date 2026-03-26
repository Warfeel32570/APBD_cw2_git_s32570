using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_cw2_s32570.Models;

public class Projector : Equipment
{
    public string Resolution { get; }
    public int Lumens { get; }

    public Projector(string name, string resolution, int lumens) : base(name)
    {
        Resolution = resolution;
        Lumens = lumens;
    }

    public override string ToString()
    {
        return $"{base.ToString()} | Resolution: {Resolution} | Lumens: {Lumens}";

    }
}
