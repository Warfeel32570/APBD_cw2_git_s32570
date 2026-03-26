using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_cw2_s32570.Services;

//Helper method for prettier output
public static class ConsolePrinter
{
    public static void PrintTitle(string title)
    {
        int width = Math.Max(title.Length + 6, 60);

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"╔{new string('═', width)}╗");
        Console.WriteLine($"║{title.PadLeft((width + title.Length) / 2).PadRight(width)}║");
        Console.WriteLine($"╚{new string('═', width)}╝");
        Console.ResetColor();
        Console.WriteLine();
    }

    public static void PrintSection(string title)
    {
        int width = Math.Max(title.Length + 6, 50);

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"╔{new string('═', width)}╗");
        Console.WriteLine($"║ {title.PadRight(width - 1)}║");
        Console.WriteLine($"╚{new string('═', width)}╝");
        Console.ResetColor();
    }

    public static void PrintMessage(string message, ConsoleColor color = ConsoleColor.White)
    {
        int width = Math.Max(message.Length + 6, 50);

        Console.ForegroundColor = color;
        Console.WriteLine($"╔{new string('═', width)}╗");
        Console.WriteLine($"║ {message.PadRight(width - 1)}║");
        Console.WriteLine($"╚{new string('═', width)}╝");
        Console.ResetColor();
        Console.WriteLine();
    }

    public static void PrintSuccess(string message)
    {
        PrintMessage(message, ConsoleColor.Green);
    }

    public static void PrintError(string message)
    {
        PrintMessage(message, ConsoleColor.Red);
    }

    public static void PrintList<T>(string title, List<T> items)
    {
        List<string> lines = new List<string>();
        lines.Add(title);
        lines.Add(new string('─', Math.Max(title.Length, 50)));

        if (items.Count == 0)
        {
            lines.Add("No items to display.");
        }
        else
        {
            for (int i = 0; i < items.Count; i++)
            {
                lines.Add($"{i + 1}. {items[i]}");
            }
        }

        PrintBox(lines, ConsoleColor.White);
    }

    public static void PrintSummaryTable(string title, List<(string Label, string Value)> rows)
    {
        int labelWidth = "Category".Length;
        int valueWidth = "Value".Length;

        foreach ((string Label, string Value) row in rows)
        {
            if (row.Label.Length > labelWidth)
            {
                labelWidth = row.Label.Length;
            }

            if (row.Value.Length > valueWidth)
            {
                valueWidth = row.Value.Length;
            }
        }

        labelWidth += 2;
        valueWidth += 2;

        string topBorder = $"╔{new string('═', labelWidth + 2)}╦{new string('═', valueWidth + 2)}╗";
        string middleBorder = $"╠{new string('═', labelWidth + 2)}╬{new string('═', valueWidth + 2)}╣";
        string bottomBorder = $"╚{new string('═', labelWidth + 2)}╩{new string('═', valueWidth + 2)}╝";

        int fullWidth = labelWidth + valueWidth + 7;

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"╔{new string('═', fullWidth - 2)}╗");
        Console.WriteLine($"║{title.PadLeft((fullWidth - 2 + title.Length) / 2).PadRight(fullWidth - 2)}║");
        Console.WriteLine(topBorder);

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"║ {"Category".PadRight(labelWidth)} ║ {"Value".PadRight(valueWidth)} ║");
        Console.WriteLine(middleBorder);

        Console.ForegroundColor = ConsoleColor.White;

        for (int i = 0; i < rows.Count; i++)
        {
            Console.WriteLine($"║ {rows[i].Label.PadRight(labelWidth)} ║ {rows[i].Value.PadRight(valueWidth)} ║");

            if (i < rows.Count - 1)
            {
                Console.WriteLine(middleBorder);
            }
        }

        Console.WriteLine(bottomBorder);
        Console.ResetColor();
        Console.WriteLine();
    }

    private static void PrintBox(List<string> lines, ConsoleColor color)
    {
        int longestLine = 0;

        foreach (string line in lines)
        {
            if (line.Length > longestLine)
            {
                longestLine = line.Length;
            }
        }

        int width = Math.Max(longestLine + 5, 50);

        Console.ForegroundColor = color;
        Console.WriteLine($"╔{new string('═', width)}╗");

        foreach (string line in lines)
        {
            Console.WriteLine($"║ {line.PadRight(width - 1)}║");
        }

        Console.WriteLine($"╚{new string('═', width)}╝");
        Console.ResetColor();
        Console.WriteLine();
    }
}
