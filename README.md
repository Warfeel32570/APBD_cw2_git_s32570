# s32570
# University Equipment Rental System

## Description
A C# console application for managing university equipment rentals.

The system allows:
- adding users and equipment
- borrowing and returning equipment
- blocking invalid operations
- calculating penalties for late returns
- generating a short summary report

---

## How to run
Requirements:
- .NET 8
- Visual Studio 2022 or terminal

Run in terminal:

```bash
dotnet build
dotnet run
```

Service is devided into 3 logical parts:
-------------------------------------------------------------------------------------------------
## AppData
stores all application data in memory.

It contains: List<Users>, List<Items>, List<Rentals>
# Why: 
simple solution for a console project, no database required, keeps data in one shared place
-------------------------------------------------------------------------------------------------

## Models
contains the domain classes.

# Equipment
Base abstract class for all equipment.
Stores: Id, Name, Status
# Methods:
MarkAsBorrowed()
MarkAsAvailable()
MarkAsUnavailable()

# Equipment --> Laptop / Projector / Camera
Each type has its own specific fields:
Laptop → RamGb, OperatingSystem
Projector → Resolution, Lumens
Camera → Megapixels, LensType

-------------------------------------------

# User --> Student / Employee
Base abstract class for users.
Stores: ID, FirstName, LastName, UserType

-------------------------------------------
# Rental
Represents one rental operation.
Stores: user, equipment, borrow date, due date, return date, penalty amount
# Methods:
MarkAsReturned() -- returnes item to list with available items
ToString()
-------------------------------------------------------------------------------------------------
This model structure was chosen because shared data is placed in base classes and specific data is placed in derived classes, which supports incapsulation principles. Rental is separate to keep rental history.
-------------------------------------------------------------------------------------------------

## Services
contains business logic.

# BorrowingPolicy
Defines rental rules:
student → max 2 active rentals
employee → max 5 active rentals
rental period → 7 days

# PenaltyCalculator
Calculates penalty for late return.

# UserService
Handles user operations: add new user, get all users, get user by id

# EquipmentService
Handles operations, such as: add item, get all equipment, get available equipment, get equipment,by id, mark equipment as unavailable

# RentalService
Handles operations, such as: borrow equipment, return equipment, get active rentals for user, get overdue rentals, get all rentals
-------------------------------------------------------------------------------------------------
I wanted to keep business logic is separated from models, make sure Program.cs stays simple -->
easier to read and maintain
-------------------------------------------------------------------------------------------------

# ReportService
Generates the final summary report.

# ConsolePrinter
Formats console output.