// See https://aka.ms/new-console-template for more information
using Maze_Generator;

var mazeGenerator = new MazeGenerator(10, 10);
var maze = mazeGenerator.GenerateMaze(); 
mazeGenerator.printMaze(maze);

