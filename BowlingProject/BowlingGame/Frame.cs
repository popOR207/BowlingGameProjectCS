using System;

namespace BowlingGameSpace
{
    public class Frame : IFrame
    {
        private FrameStatus frameType;
        private int firstRollResult;
        private int secondRollResult;

        public int FirstRollResult {get{ return firstRollResult;} set { firstRollResult = value;}}
        public int SecondRollResult {get{return secondRollResult; } set {secondRollResult = value; }}
        public FrameStatus FrameType {get{return frameType;}set{frameType = value;}}

        public Frame(FrameStatus frameType)
        {
            this.frameType = frameType;
        }
    }
}
