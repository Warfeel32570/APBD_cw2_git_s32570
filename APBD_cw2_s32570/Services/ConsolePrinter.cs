using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_cw2_s32570.Services;

public static class ConsolePrinter
{
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

        labelWidth += 5;
        valueWidth += 5;

        int tableWidth = labelWidth + valueWidth + 3;

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"╔{new string('═', tableWidth)}╗");
        Console.WriteLine($"║{title.PadLeft((tableWidth + title.Length) / 2).PadRight(tableWidth)}║");
        Console.WriteLine($"╠{new string('═', labelWidth)}╦{new string('═', valueWidth)}╣");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"║ {"Category".PadRight(labelWidth - 2)}║ {"Value".PadRight(valueWidth - 2)}║");
        Console.WriteLine($"╠{new string('═', labelWidth)}╬{new string('═', valueWidth)}╣");

        Console.ForegroundColor = ConsoleColor.White;

        for (int i = 0; i < rows.Count; i++)
        {
            Console.WriteLine($"║ {rows[i].Label.PadRight(labelWidth - 2)}║ {rows[i].Value.PadRight(valueWidth - 2)}║");

            if (i < rows.Count - 1)
            {
                Console.WriteLine($"╠{new string('═', labelWidth)}╬{new string('═', valueWidth)}╣");
            }
        }

        Console.WriteLine($"╚{new string('═', labelWidth)}╩{new string('═', valueWidth)}╝");
        Console.ResetColor();
    }
}
