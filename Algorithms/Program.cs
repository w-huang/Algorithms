namespace Algorithms
{
    using System;
    using Algorithms.Searching;

    class Program
    {
        static void Main(string[] args)
        {
            var search = new Search();

            int[] test = new int[] {1, 2, 3, 4, 5, 6, 7,8, 12, 14, 200, 400};
            int ans = Search.BinarySearch<int>(test, -22);
            Console.WriteLine(String.Format("{0}", ans));

        }
    }
}
