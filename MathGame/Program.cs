using MathGameLibrary;

bool gameRunning = true;
string difficulty = "";
int numOfQ = 0;
string menuSelection = "";
List<Questions> questions = new List<Questions>();
PlayerInfo playerInfo = new PlayerInfo();

do
{
    (gameRunning, menuSelection) = MenuSelection();

    if (gameRunning)
    {
        if (menuSelection != "5")
        {
            difficulty = Difficulty();
            numOfQ = NumOfQuestions();
            questions = GameLogic.GenerateQuestions(difficulty, numOfQ, menuSelection);
            DisplayGame(playerInfo, questions);
            Results(playerInfo, questions);
        }
        else
        {
            //History();
        }
    }
} while (gameRunning);

//Random random = new Random();

/// <summary>
/// Greet user and show menu
/// </summary>
static string DisplayWelcome()
{
    Console.Clear();
    Console.WriteLine("Welcome to Math Game!");
    Console.WriteLine("Here you will pick the type of operation you want to answer.");
    Console.WriteLine("You will be asked to select difficulty and number of questions.");
    Console.WriteLine("\n1. Addition");
    Console.WriteLine("2. Subtraction");
    Console.WriteLine("3. Multiplication");
    Console.WriteLine("4. Division");
    Console.WriteLine("5. Random");
    Console.WriteLine("6. History of Games");
    Console.WriteLine("Any other key to exit.");
    Console.Write("\nSelect from the following options: ");

    return Console.ReadLine();
}

/// <summary>
/// Select difficulty level
/// </summary>
static string Difficulty()
{
    Console.Clear();
    Console.WriteLine("1. Easy - Up to and including 5x table");
    Console.WriteLine("2. Medium - Up to and including 10x table");
    Console.WriteLine("3. Hard - Up to and including 15x table");
    Console.WriteLine("Any other key to return to main menu.\n");
    Console.Write("Pick your level of difficulty: ");

    return Console.ReadLine();
}

static int NumOfQuestions()
{
    Console.Clear();
    int num = 0;
    do
    {
        Console.Write("Enter the number of questions in the game (MAX is 10): ");
        int.TryParse(Console.ReadLine(), out num);
    } while (num <= 0 || num > 10);

    return num;
}

static (bool, string) MenuSelection()
{
    string menuSelection = "";

    // welcome user and ask to select from menu options
    menuSelection = DisplayWelcome();

    // call method depending on menu selection
    bool continueGame = menuSelection switch
    {
        "1" => true,
        "2" => true,
        "3" => true,
        "4" => true,
        "5" => true,
        "6" => true,
        _ => false
    };

    return (continueGame, menuSelection);
}

static void DisplayGame(PlayerInfo playerInfo, List<Questions> questions)
{
    for (int i = 0; i < questions.Count; i++)
    {
        int input = 0;
        do
        {
            Console.Clear();
            Console.WriteLine($"Question #{i + 1}");
            Console.WriteLine($"Current score: {playerInfo.Score}/{questions.Count}");
            Console.WriteLine($"{questions[i].Question}: \n");
            for (int j = 0; j < questions[i].Answers.Count; j++)
            {
                Console.WriteLine($"{j + 1}. {questions[i].Answers[j]}");
            }
            Console.Write("\nWhat is the correct answer? ");
            int.TryParse(Console.ReadLine(), out input);
        } while (input < 1 || input > 4);

        if (input == questions[i].correctAnswerIndex + 1)
        {
            playerInfo.Score++;
        }
    }
}

static void Results(PlayerInfo playerInfo, List<Questions> questions)
{
    Console.Clear();
    Console.WriteLine($"Your score: {playerInfo.Score}/{questions.Count}");
    Console.Write("Press any key to continue: ");
    Console.ReadLine();
}