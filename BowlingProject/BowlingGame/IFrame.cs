
namespace BowlingGameSpace
{
    public interface IFrame
    {
        public int GetFirstRollResult();
        public int GetSecondRollResult();
        public FrameStatus GetFrameType();
        public void Roll();
    }

    public enum FrameStatus
    {
        Normal, Spare, Strike, LastSpare, LastStrike
    }
}
