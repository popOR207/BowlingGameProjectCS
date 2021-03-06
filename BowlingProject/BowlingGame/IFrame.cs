
namespace BowlingGameSpace
{
    public interface IFrame
    {
        public int FirstRollResult { get; set; }
        public int SecondRollResult { get; set; }
        public FrameStatus FrameType { get; set; }
        // public void Roll();
    }

    public enum FrameStatus
    {
        Normal, Spare, Strike, LastSpare, LastStrike
    }
}
