namespace Lab2;

public class Program
{
    private static readonly string PathInput = Path.Combine(Path.GetFullPath("Lab2"), "Files", "INPUT.txt");
    private static readonly string PathOutput = Path.Combine(Path.GetFullPath("Lab2"), "Files", "OUTPUT.txt");
    
    public static void Main(string[] args)
    {
        string[] input;
        try
        {
            input = FileUtil.Read(PathInput);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        var processInput = TaskProcessor.ProcessInput(input);
        var solvs = new string[processInput.Count];

        for (int i = 0; i < processInput.Count; i++)
        {
            var arr = processInput[i];
            if (arr is null)
            {
                solvs[i] = "Exc";
            }
            else
            {
                solvs[i] = TaskProcessor.SolveTask(arr).ToString();
            }
        }
        FileUtil.Write(PathOutput, solvs);
    }
}