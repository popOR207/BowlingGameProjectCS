
using BowlingGameSpace;

namespace BowlingXunitTests
{
    public class TestPreSetInput : IUserInput
    {
        private readonly int userInputFirstRound;
        private readonly int userInputSecondRound;
        private bool roundFlip = true;

        public TestPreSetInput(int userInputFirstRound, int userInputSecondRound)
        {
            this.userInputFirstRound = userInputFirstRound;
            this.userInputSecondRound = userInputSecondRound;
        }
        public int GetUserInput()
        {
            if (roundFlip == true)
            {
                roundFlip = false;
                return userInputFirstRound;
            }
            return userInputSecondRound;
        }
    }
}
