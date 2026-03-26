using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using APBD_cw2_s32570.AppData;
using APBD_cw2_s32570.Models;

namespace APBD_cw2_s32570.Services;

public class EquipmentService
{
    private readonly SystemData _appData;

    public EquipmentService(SystemData appData)
    {
        _appData = appData;
    }

    public void AddEquipment(Equipment equipment)
    {
        _appData.Items.Add(equipment);
    }

    public List<Equipment> GetAllEquipment()
    {
        return _appData.Items;
    }

    public List<Equipment> GetAvailableEquipment()
    {
        List<Equipment> availableEquipment = new List<Equipment>();
        
        //adds avalable items to a new list
        foreach (Equipment equipment in _appData.Items)
        {
            if (equipment.Status == EquipmentStatus.Available)
            {
                availableEquipment.Add(equipment);
            }
        }

        return availableEquipment;
    }

    public Equipment? GetEquipmentById(int id)
    {
        foreach (Equipment equipment in _appData.Items)
        {
            if (equipment.ID == id)
            {
                return equipment;
            }
        }

        return null;
    }

    public bool MarkItemAsUnavailable(int id)
    {
        Equipment? equipment = GetEquipmentById(id);

        if (equipment == null)
        {
            return false;
        }

        equipment.MarkAsUnavailable();
        return true;
    }
}
