using APBD_cw2_s32570.Models;
using APBD_cw2_s32570.Services;
using APBD_cw2_s32570.AppData;


SystemData appData = new SystemData();
UserService userService = new UserService(appData);
EquipmentService equipmentService = new EquipmentService(appData);
RentalService rentalService = new RentalService(appData, userService, equipmentService);
ReportService reportService = new ReportService(appData, rentalService);

Console.OutputEncoding = System.Text.Encoding.UTF8;

ConsolePrinter.PrintTitle("UNIVERSITY EQUIPMENT RENTAL SYSTEM");

Student student1 = new Student("Anna", "Nowak");
Student student2 = new Student("Piotr", "Zieliński");
Student student3 = new Student("Maria", "Wiśniewska");
Student student4 = new Student("Tomasz", "Lewandowski");
Employee employee1 = new Employee("Jan", "Kowalski");
Employee employee2 = new Employee("Katarzyna", "Wójcik");
Employee employee3 = new Employee("Michał", "Kamiński");

userService.AddUser(student1);
userService.AddUser(student2);
userService.AddUser(employee1);
userService.AddUser(student3);
userService.AddUser(student4);
userService.AddUser(employee2);
userService.AddUser(employee3);

Laptop laptop1 = new Laptop("Dell Latitude 5520", 16, "Windows 11");
Laptop laptop2 = new Laptop("Lenovo ThinkPad T14", 8, "Windows 10");
Laptop laptop3 = new Laptop("HP ProBook 450", 16, "Windows 11");
Laptop laptop4 = new Laptop("Acer Aspire 5", 8, "Windows 10");
Laptop laptop5 = new Laptop("MacBook Air M1", 8, "macOS");

Projector projector1 = new Projector("Epson EB-X06", "1920x1080", 3600);
Projector projector2 = new Projector("BenQ MX560", "1280x800", 4000);
Projector projector3 = new Projector("ViewSonic PA503S", "800x600", 3600);

Camera camera1 = new Camera("Canon EOS 250D", 24, "Zoom");
Camera camera2 = new Camera("Nikon D3500", 20, "Standard");
Camera camera3 = new Camera("Sony Alpha A6000", 24, "Zoom");
Camera camera4 = new Camera("Panasonic Lumix G7", 16, "Wide-angle");
Camera camera5 = new Camera("Fujifilm X-T200", 24, "Standard");
Camera camera6 = new Camera("Olympus OM-D E-M10", 16, "Portrait");
Camera camera7 = new Camera("Canon PowerShot G7 X", 20, "Compact zoom");


equipmentService.AddEquipment(laptop1);
equipmentService.AddEquipment(laptop2);
equipmentService.AddEquipment(laptop3);
equipmentService.AddEquipment(laptop4);
equipmentService.AddEquipment(laptop5);

equipmentService.AddEquipment(projector1);
equipmentService.AddEquipment(projector2);
equipmentService.AddEquipment(projector3);

equipmentService.AddEquipment(camera1);
equipmentService.AddEquipment(camera2);
equipmentService.AddEquipment(camera3);
equipmentService.AddEquipment(camera4);
equipmentService.AddEquipment(camera5);
equipmentService.AddEquipment(camera6);
equipmentService.AddEquipment(camera7);

ConsolePrinter.PrintList("USERS", userService.GetAllUsers());
ConsolePrinter.PrintList("ALL EQUIPMENT", equipmentService.GetAllEquipment());
ConsolePrinter.PrintList("AVAILABLE EQUIPMENT", equipmentService.GetAvailableEquipment());

ConsolePrinter.PrintSection("CORRECT BORROW OPERATION");

bool borrow1 = rentalService.BorrowEquipment(student1.ID, laptop1.ID, DateTime.Today, out string borrowMessage1);
PrintOperationResult(borrow1, borrowMessage1);

ConsolePrinter.PrintSection("INCORRECT OPERATION - BORROWING ALREADY BORROWED EQUIPMENT");

bool borrow2 = rentalService.BorrowEquipment(student2.ID, laptop1.ID, DateTime.Today, out string borrowMessage2);
PrintOperationResult(borrow2, borrowMessage2);

ConsolePrinter.PrintSection("CORRECT BORROW OPERATION - SECOND USER");

bool borrow3 = rentalService.BorrowEquipment(employee1.ID, projector1.ID, DateTime.Today, out string borrowMessage3);
PrintOperationResult(borrow3, borrowMessage3);

ConsolePrinter.PrintSection("INCORRECT OPERATION - EXCEEDING STUDENT LIMIT");

bool borrow4 = rentalService.BorrowEquipment(student1.ID, laptop2.ID, DateTime.Today, out string borrowMessage4);
PrintOperationResult(borrow4, borrowMessage4);

bool borrow5 = rentalService.BorrowEquipment(student1.ID, camera1.ID, DateTime.Today, out string borrowMessage5);
PrintOperationResult(borrow5, borrowMessage5);

bool borrow6 = rentalService.BorrowEquipment(student1.ID, camera2.ID, DateTime.Today, out string borrowMessage6);
PrintOperationResult(borrow6, borrowMessage6);

ConsolePrinter.PrintList("ACTIVE RENTALS OF ANNA NOWAK", rentalService.GetActiveRentalsForUser(student1.ID));
ConsolePrinter.PrintList("ALL EQUIPMENT AFTER BORROWING", equipmentService.GetAllEquipment());

ConsolePrinter.PrintSection("ON-TIME RETURN");

bool return1 = rentalService.ReturnEquipment(laptop1.ID, DateTime.Today.AddDays(3), out string returnMessage1);
PrintOperationResult(return1, returnMessage1);

ConsolePrinter.PrintSection("LATE RETURN WITH PENALTY");

bool return2 = rentalService.ReturnEquipment(projector1.ID, DateTime.Today.AddDays(10), out string returnMessage2);
PrintOperationResult(return2, returnMessage2);

ConsolePrinter.PrintSection("INCORRECT RETURN OPERATION");

bool return3 = rentalService.ReturnEquipment(camera2.ID, DateTime.Today, out string returnMessage3);
PrintOperationResult(return3, returnMessage3);

ConsolePrinter.PrintList("ALL RENTALS", rentalService.GetAllRentals());
ConsolePrinter.PrintList("AVAILABLE EQUIPMENT AFTER RETURNS", equipmentService.GetAvailableEquipment());
ConsolePrinter.PrintList("OVERDUE RENTALS", rentalService.GetOverdueRentals());

ConsolePrinter.PrintSummaryTable(
    "RENTAL SYSTEM SUMMARY REPORT",
    reportService.GenerateSummaryReportTable());

ConsolePrinter.PrintMessage("Demo completed successfully.", ConsoleColor.Cyan);

static void PrintOperationResult(bool success, string message)
{
    if (success)
    {
        ConsolePrinter.PrintSuccess(message);
    }
    else
    {
        ConsolePrinter.PrintError(message);
    }
}