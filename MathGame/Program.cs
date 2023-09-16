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
        // menu option #6 is for game history
        if (menuSelection != "6")
        {
            difficulty = Difficulty();
            numOfQ = NumOfQuestions();
            questions = GameLogic.GenerateQuestions(difficulty, numOfQ, menuSelection);
            DisplayGame(playerInfo, questions);
            Results(playerInfo, questions);
        }
        else
        {
            if (playerInfo.HistoryOfQuestions.Count > 0)
            {
                History(playerInfo);
            }
            else
            {
                HistoryEmpty();
            }
        }
    }
} while (gameRunning);

// Greet user and show menu for user to select from
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

// Select difficulty level
static string Difficulty()
{
    int num = 0;
    string output = "";
    do
    {
        Console.Clear();
        Console.WriteLine("1. Easy - Up to and including 50 (5 for mult.)");
        Console.WriteLine("2. Medium - Up to and including 100 (10 for mult.)");
        Console.WriteLine("3. Hard - Up to and including 150 (15 for mult.)");
        Console.WriteLine("Any other key to return to main menu.\n");
        Console.Write("Pick your level of difficulty: ");
        output = Console.ReadLine();
        int.TryParse(output, out num);
    } while (num < 1 || num > 3);

    return output;
}

// Select number of questions
static int NumOfQuestions()
{
    int num = 0;
    do
    {
        Console.Clear();
        Console.Write("Enter the number of questions in the game (MAX is 10): ");
        int.TryParse(Console.ReadLine(), out num);
    } while (num <= 0 || num > 10);

    return num;
}

// Display if user has not yet played a game
static void HistoryEmpty()
{
    Console.Clear();
    Console.WriteLine("Please play a game to see your history.");
    Console.Write("Enter a key to return to the main menu: ");
    Console.ReadLine();
}

// Returns true if user selects valid menu option
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

// Displays the game on console
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

        // save users answer
        questions[i].UserAnswer = questions[i].Answers[input - 1];

        // increment player score
        if (input == questions[i].correctAnswerIndex + 1)
        {
            playerInfo.Score++;
        }
    }
}

// Shows results at the end of game
static void Results(PlayerInfo playerInfo, List<Questions> questions)
{
    playerInfo.HistoryOfQuestions.Add(questions);
    Console.Clear();
    Console.WriteLine($"Your score: {playerInfo.Score}/{questions.Count}");
    playerInfo.Score = 0;

    Console.Write("Press any key to continue: ");
    Console.ReadLine();
}

// Shows a detailed summary of all games played
static void History(PlayerInfo playerInfo)
{
    Console.Clear();
    for (int i = 0; i < playerInfo.HistoryOfQuestions.Count; i++)
    {
        for (int j = 0; j < playerInfo.HistoryOfQuestions[i].Count; j++)
        {
            Questions question = playerInfo.HistoryOfQuestions[i][j];
            Console.WriteLine($"Game {i + 1}: Question #{j + 1}: {question.Question}");
            for (int k = 0; k < question.Answers.Count; k++)
            {
                Console.WriteLine($"{k + 1}: {question.Answers[k]}");
            }
            Console.WriteLine($"User answer: {question.UserAnswer}");
            if (question.UserAnswer == question.CorrectAnswer.ToString())
            {
                Console.WriteLine("CORRECT!!!");
            }
            else
            {
                Console.WriteLine("Incorrect Answer.");
            }
        }
    }
    Console.Write("Press any key to return to main menu: ");
    Console.ReadLine();
}