namespace Lab3;

public class Solver
{
    private const int INF = int.MaxValue;

    public static string[] solve(int n, int m, int k, int capital, HashSet<int> cities, List<(int s, int e, int t)> roads)
    { 
        List<(int, int)>[] graph = new List<(int, int)>[n + 1];
        for (int i = 0; i <= n; i++)
        {
            graph[i] = new List<(int, int)>();
        }

        foreach (var road in roads)
        {
            int s = road.s;
            int e = road.e;
            int t = road.t;
            graph[s].Add((e, t));
            graph[e].Add((s, t));
        }

        int[] dist = new int[n + 1];
        for (int i = 1; i <= n; i++)
        {
            dist[i] = INF;
        }
        dist[capital] = 0;

        var pq = new SortedSet<(int dist, int node)>();
        pq.Add((0, capital));

        while (pq.Count > 0)
        {
            var current = pq.Min;
            int currentDist = current.dist;
            int currentNode = current.node;
            pq.Remove(current);

            if (currentDist > dist[currentNode])
                continue;

            foreach (var neighbor in graph[currentNode])
            {
                int newDist = currentDist + neighbor.Item2;
                if (newDist < dist[neighbor.Item1])
                {
                    pq.Remove((dist[neighbor.Item1], neighbor.Item1));
                    dist[neighbor.Item1] = newDist;
                    pq.Add((newDist, neighbor.Item1));
                }
            }
        }

        var result = cities
            .Where(city => dist[city] < INF)
            .Select(city => (city, dist[city]))
            .OrderBy(x => x.Item2)
            .ThenBy(x => x.Item1)
            .Select(x => $"{x.Item1} {x.Item2}")
            .ToArray();

        return result;
    }

    
    public static (int n, int m, int k, int capital, HashSet<int> cities, List<(int start, int end, int time)> roads) ProcessInput(string[] input)
    {
        if (!input.All(IsLineOfIntegers))
        {
            throw new FormatException("Input is invalid");
        }

        var firstLine = ParseLineToIntegers(input[0]);
        if (firstLine.Length != 4)
        {
            throw new FormatException("Expected 4 integers");
        }
        int n = firstLine[0];
        int m = firstLine[1];
        int k = firstLine[2];
        int capital = firstLine[3];

        var cities = ParseLineToIntegers(input[1]).ToHashSet();

        var roads = new List<(int start, int end, int time)>();
        for (int i = 2; i < 2 + m; i++)
        {
            var roadData = ParseLineToIntegers(input[i]);
            if (roadData.Length != 3)
            {
                throw new FormatException($"Invalid road format");
            }
            roads.Add((roadData[0], roadData[1], roadData[2]));
        }

        return (n, m, k, capital, cities, roads);
    }

    private static bool IsLineOfIntegers(string line)
    {
        return line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .All(part => int.TryParse(part, out _));
    }

    private static int[] ParseLineToIntegers(string line)
    {
        return line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
    }

}