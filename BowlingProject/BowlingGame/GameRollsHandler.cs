using System;
using System.Collections.Generic;

namespace BowlingGameSpace
{
    public class GameRollsHandler
    {
        private LinkedList<IFrame> gameFrames = new LinkedList<IFrame>();
        private readonly IUserInput userInputHandler;
        private readonly int _numberOfFrames;
        private const int _maxRoll = 10;

        public GameRollsHandler(int numOfFrames, IUserInput userInputHandler)
        {
            this.userInputHandler = userInputHandler;
            this._numberOfFrames = numOfFrames;
            for (int i = 0; i < _numberOfFrames; ++i)
            {
                gameFrames.AddFirst(new Frame(FrameStatus.Normal));
            }
        }

        internal LinkedList<IFrame> GetGameFrameList()
        {
            return gameFrames;
        }

        internal void StartGame()
        {
            int turnCount = 0;
            foreach (IFrame frame in gameFrames)
            {
                Console.WriteLine($"Frame { turnCount + 1} - roll.");
                SetFrameRolls(frame);
                ++turnCount;
            }
            LastTurn();
        }

        private void LastTurn()
        {
            FrameStatus lastFrameType = gameFrames.Last.Value.FrameType;

            switch (lastFrameType)
            {
                case FrameStatus.Strike:
                    AddExtraFrame(FrameStatus.Strike);
                    if (gameFrames.Last.Value.FrameType == FrameStatus.Strike)
                    {
                        Console.WriteLine("last spare added");
                        AddExtraFrame(FrameStatus.Spare);
                    }
                    break;
                case FrameStatus.Spare:
                    AddExtraFrame(FrameStatus.Spare);
                    break;
                default:
                    break;
            }
        }

        private void SetFrameRolls(IFrame currentFrame)
        {
            if (currentFrame.FrameType.Equals(FrameStatus.Normal))
            {
                NormalFrameRoll(currentFrame);
            }
            else
            {
                LastFrameRoll(currentFrame);
            }
        }

        private void AddExtraFrame(FrameStatus frameType)
        {
            IFrame frame = new Frame(frameType);
            gameFrames.AddLast(frame);
            SetFrameRolls(frame);
        }

        private void NormalFrameRoll(IFrame currentFrame)
        {
            currentFrame.FirstRollResult = RollResult(currentFrame);
            if (_maxRoll == currentFrame.FirstRollResult)
            {
                Console.WriteLine("Bonus! strike!!");
                currentFrame.FrameType = FrameStatus.Strike;
            }
            else
            {
                currentFrame.SecondRollResult = RollResult(currentFrame);
                if (_maxRoll == currentFrame.FirstRollResult + currentFrame.SecondRollResult)
                {
                    Console.WriteLine("Bonus! spare!");
                    currentFrame.FrameType = FrameStatus.Spare;
                }
            }
        }

        private void LastFrameRoll(IFrame currentFrame)
        {
            if (currentFrame.FrameType.Equals(FrameStatus.Spare))
            {
                currentFrame.FirstRollResult = RollResult(currentFrame);
            }
            else if (currentFrame.FrameType.Equals(FrameStatus.Strike))
            {
                NormalFrameRoll(currentFrame);
            }
        }

        private int RollResult(IFrame currentFrame)
        {
            int throwRange = _maxRoll - currentFrame.FirstRollResult;
            int returnResult;
            do
            {
                Console.WriteLine($"Choose a number between 0 - {throwRange}");
                returnResult = userInputHandler.GetUserInput();
            }
            while (returnResult < 0 || returnResult > throwRange);
            return returnResult;
        }
    }
}

