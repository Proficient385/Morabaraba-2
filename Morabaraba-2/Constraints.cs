using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace Morabaraba_2
{
    class Constraints
    {
        Player Player1;
        Player Player2;

        List<Point> validPos;
        string currentPlayer;
        Canvas brd;
        public Constraints(Ellipse piece1, Ellipse piece2, Canvas brd)
        {
            this.brd = brd;
            Player1 = new Player("Red", piece1, brd);
            Player2 = new Player("Yellow", piece2, brd);
            currentPlayer = "Red";
            validPos = validPosiitons();
        }

        private int xCordinate (double divider)
        {
            return Convert.ToInt32((brd.ActualWidth / divider));
        }

        private int yCordinate(double divider)
        {
            return Convert.ToInt32((brd.ActualHeight / divider));
        }
        private List<Point> validPosiitons()
        {
            List<Point> result = new List<Point>();
            // A---
            result.Add(new Point(xCordinate(4.03), yCordinate(9.05)));
            result.Add(new Point(xCordinate(2.007), yCordinate(9.05)));
            result.Add(new Point(xCordinate(1.335), yCordinate(9.05)));
            // B--
            result.Add(new Point(xCordinate(3.01), yCordinate(3.94)));
            result.Add(new Point(xCordinate(2.007), yCordinate(3.94)));
            result.Add(new Point(xCordinate(1.505), yCordinate(3.94)));
            // C--
            result.Add(new Point(xCordinate(2.415), yCordinate(2.54)));
            result.Add(new Point(xCordinate(2.007), yCordinate(2.54)));
            result.Add(new Point(xCordinate(1.716), yCordinate(2.54)));
            // D---
            result.Add(new Point(xCordinate(4.03), yCordinate(1.868)));
            result.Add(new Point(xCordinate(3.01), yCordinate(1.868)));
            result.Add(new Point(xCordinate(2.415), yCordinate(1.868)));
            result.Add(new Point(xCordinate(1.716), yCordinate(1.868)));
            result.Add(new Point(xCordinate(1.505), yCordinate(1.868)));
            result.Add(new Point(xCordinate(1.335), yCordinate(1.868)));
            // E--
            result.Add(new Point(xCordinate(2.415), yCordinate(1.475)));
            result.Add(new Point(xCordinate(2.007), yCordinate(1.475)));
            result.Add(new Point(xCordinate(1.716), yCordinate(1.475)));
            // F--
            result.Add(new Point(xCordinate(3.01), yCordinate(1.222)));
            result.Add(new Point(xCordinate(2.007), yCordinate(1.222)));
            result.Add(new Point(xCordinate(1.505), yCordinate(1.222)));
            // G--
            result.Add(new Point(xCordinate(4.03), yCordinate(1.042)));
            result.Add(new Point(xCordinate(2.007), yCordinate(1.042)));
            result.Add(new Point(xCordinate(1.335), yCordinate(1.042)));
            return result;
        }

        private string swapPlayer(string player)
        {
            return player == "Red" ? "Yellow" : "Red";
        }

        public void gamePlay(Point p)
        {
            foreach (Point point in validPos)
            {
                if (Math.Abs(p.X - point.X) <= 70 && Math.Abs(p.Y - point.Y) <= 70)
                {
                    p = point;
                    break;
                }
            }
            
            if (currentPlayer == "Red") Player1.makeMove(p);
            else Player2.makeMove(p);

            currentPlayer = swapPlayer(currentPlayer);
        }
    }
}
