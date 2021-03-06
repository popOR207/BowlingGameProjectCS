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
            IFrame frame1 = new Frame(FrameStatus.Normal);
            SetFrameValues(frame1, 10, 0);

            Assert.True(frame1.FirstRollResult == 10);
            Assert.True(frame1.SecondRollResult == 0);

            IFrame frame2 = new Frame(FrameStatus.Normal);
            SetFrameValues(frame2, 10, 10);

            Assert.True(frame2.FirstRollResult == 10);
            Assert.False(frame2.SecondRollResult == 10);

            IFrame frame3 = new Frame(FrameStatus.Normal);
            SetFrameValues(frame3, -54, 10);
            Assert.False(frame3.FirstRollResult == -54);

            IFrame frame4 = new Frame(FrameStatus.Normal);
            SetFrameValues(frame4, 1, 2);
            Assert.True(frame4.FirstRollResult == 1);
            Assert.True(frame4.SecondRollResult == 2);

            IFrame frame5 = new Frame(FrameStatus.Normal);
            SetFrameValues(frame5, 'a', 10);
            Assert.False(frame5.FirstRollResult == 'a');

            IFrame frame6 = new Frame(FrameStatus.Normal);
            SetFrameValues(frame6, '~', 2);
            Assert.False(frame6.FirstRollResult == '~');

            IFrame frame7 = new Frame(FrameStatus.Normal);   //overflow
            SetFrameValues(frame7, 888800000, 2);
            Assert.False(frame7.FirstRollResult == 888800000);

            IFrame frame8 = new Frame(FrameStatus.LastSpare);
            SetFrameValues(frame8, 5, 2);
            Assert.True(frame8.FirstRollResult == 5);

            IFrame frame9 = new Frame(FrameStatus.LastSpare);
            SetFrameValues(frame9, 10, 0);
            Assert.True(frame9.FirstRollResult == 10);

        }

        

        [Fact]
        public void LastSpareFramelRollTest()
        {
            
        }

        [Fact]
        public void LastStrikeFramelRollTest()
        {
            IFrame frame1 = new Frame(FrameStatus.LastStrike);
            SetFrameValues(frame1, 5, 2);
            Assert.True(frame1.FirstRollResult == 5);
            Assert.True(frame1.SecondRollResult == 2);

            IFrame frame2 = new Frame(FrameStatus.LastStrike);
            SetFrameValues(frame2, 10, 0);
            Assert.True(frame2.FirstRollResult == 10);
            Assert.True(frame2.SecondRollResult == 0);

            IFrame frame3 = new Frame(FrameStatus.LastStrike);
            SetFrameValues(frame3, 0, 0);
            Assert.True(frame3.FirstRollResult == 0);
            Assert.True(frame3.SecondRollResult == 0);

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

   
        public void SetFrameValues(IFrame frame, int a, int b)
        {
            UserInput ui = new UserInput();

            frame.FirstRollResult = ui;
            frame.SecondRollResult = b;
        }
    }
}
