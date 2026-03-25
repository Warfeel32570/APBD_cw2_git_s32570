using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_cw2_s32570.Models;

public abstract class Equipment
{
    //unikatowy id dla każdego kolejnego dodawanago obj
    private static int _nextID = 1;
    public int ID { get; }
    //inne klasy --> read, set --> only methods w Equipment
    public string Name { get; private set; }

    public EquipmentStatus Status {get; private set;}

    protected Equipment(string name)
    {
        ID = _nextID++;
        Name = name;
        Status = EquipmentStatus.Available; //by default, untill change
    }

    //Status switch:
    public void MarkedAsBorrowed()
    {
        Status = EquipmentStatus.Borrowed;
    }

    public void MarkedAsAvailable()
    {
        Status = EquipmentStatus.Available;
    }

    public void MarkAsUnavailable()
    {
        Status = EquipmentStatus.Unavailable;
    }

    public void Rename(string NewName)
    {
        Name = NewName;
    }

    public override string ToString()
    {
        return $"ID: {ID} | Name: {Name} | Status: {Status}.";
    }
}
