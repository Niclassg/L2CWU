using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 53 ;
            string numberString;
            int numberGuessed;

            bool areNumbersEqual = false;

            while (!areNumbersEqual)
            {

                Console.WriteLine("Please guess a number between 1-100 ");
                numberString = Console.ReadLine();
                numberGuessed = Convert.ToInt32(numberString);

                areNumbersEqual = number == numberGuessed;

                if (areNumbersEqual)
                {
                    Console.WriteLine("Yay! You guessed the right number!");
                }
                else if (number > numberGuessed)
                {
                    Console.WriteLine("The number is higher than what you guessed");
                }
                else if (number < numberGuessed)
                {
                    Console.WriteLine("The number is lower than what you guessed");
                }
            }

           


        }
    }
}
