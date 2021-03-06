using System.Collections.Generic;
using System.Linq;
using System;

namespace BowlingGameSpace
{
    public class ResultHandler
    {
        private LinkedList<IFrame> totalFrames;
        private readonly int _numberOfFrames;

        public ResultHandler(LinkedList<IFrame> totalFrames, int numOfFrames)
        {
            this._numberOfFrames = numOfFrames;
            this.totalFrames = totalFrames;
        }

        public int GetGameFinalScore()
        {
            int finalResult = 0;
            LinkedListNode<IFrame> currentNode = totalFrames.First;

            foreach (IFrame currentFrame in totalFrames.Take(_numberOfFrames))
            {
                finalResult += currentFrame.GetFirstRollResult() +
                    currentFrame.GetSecondRollResult() +
                    CalculateBonusPoints(currentFrame.GetFrameType(), currentNode);
                currentNode = currentNode.Next;
            }
            return finalResult;
        }

        private int CalculateBonusPoints(FrameStatus frameType, LinkedListNode<IFrame> currentNode)
        {
            int addedBonus = 0;
            switch (frameType)
            {
                case FrameStatus.Spare:
                    addedBonus = currentNode.Next.Value.GetFirstRollResult();
                    break;
                case FrameStatus.Strike:
                    addedBonus = GetStrikeBonus(currentNode);
                    break;
                default:
                    break;
            }
            return addedBonus;
        }

        private int GetStrikeBonus(LinkedListNode<IFrame> currentNode)
        {
            int result = currentNode.Next.Value.GetFirstRollResult();

            if (currentNode.Next.Value.GetFrameType().Equals(FrameStatus.Strike))
            {
                result += currentNode.Next.Next.Value.GetFirstRollResult();
            }
            else
            {
                result += currentNode.Next.Value.GetSecondRollResult();
            }
            return result;
        }
    }
}
