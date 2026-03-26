using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

using APBD_cw2_s32570.AppData;
using APBD_cw2_s32570.Models;

namespace APBD_cw2_s32570.Services;

public class RentalService
{
    private readonly SystemData _appData;
    private readonly UserService _userService;
    private readonly EquipmentService _equipmentService;

    public RentalService(SystemData appData, UserService userService, EquipmentService equipmentService)
    {
        _appData = appData;
        _userService = userService;
        _equipmentService = equipmentService;
    }

    public bool BorrowEquipment(int userId, int equipmentId, DateTime borrowDate, out string message)
    {
        User? user = _userService.GetUsersByID(userId);
        if (user == null)
        {
            message = "User not found.";
            return false;
        }

        //Concrete Item
        Equipment? item = _equipmentService.GetEquipmentById(equipmentId);
        if (item == null)
        {
            message = "Item not found.";
            return false;
        }

        if(item.Status == EquipmentStatus.Unavailable)
        {
            message = "Item is unavailable.";
            return false;
        }

        if(item.Status == EquipmentStatus.Borrowed)
        {
            message = "Item is borrowed by someone else.";
            return false;
        }

        int ActiveRentalsCount = GetActiveRentalsForUser(userId).Count;
        int maxActiveRentals = BorrowingPolicy.GetMaxActiveRentals(user);

        if (ActiveRentalsCount >= maxActiveRentals)
        {
            message = "User has reached the rental limit!";
            return false;
        }

        //Calculate the due date --> penalty
        DateTime dueDate = borrowDate.AddDays(BorrowingPolicy.GetMaxRentalDays());
        Rental rental = new Rental(user, item, borrowDate, dueDate);

        _appData.Rentals.Add(rental);
        item.MarkedAsBorrowed();

        message = "Item was borrowed successfully";
        return true;
    }

    public bool ReturnEquipment(int equipmentId, DateTime returnDate, out string message)
    {
        Rental? activeRental = GetActiveRentalByEquipmentId(equipmentId);

        if (activeRental == null)
        {
            message = "No active rental found for this equipment.";
            return false;
        }

        decimal penalty = PenaltyCalculator.CalculatePenalty(activeRental, returnDate);

        activeRental.MarkAsReturned(returnDate, penalty);
        activeRental.Equipment.MarkedAsAvailable();

        if (penalty > 0)
        {
            message = $"Equipment returned successfully. Penalty: {penalty:C}";
            return true;
        }

        message = "Equipment returned successfully. No penalty.";
        return true;
    }

    public List<Rental> GetActiveRentalsForUser(int userId)
    {
        List<Rental> activeRentals = new List<Rental>();

        foreach (Rental rental in _appData.Rentals)
        {
            if (rental.User.ID == userId && !rental.IsReturned)
            {
                activeRentals.Add(rental);
            }
        }

        return activeRentals;
    }

    public List<Rental> GetOverdueRentals()
    {
        List<Rental> overdueRentals = new List<Rental>();

        foreach (Rental rental in _appData.Rentals)
        {
            if (rental.IsOverdue)
            {
                overdueRentals.Add(rental);
            }
        }

        return overdueRentals;
    }

    public List<Rental> GetAllRentals()
    {
        return _appData.Rentals;
    }

    private Rental? GetActiveRentalByEquipmentId(int equipmentId)
    {
        foreach (Rental rental in _appData.Rentals)
        {
            if (rental.Equipment.ID == equipmentId && !rental.IsReturned)
            {
                return rental;
            }
        }

        return null;
    }

}



