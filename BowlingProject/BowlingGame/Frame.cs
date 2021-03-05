using System;

namespace BowlingGameSpace
{
    class Frame : IFrame
    {
        private FrameStatus frameType;
        public int firstRollResult = 0;
        private int secondRollResult = 0;
        private const int _maxRoll = 10;
        public Frame(FrameStatus frameType)
        {
            this.frameType = frameType;
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
            int returnResult = 0;
            do
            {
                Console.WriteLine($"Choose a number between 0 - {throwRange}" );
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
            while (returnResult < 0 || returnResult > throwRange);
            return returnResult;
        }
    }
}
