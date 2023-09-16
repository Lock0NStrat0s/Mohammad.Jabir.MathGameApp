using MathGame;


Methods.GameState();


static Random random = new Random();

/// <summary>
/// Greet user and show menu
/// </summary>
static string DisplayWelcome()
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
static string Difficulty()
{
    Console.Clear();
    Console.WriteLine("Pick your level of difficulty:");
    Console.WriteLine("1. Easy - Up to and including 5x table");
    Console.WriteLine("2. Medium - Up to and including 10x table");
    Console.WriteLine("3. Hard - Up to and including 15x table");
    Console.WriteLine("Any other key to return to main menu.");

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
    } while (num > 0 && num <= 10);

    return num;
}

/// <summary>
/// Runs game
/// </summary>
static void GameState()
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
                (difficulty, numOfQ) = PreGame(menuSelection);
                (questions,  = CreateQuestions(difficulty, numOfQ, menuSelection);
            }
            else
            {
                History();
            }
        }
    } while (gameRunning);
}

static (bool, string) MenuSelection()
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
static (string difficulty, int numOfQ) PreGame(string menuSelection)
{
    return (Difficulty(), NumOfQuestions());
}

static List<(string question, List<string> answers, string answer)> CreateQuestions(string difficulty, int numOfQ, string menuSelection)
{
    List<(string question, List<string> answers, string answer)> questions = new List<(string question, List<string> answers, string answer)>();

    do
    {
        questions.Add(Generate(difficulty, menuSelection));
    } while (numOfQ > 0);

    return questions;
}

static (string question, List<string> answers, string answer) Generate(string difficulty, string menuSelection)
{
    int maxNum = difficulty switch
    {
        "1" => 6,
        "2" => 11,
        "3" => 16,
    };

    string question = "";
    int answer = 0;
    int firstValue = 0;
    int secondValue = 0;
    List<string> answers = new List<string>();

    if (menuSelection == "1")
    {
        (firstValue, secondValue) = Addition(maxNum);
        question = $"{firstValue} + {secondValue}";
        answer = firstValue + secondValue;
    }
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

    // generate a list of 3 false answers 
    answers.Add(answer.ToString());
    do
    {
        string temp = random.Next(101).ToString();
        if (answers.Contains(temp))
        {
            continue;
        }
        else
        {
            answers.Add(temp);
        }
    } while (answers.Count() < 4);

    // randomize list of answers using fisher-yates shuffle
    answers = RandomizeList(answers);

    return (question, answers, answer.ToString());
}

static List<string> RandomizeList(List<string> answers)
{
    int n = answers.Count;
    while (n > 1)
    {
        n--;
        int k = random.Next(n + 1);
        string value = answers[k];
        answers[k] = answers[n];
        answers[n] = value;
    }

    return answers;
}

static void DisplayGame()
{
    Console.Clear();
}


static (int, int) Addition(int maxNum)
{
    return (random.Next(0, maxNum), random.Next(0, maxNum));
}


