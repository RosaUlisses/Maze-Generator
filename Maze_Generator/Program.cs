// See https://aka.ms/new-console-template for more information
using Maze_Generator;

var mazeGenerator = new MazeGenerator(3, 3);
var maze = mazeGenerator.GenerateMaze(); 
mazeGenerator.printMaze(maze);

