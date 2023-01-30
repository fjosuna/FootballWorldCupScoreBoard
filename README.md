# Football World Cup Score Board Solution	
	The solution include the following projects:
	

## FootballWorldCupScoreBoard.Business	
	Library that implements requirements to execute the operations on matches.
	
	Include the following clases:

	* Class Game.- Its  responsibility is to store  match's info like home team, away team, score home team and score away team. Implements the following methods:
		- Getter for home team, away team, score home team and score away team properties
		- Constructor method to init the object 
		- UpdateScore method to change score of the match 

	* Class Scoreboard.- Its responsibility is to store and management a list of matches. Implements the following methods:
		- StartGame.- Create a new game into the list. If the match already exists throw an Exception
		- UpdateScore.- Change the score of a match. If the match does not exists  throw an Exception
		- FinishGame.- Remove the match of the list. If the match does not exists  throw an Exception
		- GetGamesByTotalScoreDesc.- Get a summary of games by total score. Those games with the same total score will be returned ordered by the most recently added to our system.

## FootballWorldCupScoreBoard.Business.Test
	Project that implements the tests of every method of Game and Scoreboard class from FootballWorldCupScoreBoard.Business library
	

## FootballWorldCupScoreBoard.Console
	Console application to use FootballWorldCupScoreBoard.Business library
	* Class Program.- Implements a Main method that show a menu with the following operations:
		- Exit of program
		- Start a game
		- Update a score game
		- Get a summary of games by total score
		
## Notes		
	I have tried to follow SOLID, keep it simple and clean code principles.
	I have followed a test driven development to implement each operation.	
		
	
