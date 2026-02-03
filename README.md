# RedBadger-MartianRobots
## Requirements
Place robots on a grid and process a set of instructions sequencially. (1 robot at a time)
The robot can only move one grid space at a time.
The robot can only rotate 90 degrees left or right at a time.
The robot has a cardinal direction that it is facing in (N,E,S,W).
The grid can be a maximum of 50 across and 50 high.
The robot should have <100 instructions
A robot can fall off the grid, if it does then it leaves a scent. 
If a robot is about to fall off the grid where there is a scent, then the robot ignores the instruction and moves to the next instruction.
The output should be the robots final position and orientation. If the robot is off grid, then print LOST after it's position.

Entities:

Robot
	* XPosition - int
	* YPosition - int
	* Direction - string/enum
	* ProcessInstructions(List<string>, Grid) - Passing in the grid to this function so that the robot knows the constraints of the grid.
	
Grid
	* MaxXCoord - int
	* MaxYCoord - int
	* Scents - HashSet<int, int>  *using a hashset as it's quicker than a list but also it won't add duplicates as we don't need to store the same scent coords twice.
	
Direction
	N,
	E,
	S,
	W
	
Action
	F,
	R,
	L
	
