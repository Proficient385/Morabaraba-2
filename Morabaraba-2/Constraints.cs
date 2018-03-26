﻿using System;
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
        private Player Player1;
        private Player Player2;

        private List<Point> validPos;
        private string currentPlayer;
        private Canvas brd;

        private List<List<Point>> possibleMills;
        public Constraints(Ellipse piece1, Ellipse piece2, Canvas brd)
        {
            this.brd = brd;
            Player1 = new Player("Red", piece1, brd);
            Player2 = new Player("Yellow", piece2, brd);
            currentPlayer = "Red";
            validPos = validPosiitons();
            possibleMills = mill_Possibilities();
            //MessageBox.Show("Length: " + possibleMills.Count());
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

        private List<List<Point>> mill_Possibilities()
        {
            List<List<Point>> result = new List<List<Point>>();
            Point a1 = new Point(xCordinate(4.03), yCordinate(9.05));
            Point a4 = new Point(xCordinate(2.007), yCordinate(9.05));
            Point a7 = new Point(xCordinate(1.335), yCordinate(9.05));

            List<Point> mill = new List<Point>{ a1, a4, a7 };
            result.Add(mill);

            Point b2 = new Point(xCordinate(3.01), yCordinate(3.94));
            Point b4 = new Point(xCordinate(2.007), yCordinate(3.94));
            Point b6 = new Point(xCordinate(1.505), yCordinate(3.94));

            mill = new List<Point> { b2, b4, b6 };
            result.Add(mill);

            Point c3 = new Point(xCordinate(2.415), yCordinate(2.54));
            Point c4 = new Point(xCordinate(2.007), yCordinate(2.54));
            Point c5 = new Point(xCordinate(1.716), yCordinate(2.54));

            mill = new List<Point> { c3, c4, c5 };
            result.Add(mill);

            Point d1 = new Point(xCordinate(4.03), yCordinate(1.868));
            Point d2 = new Point(xCordinate(3.01), yCordinate(1.868));
            Point d3 = new Point(xCordinate(2.415), yCordinate(1.868));

            mill = new List<Point> { d1, d2, d3 };
            result.Add(mill);

            Point d5 = new Point(xCordinate(1.716), yCordinate(1.868));
            Point d6 = new Point(xCordinate(1.505), yCordinate(1.868));
            Point d7 = new Point(xCordinate(1.335), yCordinate(1.868));

            mill = new List<Point> { d5, d6, d7 };
            result.Add(mill);

            Point e3 = new Point(xCordinate(2.415), yCordinate(1.475));
            Point e4 = new Point(xCordinate(2.007), yCordinate(1.475));
            Point e5 = new Point(xCordinate(1.716), yCordinate(1.475));

            mill = new List<Point> { e3, e4, e5 };
            result.Add(mill);

            Point f2 = new Point(xCordinate(3.01), yCordinate(1.222));
            Point f4 = new Point(xCordinate(2.007), yCordinate(1.222));
            Point f6 = new Point(xCordinate(1.505), yCordinate(1.222));

            mill = new List<Point> { f2, f4, f6 };
            result.Add(mill);

            Point g1 = new Point(xCordinate(4.03), yCordinate(1.042));
            Point g4 = new Point(xCordinate(2.007), yCordinate(1.042));
            Point g7 = new Point(xCordinate(1.335), yCordinate(1.042));

            mill = new List<Point> { g1, g4, g7 };
            result.Add(mill);
            mill = new List<Point> { a1, b2, c3 };
            result.Add(mill);
            mill = new List<Point> { a1, d1, g1 };
            result.Add(mill);
            mill = new List<Point> { a4, b4, c4 };
            result.Add(mill);
            mill = new List<Point> { a7, b6, c5 };
            result.Add(mill);
            mill = new List<Point> { a7, d7, g7 };
            result.Add(mill);
            mill = new List<Point> { b2, d2, f2 };
            result.Add(mill);
            mill = new List<Point> { b6, d6, f6 };
            result.Add(mill);
            mill = new List<Point> { c3, d3, e3 };
            result.Add(mill);
            mill = new List<Point> { c5, d5, e5 };
            result.Add(mill);
            mill = new List<Point> { g1, f2, e3 };
            result.Add(mill);
            mill = new List<Point> { g4, f4, e4 };
            result.Add(mill);
            mill = new List<Point> { g7, f6, e5 };
            result.Add(mill);

            return result;
        }

        private void isMill()
        {
            if(currentPlayer=="Red")
            {
                for (int i = 0; i < possibleMills.Count; i++)
                {
                    int count = 0;
                    for (int k = 0; k < Player1.playedPos.Count; k++)
                    {
                        if (possibleMills[i].Contains(Player1.playedPos[k])) count++;
                    }

                    if(count==3 && !Player1.mill_List.Contains(possibleMills[i]))
                    {
                        Player1.mill_List.Add(possibleMills[i]);
                        MessageBox.Show("RED HAS MILL");
                    }
                }
            }
            else
            {
                for (int i = 0; i < possibleMills.Count; i++)
                {
                    int count = 0;
                    for (int k = 0; k < Player2.playedPos.Count; k++)
                    {
                        if (possibleMills[i].Contains(Player2.playedPos[k])) count++;
                    }

                    if (count == 3 && !Player2.mill_List.Contains(possibleMills[i]))
                    {
                        Player2.mill_List.Add(possibleMills[i]);
                        MessageBox.Show("Yellow HAS MILL");
                    }
                }
            }
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

            
            isMill();
            currentPlayer = swapPlayer(currentPlayer);
        }
    }
}
