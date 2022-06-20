using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Generator
{
    public class Coordinate
    {
         public int x { get; private set; }
         public int y { get; private set; }

         public Coordinate(int x, int y)
         {
             this.x = x;
             this.y = y;
         }
         private List<Coordinate> getAdjacentCells(int maxWidth, int maxHeight)
         {
            List<Coordinate> adjacentCells = new List<Coordinate>();

            if (x + 1 >= 0 && x + 1 < maxWidth && y >= 0 && y < maxHeight)
            {
                adjacentCells.Add(new Coordinate(x + 1, y));
            }
            if (x - 1 >= 0 && x - 1 < maxWidth && y >= 0 && y < maxHeight)
            {
                adjacentCells.Add(new Coordinate(x - 1, y));
            }
            if (x >= 0 && x < maxWidth && y + 1 >= 0 && y + 1 < maxHeight)
            {
                adjacentCells.Add(new Coordinate(x, y + 1));
            }
            if (x >= 0 && x < maxWidth && y - 1 >= 0 && y - 1 < maxHeight) 
            {
                adjacentCells.Add(new Coordinate(x, y - 1));
            }

            return adjacentCells;
         }
         public override bool Equals(object? obj)
         {
             if (obj == null || this.GetType() != obj.GetType())
             {
                 return false;
             }

             else
             {
                 Coordinate coordinate = (Coordinate) obj;
                 return (x == x && y == y) ? true : false;
             }
         }
         public override int GetHashCode()
         {
            int X = x >= 0 ? 2 * x : -2 * x - 1;
            int Y = y >= 0 ? 2 * y : -2 * y - 1;
            return X >= Y ? X * X + X + Y : X + Y * Y;
        }
    }
}
