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
        PenaltyAmount = 0m; //Because we don't know delay from the start
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
        string returnedText;

        if (IsReturned)
        {
            returnedText = ReturnDate.Value.ToShortDateString();
        }
        else
        {
            returnedText = "Not returned";
        }

        return $"{User.FullName} | {Equipment.Name} | Due: {DueDate.ToShortDateString()} | Returned: {returnedText} | Penalty: {PenaltyAmount:C}";
    }


}

