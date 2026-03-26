using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using APBD_cw2_s32570.AppData;
using APBD_cw2_s32570.Models;

namespace APBD_cw2_s32570.Services;

internal class ReportService
{
    private readonly SystemData _appData;
    private readonly RentalService _rentalService;

    public ReportService(SystemData appData, RentalService rentalService)
    {
        _appData = appData;
        _rentalService = rentalService;
    }

    public List<(string Label, string Value)> GenerateSummaryReportTable()
    {
        int totalUsers = _appData.Users.Count;
        int totalEquipment = _appData.Items.Count;
        int availableEquipment = CountEquipmentByStatus(EquipmentStatus.Available);
        int borrowedEquipment = CountEquipmentByStatus(EquipmentStatus.Borrowed);
        int unavailableEquipment = CountEquipmentByStatus(EquipmentStatus.Unavailable);
        int totalRentals = _appData.Rentals.Count;
        int activeRentals = CountActiveRentals();
        int overdueRentals = _rentalService.GetOverdueRentals().Count;
        decimal totalPenalties = CalculateTotalPenalties();

        List<(string Label, string Value)> rows = new List<(string Label, string Value)>();
        rows.Add(("Total users", totalUsers.ToString()));
        rows.Add(("Total equipment items", totalEquipment.ToString()));
        rows.Add(("Available equipment", availableEquipment.ToString()));
        rows.Add(("Borrowed equipment", borrowedEquipment.ToString()));
        rows.Add(("Unavailable equipment", unavailableEquipment.ToString()));
        rows.Add(("Total rentals", totalRentals.ToString()));
        rows.Add(("Active rentals", activeRentals.ToString()));
        rows.Add(("Overdue rentals", overdueRentals.ToString()));
        rows.Add(("Total penalties collected", totalPenalties.ToString("C")));

        return rows;
    }

    private int CountEquipmentByStatus(EquipmentStatus status)
    {
        int count = 0;

        foreach (Equipment equipment in _appData.Items)
        {
            if (equipment.Status == status)
            {
                count++;
            }
        }

        return count;
    }

    private int CountActiveRentals()
    {
        int count = 0;

        foreach (Rental rental in _appData.Rentals)
        {
            if (!rental.IsReturned)
            {
                count++;
            }
        }

        return count;
    }

    private decimal CalculateTotalPenalties()
    {
        decimal total = 0m;

        foreach (Rental rental in _appData.Rentals)
        {
            total += rental.PenaltyAmount;
        }

        return total;
    }

}
