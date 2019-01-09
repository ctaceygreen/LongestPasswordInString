using System;
using System.Text.RegularExpressions;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution
{
    public int solution(string S)
    {
        // write your code in C# 6.0 with .NET 4.5 (Mono)

        //Split S on spaces
        string[] wordsSplits = S.Split(' ');
        int largestPassword = -1;
        //Loop through each word. 
        foreach(var word in wordsSplits)
        {
            //Loop through characters of word.
            Regex alphaNumericRegex = new Regex(@"^[a-zA-Z0-9]*$");
            if (alphaNumericRegex.IsMatch(word))
            {
                int totalDigit = 0;
                int totalLetter = 0;
                foreach (char character in word)
                {
                    //If character can be parsed to int then add to count of digit
                    int digit;
                    bool isDigit = int.TryParse(character.ToString(), out digit);
                    if(isDigit)
                    {
                        totalDigit++;
                    }
                    else
                    {
                        //Else then add to count of letters
                        totalLetter++;
                    }
                    
                }
                //Check that digit count is odd % 2 != 0
                //Check that letter count is even %2 == 0
                if(totalDigit % 2 != 0 && totalLetter % 2 == 0)
                {
                    //If so, then Math.max of currentMax and this character count (digitCount + letterCount)
                    largestPassword = Math.Max(largestPassword, totalDigit + totalLetter);

                }
            }
        }
        return largestPassword;
    }
}