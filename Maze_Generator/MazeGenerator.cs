using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
        public MazeGenerator(int width, int height)
        {
            this.width = width;
            this.height = height;
            random = new Random();
        }

        public int[,] GenerateMaze()
        {
            return null;
        }

        public List<Coordinate> BackTracking()
        {
            //const int numberOfCells
            List<Coordinate> mazeCells = new List<Coordinate>();
            HashSet<Coordinate> visited = new HashSet<Coordinate>();
            Stack<Coordinate> stack = new Stack<Coordinate>();

            // while(visited.Count < )


            return null;
        }



    }
}
