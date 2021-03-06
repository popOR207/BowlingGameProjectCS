using System.Collections.Generic;
using Xunit;
using BowlingGameSpace;

namespace BowlingXunitTests
{
    public class GameRollAndFrameTests
    {
        [Fact]
        public void NormaStatuslRollTest()
        {
            Frame frame1 = new Frame(FrameStatus.Normal, new TestPreSetInput(10, 0));
            frame1.Roll();
            Assert.True(frame1.GetFirstRollResult() == 10);
            Assert.True(frame1.GetSecondRollResult() == 0);

            Frame frame2 = new Frame(FrameStatus.Normal, new TestPreSetInput(10, 10));
            frame2.Roll();
            Assert.True(frame2.GetFirstRollResult() == 10);
            Assert.False(frame2.GetSecondRollResult() == 10);

            Frame frame3 = new Frame(FrameStatus.Normal, new TestPreSetInput(-54, 10));
            frame3.Roll();
            Assert.False(frame3.GetFirstRollResult() == -54);

            Frame frame4 = new Frame(FrameStatus.Normal, new TestPreSetInput(1, 2));
            frame4.Roll();
            Assert.True(frame4.GetFirstRollResult() == 1);
            Assert.True(frame4.GetSecondRollResult() == 2);

            Frame frame5 = new Frame(FrameStatus.Normal, new TestPreSetInput('a', 2));      
            frame5.Roll();
            Assert.False(frame5.GetFirstRollResult() == 'a');

            Frame frame6 = new Frame(FrameStatus.Normal, new TestPreSetInput('~', 2));      
            frame6.Roll();
            Assert.False(frame6.GetFirstRollResult() == '~');

            Frame frame7 = new Frame(FrameStatus.Normal, new TestPreSetInput(800000, 2));   //overflow
            frame7.Roll();
            Assert.False(frame7.GetFirstRollResult() == 800000);
        }

        [Fact]
        public void LastSpareFramelRollTest()
        {
            Frame frame1 = new Frame(FrameStatus.LastSpare, new TestPreSetInput(5, 0));
            frame1.Roll();
            Assert.True(frame1.GetFirstRollResult() == 5);

            Frame frame2 = new Frame(FrameStatus.LastSpare, new TestPreSetInput(10, 0));
            frame2.Roll();
            Assert.True(frame2.GetFirstRollResult() == 10);
        }

        [Fact]
        public void LastStrikeFramelRollTest()
        {
            Frame frame1 = new Frame(FrameStatus.LastStrike, new TestPreSetInput(5, 2));
            frame1.Roll();
            Assert.True(frame1.GetFirstRollResult() == 5);
            Assert.True(frame1.GetSecondRollResult() == 2);

            Frame frame2 = new Frame(FrameStatus.LastStrike, new TestPreSetInput(10, 0));
            frame2.Roll();
            Assert.True(frame2.GetFirstRollResult() == 10);
            Assert.True(frame2.GetSecondRollResult() == 0);

            Frame frame3 = new Frame(FrameStatus.LastStrike, new TestPreSetInput(0, 0));
            frame3.Roll();
            Assert.True(frame3.GetFirstRollResult() == 0);
            Assert.True(frame3.GetSecondRollResult() == 0);

        }

        [Fact]
        public void GameRollsHandlerTest()
        {
            GameRollsHandler g1 = new GameRollsHandler(10, new UserInput());
            GameRollsHandler g2 = new GameRollsHandler(2, new UserInput());
            GameRollsHandler g3 = new GameRollsHandler(15, new UserInput());

            Assert.True(g1 != null);
            Assert.True(g2 != null);
            Assert.True(g3 != null);

        }

        [Fact]
        public void UserInputTest()
        {
            GameRollsHandler g1 = new GameRollsHandler(10, new UserInput());
        }

        [Fact]
        public void correctRollsSetTest()
        {
            int[] arr = { 10, 0, 4, 4, 5, 4, 2, 2, 4, 6, 10, 0, 0, 0, 0, 10, 2, 2, 1, 8 };
            LinkedList<IFrame> fl1 = new LinkedList<IFrame>();
            int i = 0;
            for (int k = 0; k < 10; ++k)
            {
                fl1.AddLast(new Frame(FrameStatus.Normal, new TestPreSetInput(arr[i], arr[i + 1])));
                i += 2;
            }

            foreach (IFrame frame in fl1)
            {
                frame.Roll();
            }

            i = 0;
            foreach (IFrame frame in fl1)
            {
                Assert.True(frame.GetFirstRollResult() == arr[i]);
                Assert.True(frame.GetSecondRollResult() == arr[i + 1]);
                i += 2;
            }
        }
    }
}
