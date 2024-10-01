using Lab1.FilesUtil;
using Lab1.Util;

namespace Lab1.Tests;

public class Lab1Tests : IDisposable
{
    private const string InputFilePath = "INPUT.TXT";
    
    [Fact]
    public void Test_ValidInput()
    {
        string line = "11111111111100111111111";
        var ex = Record.Exception(() => Validator.Validate(line));
        Assert.Null(ex);
    }

    [Fact]
    public void Test_InvalidInput()
    {
        string line = "";
        var ex = Record.Exception(() => Validator.Validate(line));
        Assert.NotNull(ex);
        Assert.IsType<ArgumentException>(ex);
    }

    [Fact]
    public void Test_ValidResult()
    {
        string line = "11111111111100111111111";
        int validResult = 4;
        var result = NumberProcessor.GetUniqueThreeDigitCount(line);
        Assert.Equal(validResult, result);
    }

    [Fact]
    public void Test_InvalidInputFilePath()
    {
        string path = "non-existent file path";
        var ex = Record.Exception(() => FileReader.Read(path));
        Assert.NotNull(ex);
        Assert.IsType<FileNotFoundException>(ex);
    }

    [Fact]
    public void Test_ValidInputFile()
    {
        File.WriteAllText(InputFilePath, "11111111111100111111111");
        Assert.True(File.Exists(InputFilePath));
    }

    public void Dispose()
    {
        if (File.Exists(InputFilePath))
        {
            File.Delete(InputFilePath);
        }
    }
}