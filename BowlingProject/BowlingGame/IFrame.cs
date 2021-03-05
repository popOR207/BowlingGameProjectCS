
namespace BowlingGameSpace
{
    interface IFrame
    {
        public int GetFirstRollResult();
        public int GetSecondRollResult();
        public FrameStatus GetFrameType();
        public void Roll();
    }

    enum FrameStatus
    {
        Normal, Spare, Strike, LastSpare, LastStrike
    }
}
