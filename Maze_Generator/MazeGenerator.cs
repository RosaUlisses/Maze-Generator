using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace Maze_Generator
{
    public class MazeGenerator
    {
        private int width;
        private int height;
        private  Random random;
        private readonly int maxNumberOfCoordinates;
        

        private const int MAZE_CELL_SIZE = 2;
        private const int WALL_SIZE = 1;

        private const int WALL = 1;
        private const int PASSAGE = 0;
        public MazeGenerator(int width, int height)
        {
            this.width = width;
            this.height = height;
            maxNumberOfCoordinates = height * width; 
            random = new Random();
        }   

        public int[,] GenerateMaze()
        {
            int[,] maze = new int[(width * MAZE_CELL_SIZE) + (width - 1) * WALL_SIZE, (height * MAZE_CELL_SIZE) + (height - 1) * WALL_SIZE];
            List<Coordinate> mazePath = BackTracking();

            
            for (int i = 0; i < mazePath.Count; i++)
            {
                if (i + 1 < mazePath.Count && mazePath[i].IsAdjacent(mazePath[i + 1]))
                {
                   SetWall(maze, mazePath[i], mazePath[i + 1]); 
                }
                if (i - 1 >= 0 && mazePath[i].IsAdjacent(mazePath[i - 1]))
                {
                   SetWall(maze, mazePath[i], mazePath[i - 1]); 
                }
            }

            for (int i = 0; i < maze.GetLength(0); i ++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    if (i == 0 || i == maze.GetLength(0) - 1)
                    {
                        maze[i, j] = WALL;
                    }
                    else if (j == 0 || j == maze.GetLength(1) - 1)
                    {
                        maze[i, j] = WALL;
                    }
                }
            }

            return maze;
        }

        public void printMaze(int[,] maze)
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                string s = "";
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    if (maze[i, j] == WALL) s += "* ";
                    else s += "  ";
                }
                Console.WriteLine(s);
            }           
        }

        private void SetWall(int[,] maze, Coordinate a, Coordinate b)
        {
            if (a.x != b.x)
            {
                for (int j = a.y; j < a.y + MAZE_CELL_SIZE + WALL_SIZE; j++)
                {
                    if(a.x == b.x + WALL_SIZE) maze[a.x + WALL_SIZE, j] = WALL;
                    else maze[b.x + WALL_SIZE, j] = WALL;
                }
            }
            else
            {
                for (int i = a.y; i < a.y + MAZE_CELL_SIZE + WALL_SIZE; i++)
                {
                    if(a.y == b.y - WALL_SIZE) maze[i, a.y + WALL_SIZE] = WALL;
                    else maze[i, b.y + WALL_SIZE] = WALL;
                }
            }
        }

        private List<Coordinate> BackTracking()
        {
            List<Coordinate> mazeCoordinates = new List<Coordinate>();
            HashSet<Coordinate> visited = new HashSet<Coordinate>();
            Stack<Coordinate> stack = new Stack<Coordinate>();
            List<Coordinate> adjacentCoordinates;

            Coordinate initialCoordinate = new Coordinate(0, 0);
            stack.Push(initialCoordinate);
            mazeCoordinates.Add(initialCoordinate);
            adjacentCoordinates = initialCoordinate.GetUnvisitedAdjacentCoordinates(width, height, visited); 

            while (visited.Count != maxNumberOfCoordinates)
            {
                Coordinate current = adjacentCoordinates[random.Next(adjacentCoordinates.Count)];
                visited.Add(current);
                mazeCoordinates.Add(current);

                adjacentCoordinates = current.GetUnvisitedAdjacentCoordinates(width, height, visited);
                while (adjacentCoordinates.Count == 0)
                {
                    Coordinate lastVisitedCoordinate = stack.Pop();
                    adjacentCoordinates = lastVisitedCoordinate.GetUnvisitedAdjacentCoordinates(width, height, visited);
                }
                stack.Push(current);
            }

            return mazeCoordinates;
        }
    }
}
