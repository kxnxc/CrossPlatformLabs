namespace Lab2;

public class TaskProcessor
{
    public static int SolveTask(int[][] array)
    {
        int n = array.Length;
        int m = array[0].Length;

        int[,] cost = new int[n, m];

        cost[0, 0] = array[0][0];

        for (int i = 1; i < n; ++i)
        {
            cost[i, 0] = array[i][0] + cost[i - 1, 0];
        }
        for (int i = 1; i < m; ++i)
        {
            cost[0, i] = array[0][i] + cost[0, i - 1];
        }
        for (int i = 1; i < n; ++i)
        {
            for (int j = 1; j < m; ++j)
            {
                cost[i, j] = Math.Min(cost[i - 1, j], cost[i, j - 1]) + array[i][j];
            }
        }
        return cost[n - 1, m - 1];
    }
    
    public static List<int[][]> ProcessInput(string[] input)
    {
        List<int[][]> arrays = new List<int[][]>();
        int i = 0;

        while (i < input.Length)
        {
            string[] size = input[i].Split(' ');
            if (size.Length != 2 || 
                !int.TryParse(size[0], out int rows) || 
                !int.TryParse(size[1], out int cols) || 
                rows <= 0 || cols <= 0)
            {
                Console.WriteLine($"Invalid size format at line {i + 1}: {input[i]}");
                i++;
                continue;
            }

            if (i + rows >= input.Length)
            {
                Console.WriteLine($"Insufficient rows for matrix starting at line {i + 1}");
                break;
            }

            int[][] array = new int[rows][];
            bool isValidArray = true;

            for (int j = 0; j < rows; j++)
            {
                string[] values = input[i + 1 + j].Split(' ');
                if (values.Length != cols || !values.All(IsInteger))
                {
                    Console.WriteLine($"Invalid row format at line {i + 2 + j}: {input[i + 1 + j]}");
                    isValidArray = false;
                    break;
                }

                array[j] = Array.ConvertAll(values, int.Parse);
            }

            if (isValidArray)
            {
                arrays.Add(array);
            }
            else
            {
                Console.WriteLine($"Skipping invalid matrix starting at line {i + 1}");
            }

            i += rows + 1;
        }

        return arrays;
    }

    private static bool IsInteger(string value)
    {
        return int.TryParse(value, out _);
    }
}