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
    private static string DisplayWelcome()
    {
        Console.WriteLine("Welcome to Math Game!");
        Console.WriteLine("Here you will pick the type of operation you want to answer.");
        Console.WriteLine("You will be asked to select difficulty and number of questions.");
        Console.WriteLine("\nSelect from the following options:");
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
    private static string Difficulty()
    {
        Console.WriteLine("Pick your level of difficulty:");
        Console.WriteLine("1. Easy - Up to and including 5x table");
        Console.WriteLine("2. Medium - Up to and including 10x table");
        Console.WriteLine("3. Hard - Up to and including 15x table");
        Console.WriteLine("Any other key to return to main menu.");

        return Console.ReadLine();
    }

    private static int NumOfQuestions()
    {
        int num = 0;
        do
        {
            Console.Write("Enter the number of questions in the game (MAX is 10): ");
            int.TryParse(Console.ReadLine(), out num)
        } while (num > 0 && num <= 10);

        return num;
    }

    /// <summary>
    /// Runs game
    /// </summary>
    public static void GameState()
    {
        bool gameRunning = true;

        do
        {
            gameRunning = MenuSelection();
        } while (gameRunning);
    }

    private static bool MenuSelection()
    {
        string menuSelection = "";

        // welcome user and ask to select from menu options
        menuSelection = DisplayWelcome();

        // call method depending on menu selection
        if (menuSelection == "1" || menuSelection == "2" || menuSelection == "3" || menuSelection == "4" || menuSelection == "6")
        {
            PreGame(menuSelection);
        }
        else if (menuSelection == "5")
        {
            History();
        }
        else
        {
            return false;
        }

        return true;
    }

    private static void PreGame(string menuSelection)
    {
        Difficulty();
        NumOfQuestions();

        if (menuSelection == "1")
        {
            Addition();
        }
        else if (menuSelection == "2")
        {
            Subtraction();
        }
        else if (menuSelection == "3")
        {
            Multiplication();
        }
        else if (menuSelection == "4")
        {
            Division();
        }
        else if (menuSelection == "6")
        {
            RandomGame();
        }
    }

    private static void RandomGame()
    {
        throw new NotImplementedException();
    }

    private static void History()
    {
        throw new NotImplementedException();
    }

    private static void Division()
    {
        throw new NotImplementedException();
    }

    private static void Multiplication()
    {
        throw new NotImplementedException();
    }

    private static void Subtraction()
    {
        throw new NotImplementedException();
    }

    private static void Addition()
    {

    }
}

