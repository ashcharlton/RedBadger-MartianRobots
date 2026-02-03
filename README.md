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
	- XPosition - int
	- YPosition - int
	- Direction - string/enum
	- ProcessInstructions(List<string>, Grid) - Passing in the grid to this function so that the robot knows the constraints of the grid.
	
Grid
	- MaxXCoord - int
	- MaxYCoord - int
	- Scents - HashSet<int, int>  *using a hashset as it's quicker than a list but also it won't add duplicates as we don't need to store the same scent coords twice.
	
Direction
	N,
	E,
	S,
	W
	
Action
	F,
	R,
	L

## Running
- To run the application, you just need to hit run. I have supplied a SampleData.txt file that gets copied to the build folder.

## Approach
- My approach was to decide on the different entities or actors that will be needed. Grid and Robot were the 2 main ones. I went with a C# CLI tool as that's the most simplest option I could think of.
- I chose C# as that's my main/strongest back end language and the quickest for me to get up and running.
- While my approach wasn't strictly TDD, I did write unit tests as I went along. 
- I also attempted the code first, then went back to simplify where I could. 
- I also abstracted out the code that orchestrates the grid and robot creation so that it can be tested.
- I tried to keep a lot of the logic for each entity on the entity itself so that they don't get too coupled with the orchestrator code and only passing in the entities when needed rather than passing them at instantiation. Further decoupling the code.


## Notes
- I assumed adding and subtracting to the directions would allow me to rotate around the compass.
- I wrote a test to test this for turning left, but the test failed as I have a negative direction. 
- Solution: Given that the directions are essentially base 4 (0,1,2,3) and the direction needs to remain positive, we can simply add 3 instead of subtracting 1 to loop round and end up at the previous direction. 
- The direction now went above 3 and so we need to make sure it's always within the base 4 range. Mod 4 the final direction.
- I wrote a test to test the adding of a scent. It wasn't working, I then realised I had the increment logic wrong for moving. I was incrementing the wrong direction. 
- Added Integration tests to test the orchestration of the sample data.
- I have included the sample data in SampleData.txt. Just run the project to see the output.