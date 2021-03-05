using System.Collections.Generic;
using System.Linq;

namespace BowlingGameSpace
{
    class ResultHandler
    {
        private List<IFrame> totalFrames;
        private readonly int _numberOfFrames;

        public ResultHandler(List<IFrame> totalFrames, int numOfFrames)
        {
            this._numberOfFrames = numOfFrames;
            this.totalFrames = totalFrames;
        }

        public int GetGameFinalScore()
        {
            int finalResult = 0;
            int currentFrameIndex = 0;

            foreach (IFrame frame in totalFrames.Take(_numberOfFrames))
            {
                IFrame currentFrame = totalFrames[currentFrameIndex];            
                finalResult += currentFrame.GetFirstRollResult() +
                    currentFrame.GetSecondRollResult() +
                    CalculateBonusPoints(currentFrame.GetFrameType(), currentFrameIndex);
                ++currentFrameIndex;
            }
            return finalResult;
        }

        private int CalculateBonusPoints(FrameStatus frameType, int turn)
        {
            int addedBonus = 0;
            switch (frameType)
            {
                case FrameStatus.Spare:
                    addedBonus = totalFrames[turn + 1].GetFirstRollResult();
                    break;
                case FrameStatus.Strike:
                    addedBonus = getStrikeBonus(turn);
                    break;
                default:
                    break;
            }
            return addedBonus;
        }

        private int getStrikeBonus(int currentTurn)
        {
            int result = totalFrames[currentTurn + 1].GetFirstRollResult();

            if (totalFrames[currentTurn + 1].GetFrameType().Equals(FrameStatus.Strike))
            {
                result += totalFrames[currentTurn + 2].GetFirstRollResult();
            }
            else
            {
                result += totalFrames[currentTurn + 1].GetSecondRollResult();
            }
            return result;
        }
    }
}
