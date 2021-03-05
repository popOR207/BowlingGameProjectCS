# BowlingGameProjectCS
Basic Bowling game, wrriten in C#. Was made as an exercise on C#'s design and code conventions.

Game workflow demands:

for every frame, The user is asked to fill in the number of pins he knocked down. If a bonus is granted the program will print “bonus”. The final score is presented to the user.

Flow explanation:

'BowlingGame' class holds the entry point to the program and can initiate the game process by calling the 'StartGame' method, which in turn calls the start method of the 'GameRollsHandler' instance. 'GameRollsHandler' single responsibility is to hold the game frames ('IFrame' interface) and manage their states by the user input. when the game ends, the 'GetFinalScore' method can be called from the 'ResultHandler', who has the responsibility to calculate the game score by iterating over a List of 'IFrame' it will receive from the 'GameRollsHandler', based on the individuale 'FrameStatus' of each Frame.

How to run it:

to run the program an instance of BowlingGame need to be created. the program default Frame number is 10, which is not configurable from the outside. the 'StartGame' method should be called. the 'GetFinalScore' will return an int with the final score (max of 300 in case of 10 frames game).

What i learned from this project:

the project was written only in C#, which i had no prior experience with, but was really interesting to learn. c# presented me with new OOP abilities i was not familiar with, and new design concepts that can same a lot of unnecessary code. furthermore, the design process was really interesting, and every time i break down a program and try to rebild it i learn somthing new about correct, SOLID design; i had to find some creative solutions for setting the Frames and calculating the score in a way that will be seperated enough so the code will be maintainable and de-coupled, but not over-complicated.

What i could improve:
given more time, i would like to make the code into a multi-player game, supporting more the one player at a given time using a remote connection.
also, i would like to switch some of the current 'if/else'-dependent methods with a better, more maintainable design. 
