namespace Lab3;

public class Program
{
    private static readonly string PathInput = Path.Combine(Path.GetFullPath("Lab3"), "Files", "INPUT.txt");
    private static readonly string PathOutput = Path.Combine(Path.GetFullPath("Lab3"), "Files", "OUTPUT.txt");
    
    public static void Main(string[] args)
    {
        try
        {
            (int n, int m, int k, int capital, HashSet<int> cities, List<(int start, int end, int time)> roads) processInput = Solver.ProcessInput(FileUtil.Read(PathInput));
            var solvs = Solver.solve(processInput.n, 
                processInput.m, processInput.k, 
                processInput.capital, processInput.cities, 
                processInput.roads);
            FileUtil.Write(PathOutput,solvs);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}