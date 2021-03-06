using System;


namespace BowlingGameSpace
{
    public class UserInput : IUserInput
    {
        private const int _maxRoll = 10;
        private bool legitInput = false;
         public int GetUserInput()
         {
            int returnResult = 0;
            do
             {
                try
                {
                    returnResult = Int32.Parse(Console.ReadLine());
                    if (returnResult < 0 || returnResult > _maxRoll)
                    {
                        throw new FormatException();
                    }

                    legitInput = true;
                }
                catch (Exception e)
                {
                    if (e is FormatException || e is OverflowException)
                    legitInput = false;
                    Console.WriteLine("Not a valid input, please try again");
                }
             }
            while (false == legitInput);
            return returnResult;
         }
    }
}
