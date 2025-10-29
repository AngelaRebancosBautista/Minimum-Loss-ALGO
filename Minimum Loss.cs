using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Result
{
    /*
     * Complete the 'minimumLoss' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts LONG_INTEGER_ARRAY price as parameter.
     */

    public static int minimumLoss(List<long> price)
    {
        int n = price.Count;

        Dictionary<long, int> indexMap = new Dictionary<long, int>();
        for (int i = 0; i < n; i++)
        {
            indexMap[price[i]] = i;
        }

        List<long> sorted = new List<long>(price);
        sorted.Sort();

        long minLoss = long.MaxValue;

        for (int i = 1; i < n; i++)
        {
            long high = sorted[i];
            long low = sorted[i - 1];

            if (indexMap[high] < indexMap[low])
            {
                long loss = high - low;
                if (loss < minLoss)
                    minLoss = loss;
            }
        }

        return (int)minLoss;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<long> price = Console.ReadLine().TrimEnd().Split(' ')
            .Select(priceTemp => Convert.ToInt64(priceTemp))
            .ToList();

        int result = Result.minimumLoss(price);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
