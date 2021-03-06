using System.Collections.Generic;
using Xunit;
using BowlingGameSpace;
using System.Linq;
using System;

namespace BowlingXunitTests
{
    public class BowlingGameDirectTest
    {
        private readonly int _numberOfFrames = 10;

        [Fact]
        public void FinalResultNoFinalBonuseCalculationTest()
        {
            int[] arr1 = { 10, 0, 4, 4, 5, 4, 2, 2, 4, 6, 10, 0, 0, 0, 0, 10, 2, 2, 1, 8 };          
            ResultHandler resultHandler1 = new ResultHandler(SetListForTest(arr1, _numberOfFrames), _numberOfFrames);
            Assert.True(resultHandler1.GetGameFinalScore() == 94);

            int[] arr2 = { 5, 0, 5, 0, 5, 0, 5, 0, 5, 0, 5, 0, 5, 0, 5, 0, 5, 0, 5, 0 };
            ResultHandler resultHandler2 = new ResultHandler(SetListForTest(arr2, _numberOfFrames), _numberOfFrames);
            Assert.True(resultHandler2.GetGameFinalScore() == 50);

            int[] arr3 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            ResultHandler resultHandler3 = new ResultHandler(SetListForTest(arr3, _numberOfFrames), _numberOfFrames);
            Assert.True(resultHandler3.GetGameFinalScore() == 0);

            int[] arr4 = { 10, 0, 5, 4, 0, 0, 10, 0, 0, 10, 3, 4, 5, 5, 0, 8, 0, 0, 0, 9 };
            ResultHandler resultHandler4 = new ResultHandler(SetListForTest(arr4, _numberOfFrames), _numberOfFrames);
            Assert.True(resultHandler4.GetGameFinalScore() == 95);

            int[] arr5 = { 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 5, 5, 2, 2 };
            ResultHandler resultHandler5 = new ResultHandler(SetListForTest(arr5, _numberOfFrames), _numberOfFrames);
            Assert.True(resultHandler5.GetGameFinalScore() == 241);


        }


        [Fact]
        public void FinalResultWithFinalBonuseCalculationTest()
        {
            int[] arr1 = { 10, 0, 4, 4, 5, 4, 2, 2, 4, 6, 10, 0, 0, 0, 0, 10, 10, 0, 1, 8 };         
            ResultHandler resultHandler1 = new ResultHandler(SetListForTest(arr1, 10), _numberOfFrames);
            Assert.True(resultHandler1.GetGameFinalScore() == 117);
            
            int[] arr2 = { 5, 0, 5, 0, 5, 0, 5, 0, 5, 0, 5, 0, 5, 0, 5, 0, 10, 0, 10, 0, 10, 0, 4, 0};
            ResultHandler resultHandler2 = new ResultHandler(SetListForTest(arr2, 12), _numberOfFrames);
            Assert.True(resultHandler2.GetGameFinalScore() == 94);

            int[] arr3 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 0, 10, 0, 4, 4};
            ResultHandler resultHandler3 = new ResultHandler(SetListForTest(arr3, 11), _numberOfFrames);
            Assert.True(resultHandler3.GetGameFinalScore() == 42);

            int[] arr4 = { 10, 0, 5, 4, 0, 0, 10, 0, 0, 10, 3, 4, 5, 5, 0, 8, 0, 0, 1, 9, 4, 0};
            ResultHandler resultHandler4 = new ResultHandler(SetListForTest(arr4, 11), _numberOfFrames);
            Assert.True(resultHandler4.GetGameFinalScore() == 100);

            int[] arr5 = { 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 5, 5, 8, 2 , 10, 0};
            ResultHandler resultHandler5 = new ResultHandler(SetListForTest(arr5, 11), _numberOfFrames);
            Assert.True(resultHandler5.GetGameFinalScore() == 263);

            int[] arr6 = { 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0};
            ResultHandler resultHandler6 = new ResultHandler(SetListForTest(arr6, 12), _numberOfFrames);
            Assert.True(resultHandler6.GetGameFinalScore() == 300);
        }

        public LinkedList<IFrame> SetListForTest(int[] arr, int numOfFrames)
        {
            LinkedList<IFrame> fl = new LinkedList<IFrame>();
            int i = 0;
            for (int k = 0; k < numOfFrames; ++k)
            {
                Frame frame = new Frame(FrameStatus.Normal);
                SetFrameValues(frame, arr[i], arr[i + 1]);
                 if (10 == arr[i])
                {
                    ((IFrame)frame).FrameType = FrameStatus.Strike;
                } 
                 else if (10 == arr[i] + arr[i +1])
                {
                    ((IFrame)frame).FrameType = FrameStatus.Spare;
                }
                fl.AddLast(frame);

                i += 2;
            }

            return fl;
        }

        public void SetFrameValues(IFrame frame, int a, int b)
        {
            frame.FirstRollResult = a;
            frame.SecondRollResult = b;
        }
    }
}
