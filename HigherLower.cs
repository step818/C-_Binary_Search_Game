using System;
using System.Collections.Generic;

class HigherLower
{
  public static int BST(int low, int high)
  {
    if(high - low > 2)
    {
      int guess = (high + low - 1)/2;
      return guess;
    }
    else
    {
      int guess = (high + low + 1)/2;
      return guess;
    }
  }
  public static void GuessNumber(int compsGuess)
  {
    Console.WriteLine("Is your number " + compsGuess + " or greater? ( Y / N / Correct )");
  }
  public static bool Correct(string ans)
  {
    return (ans == "Correct");
  }
  public static bool Higher(string ans)
  {
    return (ans == "Y");
  }
  public static bool Lower(string ans)
  {
    return (ans == "N");
  }

  public class Program
  {
    public static void Main()
    {
      int low = 1;
      int high = 100;
      int compsGuess = BST(low, high);

      Console.WriteLine("Welcome to HigherLower! Who would you like to be the guesser? ( Me / comp )");
      string playerChoose = Console.ReadLine();
//  Where the player chooses the computer
      if(playerChoose == "comp")
      {
        Console.WriteLine("Pick a number between 1-100. Let's see how long it takes me to guess your number.");
        Console.WriteLine("Hit 'enter' when you have chosen a number.");
        Console.ReadLine();

        string ans = null;

        while(!Correct(ans))
        {
          GuessNumber(compsGuess);
          ans = Console.ReadLine();
          
          if (Correct(ans))
          {
            Console.WriteLine("I guessed it!");
          }
          else if(Higher(ans))
          {
            low = compsGuess;
            compsGuess = BST(low, high);
          }
          else if(Lower(ans))
          {
            high = compsGuess;
            compsGuess = BST(low, high);
          }
          else
          {
            Console.WriteLine("You need to enter a valid answer");
          }
        }
      }
      else if (playerChoose == "Me")
      {
        Console.WriteLine("Ok, you chose to guess my number. Let me think of a good one...");
//  Random number generator from 1 - 100
        Random rnd = new Random();
//  Computer's number is called "compsNumber"
        int compsNumber = rnd.Next(1, 100); 
//  Thinking(setTimeout(, 3000));
        Console.WriteLine("I have chosen my number. What is your first guess?");
//  The user's guess is called "userGuess"
        int userGuess = 105;
        while(!(CompCorrect(userGuess, compsNumber)))
        {
          Console.WriteLine("My number is " + compsNumber);
          string strGuess = Console.ReadLine();
          userGuess = int.Parse(strGuess);
          if(CompCorrect(userGuess, compsNumber))
          {
            Console.WriteLine("Yes that's it! Haha you are amazing!");
          }
          else if (CompHigher(userGuess, compsNumber))
          {
            Console.WriteLine("Nope, my number is higher than that. What is your next guess?");            
          }
          else if (CompLower(userGuess, compsNumber))
          {
            Console.WriteLine("Negatory, my number is lower than that.");
          }
            else
          {
            Console.WriteLine("Enter a valid response please.");
          }
        }
      }
    } 
  }
  public static bool CompCorrect(int userGuess, int compsNumber)
  {
    return (userGuess == compsNumber);
  }
  public static bool CompHigher(int userGuess, int compsNumber)
  {
    return (userGuess < compsNumber);
  }
  public static bool CompLower(int userGuess, int compsNumber)
  {
    return (userGuess > compsNumber);
  }
}