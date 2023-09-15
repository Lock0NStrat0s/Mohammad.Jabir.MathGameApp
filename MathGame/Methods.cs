using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
        Console.Clear();
        Console.WriteLine("Pick your level of difficulty:");
        Console.WriteLine("1. Easy - Up to and including 5x table");
        Console.WriteLine("2. Medium - Up to and including 10x table");
        Console.WriteLine("3. Hard - Up to and including 15x table");
        Console.WriteLine("Any other key to return to main menu.");

        return Console.ReadLine();
    }

    private static int NumOfQuestions()
    {
        Console.Clear();
        int num = 0;
        do
        {
            Console.Write("Enter the number of questions in the game (MAX is 10): ");
            int.TryParse(Console.ReadLine(), out num);
        } while (num > 0 && num <= 10);

        return num;
    }

    /// <summary>
    /// Runs game
    /// </summary>
    public static void GameState()
    {
        bool gameRunning = true;
        string difficulty = "";
        int numOfQ = 0;
        string menuSelection = "";
        List<string> questions = new List<string>();
        List<string> history = new List<string>();

        do
        {
            (gameRunning, menuSelection) = MenuSelection();

            if (gameRunning)
            {
                if (menuSelection != "5")
                {
                    PreGame(menuSelection);
                    CreateQuestions(difficulty, numOfQ, menuSelection);
                }
                else
                {
                    History();
                }
            }
        } while (gameRunning);
    }

    private static (bool, string) MenuSelection()
    {
        string menuSelection = "";

        // welcome user and ask to select from menu options
        menuSelection = DisplayWelcome();

        // call method depending on menu selection
        if (menuSelection != "1" || menuSelection != "2" || menuSelection != "3" || menuSelection != "4" || menuSelection != "5" || menuSelection != "6")
        {
            return (false, menuSelection);
        }

        return (true, menuSelection);
    }

    /// <summary>
    /// Ascertain difficulty and number of questions and then begin game
    /// </summary>
    /// <param name="menuSelection"></param>
    private static (string difficulty, int numOfQ) PreGame(string menuSelection)
    {
        return (Difficulty(), NumOfQuestions());
    }

    private static List<string> CreateQuestions(string difficulty, int numOfQ, string menuSelection)
    {
        //List<string> questions = new List<string>();

        do
        {
            questions.Add(Generate(difficulty, numOfQ, menuSelection));
        } while (numOfQ > 0);

        return questions;
    }

    private static void DisplayGame()
    {
        Console.Clear();
    }

    private static void RandomGame(string difficulty, int numOfQ)
    {

    }

    private static void History()
    {

    }

    private static void Division(string difficulty, int numOfQ)
    {

    }

    private static void Multiplication(string difficulty, int numOfQ)
    {

    }

    private static void Subtraction(string difficulty, int numOfQ)
    {

    }

    private static void Addition(string difficulty, int numOfQ)
    {
        //List<string> Questions = new List<string>();

        //do
        //{
        //    Generate(difficulty, numOfQ);
        //} while (numOfQ > 0);
    }

    private static string Generate(string difficulty, int numOfQ, string menuSelection)
    {
        //if (menuSelection == "1")
        //{
        //    Addition(difficulty, numOfQ);
        //}
        //else if (menuSelection == "2")
        //{
        //    Subtraction(difficulty, numOfQ);
        //}
        //else if (menuSelection == "3")
        //{
        //    Multiplication(difficulty, numOfQ);
        //}
        //else if (menuSelection == "4")
        //{
        //    Division(difficulty, numOfQ);
        //}
        //else if (menuSelection == "6")
        //{
        //    RandomGame(difficulty, numOfQ);
        //}
    }
}

