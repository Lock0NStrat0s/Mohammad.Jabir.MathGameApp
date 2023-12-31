﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGameLibrary;

public static class GameLogic
{
    public static Random random = new Random();     // random number generator
    
    // Generates and returns a list of questions
    public static List<Questions> GenerateQuestions(string difficulty, int numOfQ, string menuSelection)
    {
        List<Questions> questions = new List<Questions>();

        // if user selects a normal operation
        if (menuSelection != "5")
        {
            do
            {
                questions.Add(Operation(difficulty, menuSelection));
                numOfQ--;
            } while (numOfQ > 0);
        }
        // if user selects random operations
        else
        {
            do
            {
                int rndOperation = random.Next(1, 5);
                questions.Add(Operation(difficulty, rndOperation.ToString()));
                numOfQ--;
            } while (numOfQ > 0);
        }

        return questions;
    }

    // Handles the 4 different types of math operations
    private static Questions Operation(string difficulty, string menuSelection)
    {
        Questions question = new Questions();

        int maxNum = difficulty switch
        {
            "1" => 51,
            "2" => 101,
            "3" => 151,
            _ => 101
        };

        if (menuSelection == "1")
        {
            Addition(question, maxNum);
        }
        else if (menuSelection == "2")
        {
            Subtraction(question, maxNum);
        }
        else if (menuSelection == "3")
        {
            // reduce difficulty when multiplying
            maxNum = difficulty switch
            {
                "1" => 6,
                "2" => 11,
                "3" => 16,
                _ => 11
            };
            Multiplication(question, maxNum);
        }
        else if (menuSelection == "4")
        {
            Division(question, maxNum);
        }

        return question;
    }

    private static void Division(Questions question, int maxNum)
    {
        double firstValue = 0;
        double secondValue = 0;
        do
        {
            firstValue = random.Next(0, maxNum);
            secondValue = random.Next(0, maxNum);
        } while (firstValue % secondValue != 0);


        question.Question = $"{firstValue} / {secondValue}";
        question.CorrectAnswer = (int)(firstValue / secondValue);

        GenerateAnswers(question);
    }

    private static void Multiplication(Questions question, int maxNum)
    {
        int firstValue = random.Next(0, maxNum);
        int secondValue = random.Next(0, maxNum);

        question.Question = $"{firstValue} * {secondValue}";
        question.CorrectAnswer = firstValue * secondValue;

        GenerateAnswers(question);
    }

    private static void Subtraction(Questions question, int maxNum)
    {
        int firstValue = random.Next(0, maxNum);
        int secondValue = random.Next(0, firstValue + 1);

        question.Question = $"{firstValue} - {secondValue}";
        question.CorrectAnswer = firstValue - secondValue;

        GenerateAnswers(question);
    }

    private static void Addition(Questions question, int maxNum)
    {
        int firstValue = random.Next(0, maxNum);
        int secondValue = random.Next(0, maxNum);

        question.Question = $"{firstValue} + {secondValue}";
        question.CorrectAnswer = firstValue + secondValue;

        GenerateAnswers(question);
    }

    // Generate a list of 3 false answers
    private static void GenerateAnswers(Questions question)
    {
        question.Answers.Add(question.CorrectAnswer.ToString());
        do
        {
            string temp = random.Next(151).ToString();
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

        for (int i = 0; i < question.Answers.Count(); i++)
        {
            if (question.Answers[i] == question.CorrectAnswer.ToString())
            {
                question.correctAnswerIndex = i;
            }
        }
    }

    // Randomize generated list
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

