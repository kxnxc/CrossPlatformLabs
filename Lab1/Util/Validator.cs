namespace Lab1.Util;

public class Validator
{
    public static bool Validate(string n)
    {
        if (n.Length > 100)
        {
            throw new ArgumentException("Input number cannot exceed 100 digits");
        }
        if (n == "0" || n == "")
        {
            throw new ArgumentException("Input must be a natural number greater than 0");
        }
        
        return true;
    }
}