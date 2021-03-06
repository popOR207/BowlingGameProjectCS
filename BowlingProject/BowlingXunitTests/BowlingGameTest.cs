using Xunit;
using BowlingGameSpace;

namespace BowlingXunitTests
{
    public class BowlingGameTest
    {
        [Fact]
        public void TestBowlingGameInit()
        {
            BowlingGame bg = new BowlingGame(null);
            Assert.True(bg != null);
        }

        [Fact]
        public void TestBowlingGameGameProcess()
        {
            BowlingGame bg = new BowlingGame(new TestPreSetInput(10, 0));
            Assert.True(bg != null);
        }
    }
}
