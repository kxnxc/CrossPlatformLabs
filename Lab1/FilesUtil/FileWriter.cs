namespace Lab1.FilesUtil;

public static class FileWriter
{
    public static void Write(string path, int number)
    {
        if (!File.Exists(path))
        {
            File.Create(path).Close();
        }

        using var streamWriter = new StreamWriter(path);
        
        streamWriter.WriteLine(number);
    }
}