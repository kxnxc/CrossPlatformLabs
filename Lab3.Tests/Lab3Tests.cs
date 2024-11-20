namespace Lab3.Tests;

public class Lab3Tests
{
    [Fact]
    public void ok_test_valid_result()
    {
        int n = 4, m = 4, k = 2, capital = 1;
        var cities = new HashSet<int> { 3, 4 };
        var roads = new List<(int s, int e, int t)>
        {
            (1, 2, 5),
            (2, 3, 5),
            (1, 3, 10),
            (3, 4, 1)
        };

        var result = Solver.solve(n, m, k, capital, cities, roads);

        Assert.Equal(new[] { "3 10", "4 11" }, result);
    }
    
    [Fact]
    public void process_input_test()
    {
        var input = new[]
        {
            "4 4 2 1",
            "3 4",
            "1 2 5",
            "2 3 5",
            "1 3 10",
            "3 4 1"
        };

        var result = Solver.ProcessInput(input);

        Assert.Equal(4, result.n);
        Assert.Equal(4, result.m);
        Assert.Equal(2, result.k);
        Assert.Equal(1, result.capital);
        Assert.Equal(new HashSet<int> { 3, 4 }, result.cities);
        Assert.Equal(
            new List<(int start, int end, int time)>
            {
                (1, 2, 5),
                (2, 3, 5),
                (1, 3, 10),
                (3, 4, 1)
            },
            result.roads
        );
    }
    
    [Fact]
    public void read_file_test()
    {
        var testPath = "test_input.txt";
        var content = new[] { "1 2 3 4", "5 6 7 8" };
        File.WriteAllLines(testPath, content);

        var result = FileUtil.Read(testPath);

        Assert.Equal(content, result);

        File.Delete(testPath);
    }
    
    [Fact]
    public void file_not_exist_test()
    {
        var testPath = "test_output.txt";
        var content = new[] { "Result 1", "Result 2" };

        FileUtil.Write(testPath, content);

        Assert.True(File.Exists(testPath));
        Assert.Equal(content, File.ReadAllLines(testPath));

        File.Delete(testPath);
    }
    
    [Fact]
    public void write_result_to_file_test()
    {
        var testPath = "test_output.txt";
        File.WriteAllText(testPath, "Old Content");
        var newContent = new[] { "New Line 1", "New Line 2" };

        FileUtil.Write(testPath, newContent);

        Assert.Equal(newContent, File.ReadAllLines(testPath));

        File.Delete(testPath);
    }
}