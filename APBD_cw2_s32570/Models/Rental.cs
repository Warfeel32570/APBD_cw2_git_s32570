using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_cw2_s32570.Models;

public class Rental
{
    public User User { get; }
    public Equipment Equipment { get; }
    public DateTime BorrowDate { get; }
    public DateTime DueDate { get; }
    public DateTime? ReturnDate { get; private set; }
    public decimal PenaltyAmount { get; private set; }
    
    public Rental(User user, Equipment equipment, DateTime borrowDate, DateTime dueDate)
    {
        User = user;
        Equipment = equipment;
        BorrowDate = borrowDate;
        DueDate = dueDate;
        ReturnDate = null;
        PenaltyAmount = 0m;
    }
    public bool IsReturned => ReturnDate.HasValue; 
    public bool IsOverdue => !IsReturned && DateTime.Today > DueDate.Date;

    public void MarkAsReturned(DateTime returnDate, decimal penaltyAmount)
    {
        ReturnDate = returnDate;
        PenaltyAmount = penaltyAmount;
    }

    public override string ToString()
    {
        string ReturnInfo = IsReturned ? ReturnDate!.Value.ToShortDateString() : "Item is not returned!";
        return $"User: {User.FullName}, Equipment: {Equipment.Name}, Borrowed: {BorrowDate.ToShortDateString()}, Due: {DueDate.ToShortDateString()}, Returned: {returnInfo}, Penalty: {PenaltyAmount:C}";
    }


}

