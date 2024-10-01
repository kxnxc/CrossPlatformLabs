namespace Lab1.FilesUtil;

public static class FileReader
{
    public static string Read(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException("Input file doesn't exist");
        }
        using var streamReader = new StreamReader(path);
        var readLine = streamReader.ReadLine();
        if (readLine == null)
        {
            throw new NullReferenceException("Input file is empty");
        }

        return readLine;
    }
}