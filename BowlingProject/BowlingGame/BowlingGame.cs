using System;

namespace BowlingGameSpace
{
    public class BowlingGame
    {
        private const int _numberOfFrames = 10;
        private GameRollsHandler gameHandler;
    
        public BowlingGame(IUserInput userInputHandler)
        {
            gameHandler = new GameRollsHandler(_numberOfFrames, userInputHandler);
        }

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
            BowlingGame game = new BowlingGame(new UserInput());
            game.StartGame();
            int result = game.GameTotalScore();
            Console.WriteLine("Ginal game result is: " + result);
        }
    }

}
