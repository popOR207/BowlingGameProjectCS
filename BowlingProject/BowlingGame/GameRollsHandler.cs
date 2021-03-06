using System;
using System.Collections.Generic;

namespace BowlingGameSpace
{
    public class GameRollsHandler
    {
        private LinkedList<IFrame> gameFrames = new LinkedList<IFrame>();
        private readonly int _numberOfFrames;
        private readonly IUserInput userInputHandler;

        public GameRollsHandler(int numOfFrames, IUserInput userInputHandler)
        {
            this.userInputHandler = userInputHandler;
            this._numberOfFrames = numOfFrames;
            for (int i = 0; i < _numberOfFrames; ++i)
            {
                gameFrames.AddFirst(new Frame(FrameStatus.Normal, userInputHandler));
            }
        }

        public void StartGame()
        {
            int turnCount = 0;
            foreach (IFrame frame in gameFrames)
            {
                Console.WriteLine($"Frame { turnCount + 1} - roll.");
                frame.Roll();
                ++turnCount;
            }
            LastTurn();
        }

        private void LastTurn()
        {
            FrameStatus lastFrameType = gameFrames.Last.Value.GetFrameType();

            switch (lastFrameType)
            {
                case FrameStatus.Strike:
                    AddExtraFrame(FrameStatus.LastStrike);
                    if (gameFrames.Last.Value.GetFrameType() == FrameStatus.Strike)
                    {
                        AddExtraFrame(FrameStatus.LastSpare);
                    }
                    break;
                case FrameStatus.Spare:
                    AddExtraFrame(FrameStatus.LastSpare);
                    break;
                default:
                    break;
            }
        }

        private void AddExtraFrame(FrameStatus frameType)
        {
            IFrame frame = new Frame(frameType, userInputHandler);
            frame.Roll();
            gameFrames.AddLast(frame);
        }

        public LinkedList<IFrame> GetGameFrameList()
        {
            return gameFrames;
        }
    }
}
