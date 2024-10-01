namespace Lab1.Util;

public static class NumberProcessor
{
    public static int GetUniqueThreeDigitCount(string number)
    {
        var uniqueNumbers = new HashSet<string>();
        int length = number.Length;
        
        for (int i = 0; i < length; i++)
        {
            for (int j = i + 1; j < length; j++)
            {
                for (int k = j + 1; k < length; k++)
                {
                    string threeDigitNumber = $"{number[i]}{number[j]}{number[k]}";

                    if (threeDigitNumber[0] != '0')
                    {
                        uniqueNumbers.Add(threeDigitNumber);
                    }
                }
            }
        }

        return uniqueNumbers.Count;
    }
}