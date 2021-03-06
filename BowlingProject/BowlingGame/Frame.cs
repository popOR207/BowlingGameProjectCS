using System;

namespace BowlingGameSpace
{
    public class Frame : IFrame
    {
        private FrameStatus frameType;
        private const int _maxRoll = 10;
        public int firstRollResult = 0;
        private int secondRollResult = 0;
        private readonly IUserInput UserInputHandler;

        public Frame(FrameStatus frameType, IUserInput UserInputHandler)
        {
            this.frameType = frameType;
            this.UserInputHandler = UserInputHandler;
        }

        public int GetFirstRollResult()
        {
            return firstRollResult;
        }

        public int GetSecondRollResult()
        {
            return secondRollResult;
        }

        public FrameStatus GetFrameType()
        {
            return frameType;
        }

        public void Roll()
        {
            if (frameType.Equals(FrameStatus.Normal))
            {
                NormalFrameRoll();
            }
            else
            {
                LastFrameRoll();
            }
        }

        private void NormalFrameRoll()
        {
            firstRollResult = RollResult();
            if (_maxRoll == firstRollResult)
            {
                Console.WriteLine("Bonus! strike!!");
                frameType = FrameStatus.Strike;
            }
            else
            {
                secondRollResult = RollResult();
                if (_maxRoll == firstRollResult + secondRollResult)
                {
                    Console.WriteLine("Bonus! spare!");
                    frameType = FrameStatus.Spare;
                }
            }
        }

        private void LastFrameRoll()
        {
            if (frameType.Equals(FrameStatus.LastSpare))
            {
                firstRollResult = RollResult();
            }
            else if (frameType.Equals(FrameStatus.LastStrike))
            {
                NormalFrameRoll();
            }
        }

        private int RollResult()
        {
            int throwRange = _maxRoll - firstRollResult;
            int returnResult;
            do
            {
                Console.WriteLine($"Choose a number between 0 - {throwRange}" );
                returnResult = UserInputHandler.GetUserInput();
            }
            while (returnResult < 0 || returnResult > throwRange);
            return returnResult;
        }
    }
}
