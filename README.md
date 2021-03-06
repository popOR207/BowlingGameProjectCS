# BowlingGameProjectCS
Basic Bowling game, wrriten in C#. Was made as an exercise on C#'s design and code conventions.

Game workflow demands:

for every frame, The user is asked to fill in the number of pins he knocked down. If a bonus is granted the program will print “bonus”. The final score is presented to the user.

Flow explanation:

'BowlingGame' class holds the entry point to the program and can initiate the game process by calling the 'StartGame' method, which in turn calls the start method of the 'GameRollsHandler' instance. 'GameRollsHandler' single responsibility is to hold the game frames ('IFrame' interface) and manage their states by the result of the user's input, which itself is handled by an object who implements the IUserInput interface. when the game ends, the 'GetFinalScore' method can be called from the 'ResultHandler', who has the responsibility to calculate the game score by iterating over a List of 'IFrame' it will receive from the 'GameRollsHandler', based on the individuale 'FrameStatus' of each Frame.

How to run it:

to run the program an instance of BowlingGame need to be created with an instance of a Object who implements the 'IUserInput' interface. the program default Frame number is 10, which is not configurable from the outside. 
the 'StartGame' method will be called next, setting the collection of frames for the game.
finallly, the 'GetFinalScore' will return an int with the final score (max of 300 is possible in case of a perfect 10 frames game).

What i learned from this project:

the project was written only in C#, which i had no prior experience with, but was really interesting to learn; especially some of c#'s concepts that can eliminate a lot of unnecessary code. furthermore, the design process was a neat experience, and every time i disassembled the program and rebuild it i learned somthing new about correct, SOLID design; i had to find some creative solutions for setting the Frames and calculating the score in a way that will be seperated enough so the code will be maintainable and de-coupled, but not over-complicated.
i also learned a lot about how to test User-input based programs, which lead to a lot of other interesting discoveries.

What i could improve:

given more time, i would like to make the code into a multi-player game, supporting more then one player at a given time using a remote connection.
also, i would like to switch some of the current 'if/else'-dependent methods with a better, more maintainable design, and to add a WPF display.
