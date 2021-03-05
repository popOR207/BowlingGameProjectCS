using System;

namespace BowlingGameSpace
{
    class BowlingGame
    {
        private const int _numberOfFrames = 10;
        private GameRollsHandler gameHandler = new GameRollsHandler(_numberOfFrames);
       
        public void StartGame()
        {
            gameHandler.StartGame();
        }

        public int GameTotalScore()
        {
            ResultHandler resultHandler = new ResultHandler(gameHandler.GetGameFrameList(), _numberOfFrames);
            return resultHandler.GetGameFinalScore();
        }

        static void Main(string[] args)
        {
            BowlingGame game = new BowlingGame();
            game.StartGame();
            int result = game.GameTotalScore();
            Console.WriteLine("game final result is: " + result);
        }
    }

}
