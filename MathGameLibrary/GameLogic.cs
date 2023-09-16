using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGameLibrary;

public static class GameLogic
{
    public static Random random = new Random();
    public static List<Questions> GenerateQuestions(string difficulty, int numOfQ, string menuSelection)
    {
        List<Questions> questions = new List<Questions>();

        do
        {
            questions.Add(Operation(difficulty, menuSelection));
            numOfQ--;
        } while (numOfQ > 0);

        return questions;
    }

    private static Questions Operation(string difficulty, string menuSelection)
    {
        Questions question = new Questions();

        int maxNum = difficulty switch
        {
            "1" => 6,
            "2" => 11,
            "3" => 16,
            _ => 11
        };

        if (menuSelection == "1")
        {
            Addition(question, maxNum);
        }

        return question;
    }

    private static void Addition(Questions question, int maxNum)
    {
        int firstValue = random.Next(0, maxNum);
        int secondValue = random.Next(0, maxNum);

        question.Question = $"{firstValue} + {secondValue}";
        question.CorrectAns = firstValue + secondValue;

        GenerateAnswers(question);
    }

    private static void GenerateAnswers(Questions question)
    {
        // generate a list of 3 false answers 
        question.Answers.Add(question.CorrectAnswer.ToString());
        do
        {
            string temp = random.Next(101).ToString();
            if (question.Answers.Contains(temp))
            {
                continue;
            }
            else
            {
                question.Answers.Add(temp);
            }
        } while (question.Answers.Count() < 4);

        // randomize list of answers using fisher-yates shuffle
        question.Answers = RandomizeList(question.Answers);
    }

    private static List<string> RandomizeList(List<string> answers)
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
}

