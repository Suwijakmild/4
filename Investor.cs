using System;
namespace StoreOptimization
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the values of N (number of roads) and K (maximum distance): ");
            int[] inputValues = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int N = inputValues[0];
            int K = inputValues[1];
            Console.WriteLine("Enter the population for each road:");
            int[] roadPopulations = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int optimalPopulation = CalculateOptimalPopulation(roadPopulations, N, K);
            Console.WriteLine("Maximum potential customer base: " + optimalPopulation);
        }
        static int CalculateOptimalPopulation(int[] roadPopulations, int N, int K)
        {
            int optimalPopulation = 0;
            for (int i = 0; i < N; i++)
            {
                int localPopulation = 0;
                for (int j = Math.Max(0, i - K); j <= Math.Min(N - 1, i + K); j++)
                {
                    localPopulation += roadPopulations[j];
                }
                optimalPopulation = Math.Max(optimalPopulation, localPopulation);
            }
            return optimalPopulation;
        }
    }
}