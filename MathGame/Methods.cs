using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame;

public static class Methods
{
    /// <summary>
    /// Greet user and show menu
    /// </summary>
    public static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to Math Game!");
        Console.WriteLine("Here you will pick the type of operation you want to answer.");
        Console.WriteLine("You will be asked to select difficulty and number of questions.");
        Console.WriteLine("Select from the following options:");
        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Subtraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");
        Console.WriteLine("5. Random");
        Console.WriteLine("6. History of Games");
        Console.WriteLine("Any other key to exit");
    }

    /// <summary>
    /// Select difficulty level
    /// </summary>
    public static void Difficulty()
    {

    }
}

