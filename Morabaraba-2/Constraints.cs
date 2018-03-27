using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Morabaraba_2
{
    class Constraints
    {
        private Player Player1;
        private Player Player2;
        private GUI player1GUI;
        private GUI player2GUI;

        private List<Point> validPos;
        private string currentPlayer;
        private Canvas brd;
        private Label playerTurn;

        private List<List<Point>> possibleMills;
        public bool mill;
        
        public Constraints(Canvas brd)
        {
            this.brd = brd;
            Player1 = new Player("Red",brd);
            Player2 = new Player("Yellow",brd);

            player1GUI = new GUI(Player1);
            player2GUI = new GUI(Player2);

            player1GUI.GUI_pieces_allign();
            player1GUI.GUI_update();
            player2GUI.GUI_pieces_allign();
            player2GUI.GUI_update();

            currentPlayer = "Red";
            playerTurn = new Label();
            validPos = validPositions();
            possibleMills = mill_Possibilities();
            mill = false;

            if (currentPlayer == "Red")
            {
                player2GUI.playerTurn.Visibility = Visibility.Hidden;
            }
        }

        private int xCordinate (double divider)
        {
            return Convert.ToInt32((brd.ActualWidth / divider));
        }

        private int yCordinate(double divider)
        {
            return Convert.ToInt32((brd.ActualHeight / divider));
        }

        private List<Point> validPositions()
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

        private Ellipse candidate(Point p)
        {
            foreach(object ob in brd.Children)
            {
                if(ob is Ellipse)
                {
                    Ellipse x = (Ellipse)ob;
                    if (Canvas.GetLeft(x) + (x.ActualWidth/2) == p.X && Canvas.GetTop(x) + (x.ActualHeight/2) == p.Y)
                    {
                        return x;
                    }
                }
            }
            return null;
        }

        private bool cowIn_MillPos(List<List<Point>> mill_List, Point p)
        {
            for(int i=0;i<mill_List.Count;i++)
            {
                if (mill_List[i].Contains(p)) return true;
            }
            return false;
        }

        public void Eliminate(Point p)
        {
            foreach (Point point in validPos)
            {
                if (Math.Abs(p.X - point.X) <= 70 && Math.Abs(p.Y - point.Y) <= 70)
                {
                    p = point;
                    break;
                }
            }
            
            Ellipse victim = candidate(p); 
            if (victim == null)
            {
                MessageBox.Show("Invalid point, try again");
            }
            else
            {
                if (currentPlayer == "Yellow" && victim.Fill.Equals(Brushes.Yellow) || currentPlayer == "Red" && victim.Fill.Equals(Brushes.Red))
                {
                    if (cowIn_MillPos(Player1.mill_List, p) || cowIn_MillPos(Player2.mill_List, p))
                    {
                        MessageBox.Show("Cannot kill a cow already in a mill, try another cow");
                    }
                    else
                    {
                        brd.Children.Remove(victim);
                        mill = false;
                        if (currentPlayer == "Yellow") Player1.eliminateOpponent(Player2, p);
                        else Player2.eliminateOpponent(Player1, p);
                    }
                }
                else
                {
                    MessageBox.Show("Don't kill yourself, Try again");
                }
            }
            
        }

        public void isMill()
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
                        MessageBox.Show("RED HAS MILL, Choose a cow to eliminate");
                        mill = true;
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
                        MessageBox.Show("Yellow HAS MILL, Choose a cow to eliminate");
                        mill = true;
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
            if(currentPlayer=="Red")
            {
                player2GUI.playerTurn.Visibility = Visibility.Visible;
                player1GUI.playerTurn.Visibility = Visibility.Hidden;
            }
            else
            {
                player1GUI.playerTurn.Visibility = Visibility.Visible;
                player2GUI.playerTurn.Visibility = Visibility.Hidden;
            }

            foreach (Point point in validPos)
            {
                if (Math.Abs(p.X - point.X) <= 70 && Math.Abs(p.Y - point.Y) <= 70)
                {
                    p = point;
                    break;
                }
            }
            if (!validPos.Contains(p))
            {
                MessageBox.Show("You have clicked an invalid point, try again!");
            }
            else if(Player1.playedPos.Contains(p) && Player1.stage=="Placing" || Player2.playedPos.Contains(p) && Player2.stage == "Placing")
            {
                MessageBox.Show("The space is already occupied, try another location");
            }
            else if (Player1.playedPos.Contains(p) && Player1.stage == "Moving" || Player2.playedPos.Contains(p) && Player2.stage == "Moving")
            {
                MessageBox.Show("Time to Move");
                MessageBox.Show("Player 2 stage is:" + Player2.stage);
            }
            else
            {
                if (currentPlayer == "Red") Player1.makeMove(p);
                else Player2.makeMove(p);


                isMill();
                currentPlayer = swapPlayer(currentPlayer);
            }
        }
        
    }
}
