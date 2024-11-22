using System.Text;
using Lab1;
using Lab2;
using Lab3;

public class LabRunner
{
    public void RunLab1(string inputFile, string outputFile)
    {
        try
        {
            Console.OutputEncoding = Encoding.UTF8;
            var line = Lab1.FilesUtil.FileReader.Read(inputFile);
            Lab1.Util.Validator.Validate(line);
            var result = Lab1.Util.NumberProcessor.GetUniqueThreeDigitCount(line);
            Lab1.FilesUtil.FileWriter.Write(outputFile, result);
            

            Console.WriteLine("File OUTPUT.TXT successfully created");
            Console.WriteLine("Lab #1");
            Console.WriteLine("Input data:");
            Console.WriteLine(string.Join(Environment.NewLine, line).Trim());
            Console.WriteLine("Output data:");
            Console.WriteLine(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void RunLab2(string inputFile, string outputFile)
    {
        try
        {
            Console.OutputEncoding = Encoding.UTF8;
            string[] lines = Lab2.FileUtil.Read(inputFile);
            var processInput = Lab2.TaskProcessor.ProcessInput(lines);
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
                    solvs[i] = Lab2.TaskProcessor.SolveTask(arr).ToString();
                }
            }
            
            Lab2.FileUtil.Write(outputFile, solvs);

            Console.WriteLine("File OUTPUT.TXT successfully created");
            Console.WriteLine("Lab #2");
            Console.WriteLine("Input data:");
            Console.WriteLine(string.Join(Environment.NewLine, lines).Trim());
            Console.WriteLine("Output data:");
            Console.WriteLine(solvs);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    public void RunLab3(string inputFile, string outputFile)
    {
        try
        {
            Console.OutputEncoding = Encoding.UTF8;
            string[] lines = Lab3.FileUtil.Read(inputFile);
            (int n, int m, int k, int capital, HashSet<int> cities, List<(int start, int end, int time)> roads) processInput = Lab3.Solver.ProcessInput(lines);
            var solvs = Solver.solve(processInput.n, 
                processInput.m, processInput.k, 
                processInput.capital, processInput.cities, 
                processInput.roads);
            Lab3.FileUtil.Write(outputFile, solvs);
            
            Console.WriteLine("File OUTPUT.TXT successfully created");
            Console.WriteLine("Lab #3");
            Console.WriteLine("Input data:");
            Console.WriteLine(string.Join(Environment.NewLine, lines).Trim());
            Console.WriteLine("Output data:");
            Console.WriteLine(solvs);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}