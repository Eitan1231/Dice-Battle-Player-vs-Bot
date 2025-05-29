using System;
using System.Threading;

namespace RollDice
{
    class Program
    {
        static Random random = new Random(); 
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Dice Game!");
                Console.WriteLine("----------------------------------");

                int[] player1 = new int[8];
                int[] player2 = new int[8];

                Console.WriteLine("Rolling dice for Player 1...");
                RollDice(player1);
                Thread.Sleep(1000);

                Console.WriteLine("\nRolling dice for Player 2...");
                RollDice(player2);
                Thread.Sleep(1000);

                Console.WriteLine("----------------------------------");

                int sumPlayer1 = CalculateSum(player1);
                int sumPlayer2 = CalculateSum(player2);
                double avgPlayer1 = CalculateAverage(player1);
                double avgPlayer2 = CalculateAverage(player2);

                Console.WriteLine("\nResults:");
                Console.WriteLine($"Player 1 Total: {sumPlayer1}, Average: {avgPlayer1:F2}");
                Console.WriteLine($"Player 2 Total: {sumPlayer2}, Average: {avgPlayer2:F2}");

                Console.WriteLine("\nWinner:");
                if (sumPlayer1 > sumPlayer2)
                {
                    Console.WriteLine("Player 1 Wins!");
                }
                else if (sumPlayer2 > sumPlayer1)
                {
                    Console.WriteLine("Player 2 Wins!");
                }
                else
                {
                    Console.WriteLine("It's a Tie!");
                }

                Console.Write("\nWould you like to play again? (Y = Yes, N = No): ");
            } while (Console.ReadLine().Trim().ToUpper() == "Y");

            Console.WriteLine("Thanks for playing!");
            Console.ReadKey();
        }

        static void RollDice(int[] player)
        {
            for (int i = 0; i < player.Length; i++)
            {
                player[i] = random.Next(1, 7); 
                Console.Write(player[i] + " ");
                Thread.Sleep(100);
            }
            Console.WriteLine();
        }

        static int CalculateSum(int[] array)
        {
            int sum = 0;
            foreach (int number in array)
            {
                sum += number;
            }
            return sum;
        }

        static double CalculateAverage(int[] array)
        {
            return (double)CalculateSum(array) / array.Length;
        }
    }
}
