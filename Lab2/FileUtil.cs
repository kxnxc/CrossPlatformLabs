namespace Lab2;

public static class FileUtil
{
    public static string[] Read(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException("Input file doesn't exist");
        }
        return File.ReadLines(path).ToArray();
    }
    
    public static void Write(string path, string[] solvs)
    {
        if (!File.Exists(path))
        {
            File.Create(path).Close();
        }

        File.WriteAllLines(path, solvs);
    }
}