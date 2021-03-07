
namespace BowlingGameSpace
{
    public interface IFrame
    {
        public int FirstRollResult { get; set; }
        public int SecondRollResult { get; set; }
        public FrameStatus FrameType { get; set; }
    }

    public enum FrameStatus
    {
        Normal, Spare, Strike
    }
}
