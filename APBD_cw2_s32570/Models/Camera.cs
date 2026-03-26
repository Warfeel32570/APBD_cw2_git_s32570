using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_cw2_s32570.Models;

public class Camera : Equipment
{
    public int Megapixels { get; }
    public string Lens { get; }

    public Camera(string name, int megapixels, string lens) : base(name)
    {
        Megapixels = megapixels;
        Lens = lens;
    }

    public override string ToString()
    {
        return $"{base.ToString()} | Megapixels: {Megapixels} | Lens Type: {Lens}";
    }
}
