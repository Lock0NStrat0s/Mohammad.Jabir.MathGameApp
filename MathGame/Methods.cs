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
    public static string DisplayWelcome()
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

        return Console.ReadLine();
    }

    /// <summary>
    /// Select difficulty level
    /// </summary>
    public static string Difficulty()
    {
        Console.WriteLine("Pick your level of difficulty:");
        Console.WriteLine("1. Easy - Up to and including 5x table");
        Console.WriteLine("2. Medium - Up to and including 10x table");
        Console.WriteLine("3. Hard - Up to and including 15x table");
        Console.WriteLine("Any other key to return to main menu.");

        return Console.ReadLine();
    }

    public static string NumOfQuestions()
    {

    }

    public static void GameState()
    {

    }
}

