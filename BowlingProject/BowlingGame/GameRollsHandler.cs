using System;
using System.Collections.Generic;

namespace BowlingGameSpace
{
    class GameRollsHandler
    {
        private List<IFrame> gameFrames = new List<IFrame>();
        private readonly int _numberOfFrames;

        public GameRollsHandler(int numOfFrames)
        {
            this._numberOfFrames = numOfFrames;
            for (int i = 0; i < _numberOfFrames; ++i)
            {
                gameFrames.Add(new Frame(FrameStatus.Normal));
            }
        }

        public void StartGame()
        {
            int turnCount = 0;
            foreach (IFrame frame in gameFrames)
            {
                Console.WriteLine($"turn { turnCount + 1} go!");
                gameFrames[turnCount].Roll();
                ++turnCount;
            }
            LastTurn();
        }

        private void LastTurn()
        {
            int lastTurn = _numberOfFrames - 1;
            FrameStatus lastFrameType = gameFrames.FindLast(x => true).GetFrameType();

            switch (lastFrameType)
            {
                case FrameStatus.Strike:
                    AddExtraFrame(FrameStatus.LastStrike);
                    if (gameFrames.FindLast(x=>true).GetFrameType() == FrameStatus.Strike)
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
            IFrame frame = new Frame(frameType);
            frame.Roll();
            gameFrames.Add(frame);
        }

        public List<IFrame> GetGameFrameList()
        {
            return gameFrames;
        }
    }
}
