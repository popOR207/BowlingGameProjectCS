using System;

namespace BowlingGameSpace
{
    public class Frame : IFrame
    {
        private FrameStatus frameType;

        int IFrame.FirstRollResult { get ; set ; }
        int IFrame.SecondRollResult { get ; set ; }
        FrameStatus IFrame.FrameType { get ; set; }

        public Frame(FrameStatus frameType)
        {
            this.frameType = frameType;
        }

    }
}
