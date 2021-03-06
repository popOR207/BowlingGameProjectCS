using System;


namespace BowlingGameSpace
{
    public class UserInput : IUserInput
    {
         private const int _maxRoll = 10;
         public int GetUserInput()
         {
            int returnResult;
            do
             {
                 try
                 {
                     returnResult = Int32.Parse(Console.ReadLine());
                 }
                 catch (FormatException e)
                 {
                     Console.WriteLine("Not a valid input" + e);
                     returnResult = -1;
                 }
             }
             while (returnResult < 0 || returnResult > _maxRoll);
             return returnResult;
         }
    }
}
